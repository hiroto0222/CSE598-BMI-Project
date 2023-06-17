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

            BMIServiceReference.BMIServiceSoapClient client = new BMIServiceReference.BMIServiceSoapClient();

            Console.WriteLine("Call MyBMI");
            double bmi = await client.MyBMIAsync(height, weight);
            Console.WriteLine("bmi: " + bmi);

            Console.WriteLine("Call MyHealth");
            BMIServiceReference.MyHealthResponse res = await client.MyHealthAsync(height, weight);
            BMIServiceReference.Health health = res.Body.MyHealthResult;
            Console.WriteLine("bmi: " + health.bmi);
            Console.WriteLine("risk: " + health.risk);
            Console.WriteLine("more: " + string.Join(", ", health.more));

            // Wait for user input before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
