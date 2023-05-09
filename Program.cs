using System;
using System.Net.Http.Headers;

namespace dota2_timer
{
    internal class Program
    {
        private static string version = "1.0.0";

        private static System.Timers.Timer riverTimer;
        private static System.Timers.Timer wisdomTimer;
        private static System.Timers.Timer bountyTimer;
        private static System.Timers.Timer lotusTimer;
        private static System.Timers.Timer tormentorTimer;
        private static System.Timers.Timer tierOneTimer;
        private static System.Timers.Timer tierTwoTimer;
        private static System.Timers.Timer tierThreeTimer;
        private static System.Timers.Timer tierFourTimer;
        private static System.Timers.Timer tierFiveTimer;

        private static System.Timers.Timer resetTimer;

        private static DateTime startTime;
        private static string currentItemTier = "";

        static void Main(string[] args)
        {
            startTime = DateTime.Now;

            SetTimers();
            PrintHeaderText();

            Console.ReadLine();

            disposeTimers();
        }

        private static void SetTimers()
        {
            double fifteenSeconds = 1000 * 30;
            double twoMinutes = 1000 * 60 * 2;
            double threeMinutes = 1000 * 60 * 3;
            double sevenMinutes = 1000 * 60 * 7;
            double seventeenMinutes = 1000 * 60 * 17;
            double twentyMinutes = 1000 * 60 * 20;
            double twentysevenMinutes = 1000 * 60 * 27;
            double thirtysevenMinutes = 1000 * 60 * 37;
            double sixtyMinutes = 1000 * 60 * 60;

            riverTimer = new System.Timers.Timer(twoMinutes);
            riverTimer.Elapsed += delegate { RuneTimerElapsed("River rune"); };
            riverTimer.Enabled = true;

            bountyTimer = new System.Timers.Timer(threeMinutes);
            bountyTimer.Elapsed += delegate { RuneTimerElapsed("Bounty rune"); };
            bountyTimer.Enabled = true;

            lotusTimer = new System.Timers.Timer(threeMinutes);
            lotusTimer.Elapsed += delegate { RuneTimerElapsed("Lotus rune"); };
            lotusTimer.Enabled = true;

            wisdomTimer = new System.Timers.Timer(sevenMinutes);
            wisdomTimer.Elapsed += delegate { RuneTimerElapsed("Wisdom rune"); };
            wisdomTimer.Enabled = true;

            tormentorTimer = new System.Timers.Timer(twentyMinutes);
            tormentorTimer.Elapsed += delegate { RuneTimerElapsed("Tormentor"); };
            tormentorTimer.AutoReset = false;
            tormentorTimer.Enabled = true;

            tierOneTimer = new System.Timers.Timer(sevenMinutes);
            tierOneTimer.Elapsed += delegate { ItemTimerElapsed("Tier one"); };
            tierOneTimer.AutoReset = false;
            tierOneTimer.Enabled = true;

            tierTwoTimer = new System.Timers.Timer(seventeenMinutes);
            tierTwoTimer.Elapsed += delegate { ItemTimerElapsed("Tier two"); };
            tierTwoTimer.AutoReset = false;
            tierTwoTimer.Enabled = true;

            tierThreeTimer = new System.Timers.Timer(twentysevenMinutes);
            tierThreeTimer.Elapsed += delegate { ItemTimerElapsed("Tier three"); };
            tierThreeTimer.AutoReset = false;
            tierThreeTimer.Enabled = true;

            tierFourTimer = new System.Timers.Timer(thirtysevenMinutes);
            tierFourTimer.Elapsed += delegate { ItemTimerElapsed("Tier four"); };
            tierFourTimer.AutoReset = false;
            tierFourTimer.Enabled = true;

            tierFiveTimer = new System.Timers.Timer(sixtyMinutes);
            tierFiveTimer.Elapsed += delegate { ItemTimerElapsed("Tier five"); };
            tierFiveTimer.AutoReset = false;
            tierFiveTimer.Enabled = true;

            resetTimer = new System.Timers.Timer(fifteenSeconds);
            resetTimer.Elapsed += delegate { resetElapsed(); };
            resetTimer.AutoReset = false;
        }

        private static void RuneTimerElapsed(string rune)
        {
            resetTimer.Enabled = true;
            Console.WriteLine(rune + " has spawned" + "\n---------////////---------");
        }
        private static void ItemTimerElapsed(string itemTier)
        {
            resetTimer.Enabled = true;
            currentItemTier = itemTier + " items are now dropping";
            Console.WriteLine(currentItemTier + "\n---------////////---------");
        }

        private static void resetElapsed()
        {
            Console.Clear();
            PrintHeaderText();
        }

        private static void PrintHeaderText()
        {
            Console.WriteLine($"Dota 2 Timer Support v{version} https://github.com/andersastor/dota2-timer");
            Console.WriteLine("The application started at {0:HH:mm:ss.fff}, rune and item timers are now active", startTime);
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine(currentItemTier + "\n");
        }

        private static void disposeTimers()
        {
            riverTimer.Stop();
            riverTimer.Dispose();

            wisdomTimer.Stop();
            wisdomTimer.Dispose();

            bountyTimer.Stop();
            bountyTimer.Dispose();

            lotusTimer.Stop();
            lotusTimer.Dispose();

            tormentorTimer.Stop();
            tormentorTimer.Dispose();

            tierOneTimer.Stop();
            tierOneTimer.Dispose();

            tierTwoTimer.Stop();
            tierTwoTimer.Dispose();

            tierThreeTimer.Stop();
            tierThreeTimer.Dispose();

            tierFourTimer.Stop();
            tierFourTimer.Dispose();

            tierFiveTimer.Stop();
            tierFiveTimer.Dispose();

            resetTimer.Stop();
            resetTimer.Dispose();
        }
    }
}
