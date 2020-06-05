using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace kkkk
{
    class Program
    {
        static string userName = "userName";
        static string password = "userPassword";
        static string InfoBipUrl = "http://api.infobip.com/sms/1/text/single";

        static void Main(string[] args)
        {
            try
            {

                HttpClient _client = new HttpClient();

                _client.DefaultRequestHeaders.Authorization =
              new AuthenticationHeaderValue("Basic",
              Convert.ToBase64String(Encoding.ASCII.GetBytes($"{userName}:{password}")));


                Dictionary<string, string> data = new Dictionary<string, string>();

                data = new Dictionary<string, string>();
                data.Add("from", "{entity name}");
                data.Add("to", "{recipent phone number}");
                data.Add("text", "Testing Infobip SMS Integration");

                HttpResponseMessage response = _client.PostAsync(InfoBipUrl,
                                            new StringContent(JsonConvert.SerializeObject(data),
                                            Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                    Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                else

                    Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}

