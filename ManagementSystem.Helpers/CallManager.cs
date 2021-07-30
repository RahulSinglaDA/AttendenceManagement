using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ManagementSystem.Helpers
{
    public class CallManager<T>
    {
        public static T Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = client.GetAsync(url).Result)
                {
                    if(res.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        HttpContent content = res.Content;
                        string responseJson = content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(responseJson);
                    }
                    else
                    {
                        return default(T);
                    }
                }
            }
        }

        public static async void Post(T obj, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent reqContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (HttpResponseMessage res = await client.PostAsync(url, reqContent))
                {
                    HttpContent content = res.Content;
                    var responseJson = await content.ReadAsStringAsync();
                    Console.WriteLine(responseJson);
                }
            }
        }

        public static async void Put(T obj, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent reqContent = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                using (HttpResponseMessage res = await client.PutAsync(url, reqContent))
                {
                    HttpContent content = res.Content;
                    var responseJson = await content.ReadAsStringAsync();
                    Console.WriteLine(responseJson);
                }
            }
        }

        public static async void Delete(T obj, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(url))
                {
                    HttpContent content = res.Content;
                    var responseJson = await content.ReadAsStringAsync();
                    Console.WriteLine(responseJson);
                }
            }
        }

    }
}
