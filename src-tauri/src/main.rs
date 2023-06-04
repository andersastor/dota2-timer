
// Prevents additional console window on Windows in release, do not remove.
#![cfg_attr(
    all(not(debug_assertions), target_os = "windows"),
    windows_subsystem = "windows"
)]

use async_trait::async_trait;
use dota::{GameStateHandler, GSIServer};
use tauri::{Manager, AppHandle};
use tokio::sync::{mpsc, Mutex};
use tracing_subscriber;
use sysinfo::{System, SystemExt};

struct AsyncProcInputTx {
    _inner: Mutex<mpsc::Sender<String>>,
}


fn main() {
    tracing_subscriber::fmt::init();
    
    let (async_proc_input_tx, async_proc_input_rx) = mpsc::channel(1);
    let (async_proc_output_tx, mut _async_proc_output_rx) = mpsc::channel(1);
    
    tauri::Builder::default()
        .manage(AsyncProcInputTx {
            _inner: Mutex::new(async_proc_input_tx),
        })
        .invoke_handler(tauri::generate_handler![check_process_running])
        .setup(|app| {
            tauri::async_runtime::spawn(async move {
                async_process_model(
                    async_proc_input_rx,
                    async_proc_output_tx,
                ).await
            });

            let app_handle = app.handle();
            tauri::async_runtime::spawn(async move {

                let handler = JsonHandler {
                    manager: app_handle
                };
                
                let server = GSIServer::new("127.0.0.1:3000");
                server.run_with_handler(handler).await.map_err(|err| println!("{:?}", err)).ok();
                
            });

            Ok(())
        })
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}

#[tauri::command]
fn check_process_running() -> bool {
    let s = System::new_all();
    for _process in s.processes_by_exact_name("dota2.exe") {
        // Process is running if it is in list
        return true;
    }
    return false;
}

#[derive(Clone, Debug)]
struct JsonHandler {
    manager: AppHandle
}

#[async_trait]
impl GameStateHandler<serde_json::Value> for JsonHandler {
    async fn handle(self, json: serde_json::Value) {
        let clock_time = json.get("map")
        .and_then(|value| value.get("clock_time"));
    
        match clock_time {
            None => println!("Something went wrong when fetching clock time."),
            Some(time) => {
                match time.as_i64() {
                    None => println!("Clock time is in a non-number parsable format."),
                    Some(time_i64) => {

                        self.manager
                            .emit_all("rs2js", format!("{}", time_i64))
                            .unwrap();

                    // println!("Seconds: {}, clock time: {}:{}", time_i64, (time_i64 % 3600)/60, format!("{:0>2}", time_i64 % 60));
                    }
                }
            }
        }
    }
}

async fn async_process_model(
    mut input_rx: mpsc::Receiver<String>,
    output_tx: mpsc::Sender<String>,
) -> Result<(), Box<dyn std::error::Error + Send + Sync>> {
    while let Some(input) = input_rx.recv().await {
        let output = input;
        output_tx.send(output).await?;
    }

    Ok(())
}