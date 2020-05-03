using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherService.Model
{
    public class PlayersModel
    {
        public string Endpoint { get; set; }
        public long Id { get; set; }
        public List<string> Identifiers { get; set; }
        public string Name { get; set; }
        public long Ping { get; set; }
    }
}
