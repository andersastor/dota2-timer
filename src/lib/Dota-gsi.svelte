<script lang="ts">
	import { invoke } from "@tauri-apps/api/tauri"
	import { listen } from '@tauri-apps/api/event'
	import { clock_time } from "../util/stores";
	import { formatTime } from "../util/time-formatting";
	import TimerList from "./timer-list.svelte";


	async function promise() {
	    await listen('rs2js', (event) => {
	        let input = event.payload
	        clock_time.update(n => Number(input)); // eslint-disable-line @typescript-eslint/no-unused-vars
	    });
	}

	let doProcessRunningCheck = checkProcessRunning();

	async function checkProcessRunning(): Promise<boolean> {
        return invoke('check_process_running');
      }

  function retry() {
    doProcessRunningCheck = checkProcessRunning();
  }


</script>

<div style="display: grid; grid-template-columns: auto auto; margin: 8px;">
  
  {#await doProcessRunningCheck then result}
    {#if result == false}
      <p> Dota 2 appears to not be running, please launch the game and try again. </p>
      <button on:click={retry}>Refresh</button>
    {:else}
      {#await promise()}
      <!-- Empty codeblock -->
      {/await}
      
      <div style="grid-column: 2; grid-row: 2;">
        <h3>Clock time</h3>
        {formatTime($clock_time)}
        <TimerList></TimerList>
      </div>
    {/if}
  {/await}

</div>