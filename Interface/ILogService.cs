using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherService.Interface
{
    public interface ILogService
    {
        void TextLog();
        void DbLog();
        void ApiLog();
    }
}
