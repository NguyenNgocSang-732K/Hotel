using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Client.Models.ModelView;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Client.Models.DTO
{

    public class AccountDTO
    {
        private static string URL = "http://192.168.6.166:1273/api/";


        public static string Get()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://192.168.6.166:1273/api/account");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = httpClient.GetAsync("").Result;
                HttpStatusCode status = result.StatusCode;
                var content = result.Content.ReadAsStringAsync().Result;
                string rs = content.ToString();
                return rs;
            }
            catch
            {
                return null;
            }
        }

        public static Account LoginAsync(string username, string password)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("http://192.168.6.166:1273/api/account/login");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Add Parameter headers
                //httpClient.DefaultRequestHeaders.Add("email", "nguyenngocsang0868@gmail.com");
                //httpClient.DefaultRequestHeaders.Add("password", "123");

                //Add parameter body
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
                request.Content = new StringContent(JsonConvert.SerializeObject(new { }), Encoding.UTF8, "application/json");
                var result = httpClient.SendAsync(request).Result;
                HttpStatusCode status = result.StatusCode;
                var content = result.Content.ReadAsStringAsync().Result;
                Account rs = JsonConvert.DeserializeObject<Account>(content.ToString());
                return rs;
            }
            catch
            {
                return null;
            }
        }

        //public static async Task<HttpResponseMessage> Login(Account account)
        //{
        //    try
        //    {
        //        HttpClient httpClient = new HttpClient();
        //        HttpRequestMessage httpRequestMessage = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Post,
        //            RequestUri = new Uri(URL + "account/login"),
        //            Content = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json")
        //        };
        //        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
        //        if (httpResponseMessage.IsSuccessStatusCode)
        //        {
        //            return httpResponseMessage;
        //        }
        //        return null;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public static async Task<String> Login(string username, string password)
        //{
        //    try
        //    {
        //        IEnumerable<KeyValuePair<string, string>> query = new List<KeyValuePair<string, string>>()
        //        {
        //            new KeyValuePair<string, string>("username",username),
        //            new KeyValuePair<string, string>("password",password),
        //        };

        //        HttpContent httpContent = new FormUrlEncodedContent(query);
        //        HttpClient httpClient = new HttpClient();
        //        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync("http://192.168.6.166:1273/api/account/login", httpContent);
        //        HttpContent content = httpResponseMessage.Content;
        //        string mycontent = await content.ReadAsStringAsync();
        //        return mycontent;
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //}

        //static async Task<string> PostURI(Uri u, HttpContent c)
        //{
        //    var response = string.Empty;
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage result = await client.PostAsync(u, c);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            response = result.StatusCode.ToString();
        //        }
        //    }
        //    return response;
        //}
    }
}
