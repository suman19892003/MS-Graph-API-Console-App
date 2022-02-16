using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public class ListColl
        {
            public string webUrl { get; set; }

            public fields fields { get; set; }
        }
        public class fields
        {
            public string Topic { get; set; }
            public string Subject { get; set; }
            public string Category { get; set; }
        }
        static void Main(string[] args)
        {
            GetDataAsync().GetAwaiter().GetResult();
            Console.ReadKey();
        }
        static async Task GetDataAsync()
        {
            Console.WriteLine("Get Data from SP List");
            using (var client = new HttpClient())
            {
                var token = await GetTokenAsync();
                if (!string.IsNullOrEmpty(token))
                {
                    //list Item URL
                    //var message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/sites/your site ID/lists/c22a7277-f724-4f65-9a8e-a4f0a36c25d9/items?$expand=fields($select=Title,Description)");
                    var message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/sites/Your Site ID/lists/5c3cd208-1e89-4a1b-9e0c-4e50044c3332/items?$expand=fields");
                    message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                    var response = await client.SendAsync(message);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        JObject o = JObject.Parse(json);
                        JArray a = (JArray)o["value"];
                        IList<ListColl> person = a.ToObject<IList<ListColl>>();
                        Console.WriteLine(person[0].webUrl);
                        Console.WriteLine(person[0].fields.Topic);
                        Console.WriteLine(person[0].fields.Category);
                    }
                }
            }
        }
        static async Task<string> GetTokenAsync()
        {
            var clientId = "Client ID";
            var authorityUri = $"https://login.microsoftonline.com/common";
            var redirectUri = "https://localhost";//Ensure that this URL is added as Redirect URL in APP Registration
            var scopes = new List<string> { "User.Read", "Sites.Read.All" };
            var publicClient = PublicClientApplicationBuilder
                          .Create(clientId)
                          .WithAuthority(new Uri(authorityUri))
                          .WithRedirectUri(redirectUri)
                          .Build();
            var accessTokenRequest = publicClient.AcquireTokenInteractive(scopes);
            var accessToken = accessTokenRequest.ExecuteAsync().Result.AccessToken;
            return accessToken;
        }
    }
}