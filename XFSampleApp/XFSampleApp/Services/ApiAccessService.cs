using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using XFSampleApp.models;

namespace XFSampleApp.Services
{
    public class ApiAccessService
    {
        private static System.Net.Http.HttpClient _httpClient;
        private static string baseUrl = "https://xamarinclassdemo.azurewebsites.net/api";

        private static System.Net.Http.HttpClient HttpClient
        {
            get
            {
                if (_httpClient == null)
                    _httpClient = new System.Net.Http.HttpClient();
                return _httpClient;
            }
        }

        public static async Task<ObservableCollection<SchoolInfo>> GetSchoolDataFromWebApi()
        {
            HttpClient.DefaultRequestHeaders.Clear();
            var urlStr = $"{baseUrl}/getschoolinfos";
            var resultStr = await HttpClient.GetStringAsync(urlStr);

            System.Diagnostics.Debug.WriteLine(resultStr);

            var schoolInfos = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<SchoolInfo>>(resultStr);
            return schoolInfos;
        }

        public static async Task<string> PostToAuthWebApi(string account, string password)
        {
            var urlStr = $"{baseUrl}/login";

            HttpClient.DefaultRequestHeaders.Add("username", account);
            HttpClient.DefaultRequestHeaders.Add("password", password);

            var authContent = new System.Net.Http.StringContent("");

            var result = await HttpClient.PostAsync(urlStr, authContent);

            var resultStr = await result.Content.ReadAsStringAsync();
            return resultStr;
        }
    }
}
