using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using DTO;
using Newtonsoft.Json;

namespace StudentManagement.API
{
    public class API<T>
    {
        private HttpClient apiClient { get; set; }

        private static API<T> instance;
        public static API<T> Instance
        {
            get
            {
                if (instance == null)
                    instance = new API<T>();
                return instance;
            }
        }

        private API()
        {
            Init();
        }

        private void Init()
        {
            string api = ConfigurationManager.AppSettings["api"]; //stirng localhost set trong appsettings

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> Post(string route, object body)
        {
            Init();

            using (HttpResponseMessage response = await apiClient.PostAsJsonAsync(route, body)) // đường dẫn và body info, chờ đợi server response
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<T>(jsonstring);
                    if (data != null)
                        return data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
                return default;
            }
        }

        public async Task<T> Get(string route)
        {
            using (HttpResponseMessage response = await apiClient.GetAsync(route))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<T>(jsonstring);
                    if (data != null)
                        return data;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
                return default;
            }
        }
    }
}
