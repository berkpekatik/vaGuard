using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using vGuard.Model;
using Timer = System.Timers.Timer;

namespace vGuard.Service
{
    public class Guard
    {
        private WebClient webClient = new WebClient();
        private CheatModel cheatList = new CheatModel();
        private Timer timer = new Timer();
        private Timer cheatController = new Timer();
        public void Start()
        { 
            DownloadCheatList();
            cheatController.Elapsed += new ElapsedEventHandler(OnCheatControlTime);
            cheatController.Interval = 3000;
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 10000;
            timer.Enabled = true;
            cheatController.Enabled = true;
        }

        private void OnElapsedTime(object sender, ElapsedEventArgs e)
        {
            DownloadCheatList();
        }
        private void OnCheatControlTime(object sender, ElapsedEventArgs e)
        {
            ControlCheats();
        }

        void DownloadCheatList()
        {
            cheatList = JsonConvert.DeserializeObject<CheatModel>(webClient.DownloadString("http://berkpekatik.com/cheat.json"));
        }
        void ControlCheats()
        {
            foreach (var item in cheatList.CheatList)
            {
                var process = Process.GetProcesses().Where(x =>
                x.ProcessName.ToLower().StartsWith(item) ||
                x.ProcessName.ToLower().Contains(item) ||
                x.MainWindowTitle.ToLower().StartsWith(item) ||
                x.MainWindowTitle.ToLower().Contains(item) ||
                x.ProcessName.ToLower() == item ||
                x.MainWindowTitle.ToLower() == item);
                if (process.Any())
                {
                    process.ToList().ForEach(x => x.Kill());
                    CloseFivem();
                }
            }
        }
        void CloseFivem()
        {
            try
            {
                var fivem = Process.GetProcessesByName("FiveM");
                if (fivem.Any()) fivem.First().Kill();
                else return;
            }
            catch
            {

            }
        }
        public void Stop()
        {
            CloseFivem();
        }
        public void OnShutdown()
        {
            var fivem = Process.GetProcessesByName("FiveM");
            if (fivem.Any()) fivem.First().Kill();
        }
    }
}
