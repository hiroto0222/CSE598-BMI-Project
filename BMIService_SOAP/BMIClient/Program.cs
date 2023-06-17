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
            await api.GetMyBMI(height, weight);
            await api.GetMyHealth(height, weight);

            // Wait for user input before exiting
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    public class WebApiClient
    {
        private readonly static HttpClient Client = new HttpClient();
        private readonly string apiBaseURL = "https://localhost:44379/BMIService.asmx";

        public async Task GetMyBMI(int height, int weight)
        {
            try
            {
                Console.WriteLine("Call MyBMI");

                // Set SOAP request body
                var soapRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
                                                   xmlns:tem=""http://tempuri.org/"">
                                        <soap:Body>
                                            <tem:MyBMI>
                                                <tem:height>{height}</tem:height>
                                                <tem:weight>{weight}</tem:weight>
                                            </tem:MyBMI>
                                        </soap:Body>
                                    </soap:Envelope>";
                var content = new StringContent(soapRequest, Encoding.UTF8, "text/xml");

                var res = await Client.PostAsync(apiBaseURL, content);
                var resBody = await res.Content.ReadAsStringAsync();
                Console.WriteLine(resBody);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("End");
        }

        public async Task GetMyHealth(int height, int weight)
        {
            try
            {
                Console.WriteLine("Call MyHealth");

                // Set SOAP request body
                var soapRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
                                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
                                                   xmlns:tem=""http://tempuri.org/"">
                                        <soap:Body>
                                            <tem:MyHealth>
                                                <tem:height>{height}</tem:height>
                                                <tem:weight>{weight}</tem:weight>
                                            </tem:MyHealth>
                                        </soap:Body>
                                    </soap:Envelope>";
                var content = new StringContent(soapRequest, Encoding.UTF8, "text/xml");

                var res = await Client.PostAsync(apiBaseURL, content);
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
