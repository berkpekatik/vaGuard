using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherService.Model
{
    public class ServerDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string Ts3 { get; set; }
        public string DiscordUrl { get; set; }
    }
}
