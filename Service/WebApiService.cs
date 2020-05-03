using LauncherService.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LauncherService.Service
{
    public class WebApiService : IWebApiService
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<T> Get<T>(string url)
        {
            try
            {
                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch
            { 
                return default(T);
            }
        }

        public async Task<T> Get<T>(string url, Dictionary<dynamic, dynamic> values)
        {
            try
            {
                url = url + "?";
                foreach (var item in values)
                {
                    url = url + item.Key + "=" + item.Value + "&";
                }
                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch
            {
                return default(T);
            }
        }

        public async Task<T> GetPostAsync<T>(string url)
        {
            try
            {
                var response = await client.PostAsync(url, null);
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch
            {
                return default(T);
            }

        }

        public async Task<T> GetPostAsync<T>(string url, Dictionary<string, string> values)
        {
            try
            {
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseString);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
