using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using vGuard.Service;

namespace vGuard
{
    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
            InitializeComponent();
        }

        private Guard guard = new Guard();
        protected override void OnStart(string[] args)
        {
            guard.Start();
        }

        protected override void OnStop()
        {
            guard.Stop();
        }
        protected override void OnShutdown()
        {
            guard.OnShutdown();
        }
    }
}
