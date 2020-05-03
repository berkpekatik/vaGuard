using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LauncherService.Interface
{
    public interface IWebApiService
    {
        Task<T> GetPostAsync<T>(string url);
        Task<T> Get<T>(string url);
        Task<T> GetPostAsync<T>(string url,Dictionary<string, string> values);
        Task<T> Get<T>(string url, Dictionary<dynamic, dynamic> values);
    }
}
