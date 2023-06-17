using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BMIClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var weight = 140;
            var height = 67;
            var api = new WebApiClient();
            await api.GetMyBMI(weight, height);
            await api.GetMyHealth(weight, height);

            // Wait for user input before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    public class WebApiClient
    {
        private readonly static HttpClient Client = new HttpClient();
        private readonly string apiBaseURL = "https://localhost:44396/api/BMI/";

        public async Task GetMyBMI(int weight, int height)
        {
            try
            {
                Console.WriteLine("Call GET api/BMI/MyBMI");
                var res = await Client.GetAsync(apiBaseURL + $"MyBMI?weight={weight}&height={height}");
                res.EnsureSuccessStatusCode();
                var resBody = await res.Content.ReadAsStringAsync();
                Console.WriteLine(resBody);
            } catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("End");
        }

        public async Task GetMyHealth(int weight, int height)
        {
            try
            {
                Console.WriteLine("Call GET api/BMI/MyHealth");
                var res = await Client.GetAsync(apiBaseURL + $"MyHealth?weight={weight}&height={height}");
                res.EnsureSuccessStatusCode();
                var resBody = await res.Content.ReadAsStringAsync();
                Console.WriteLine(resBody);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("End");
        }
    }
}
