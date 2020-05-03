using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherService.Interface
{
    interface IServerService
    {
        Task GetStartupAsync(string serverKey);
        void GetSetup();
        void GetStatus();
        void GetPlayers();
    }
}
