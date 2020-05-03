using LauncherService.Interface;
using LauncherService.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherService.Service
{

    public class ServerService : IServerService
    {
        private static ServerDetailsModel model = new ServerDetailsModel();
        private readonly IWebApiService _webApiService;

        public ServerService(IWebApiService webApiService)
        {
            _webApiService = webApiService;
        }
        public void GetPlayers()
        {
            throw new NotImplementedException();
        }

        public void GetSetup()
        {
            throw new NotImplementedException();
        }

        public async Task GetStartupAsync(string serverKey)
        {
            var service = ServiceController.GetServices(Environment.MachineName).Where(x => x.DisplayName == "vaGuard");
            if (service.Any() && service.First().Status == ServiceControllerStatus.Running)
            {
                await GetAssemblyAsync();
            }
            else if (service.Any() && service.First().Status == ServiceControllerStatus.Stopped)
            {
                service.First().Start();
                await GetAssemblyAsync();
            }
            else
            {
                MessageBox.Show("vaGuard aktif değil, lütfen kontrol edin.");
                Application.Exit();
            }
        }
        private async Task GetAssemblyAsync()
        {
            try
            {
                model = await _webApiService.Get<ServerDetailsModel>("");
                if (model.Id == 0)
                {
                    MessageBox.Show("ServerKey'e uluşılamadı.");
                    Application.Exit();
                }
            }
            catch
            {
                MessageBox.Show("ServerKey'e uluşılamadı.");
                Application.Exit();
            }
        }
        public void GetStatus()
        {
            throw new NotImplementedException();
        }
    }
}
