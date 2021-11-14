using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:5000/values");
                response.EnsureSuccessStatusCode();
                if(response.IsSuccessStatusCode)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(message);
                }
                else
                {
                    Console.WriteLine($"response error code : {response.StatusCode}");
                }
            }
        }
    }
}
