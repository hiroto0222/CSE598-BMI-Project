using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BMIService.Controllers
{
    public class BMIController : ApiController
    {
        // GET: api/BMI/myBMI?height={}&weight={}
        [HttpGet]
        [ActionName("MyBMI")]
        public HttpResponseMessage MyBMI(int height, int weight)
        {
            Health health = new Health(height, weight);

            var responseObj = new
            {
                status = "success",
                data = new
                {
                    BMI = health.bmi
                }
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, responseObj);
            return response;
        }

        // GET: api/BMI/myHealth?height={}&weight={}
        [HttpGet]
        [ActionName("MyHealth")]
        public HttpResponseMessage MyHealth(int height, int weight)
        {
            Health health = new Health(height, weight);

            var responseObj = new
            {
                status = "success",
                data = health
            };

            var response = Request.CreateResponse(HttpStatusCode.OK, responseObj);
            return response;
        }
    }

    public class Health
    {
        public double bmi;
        public string risk;
        public string[] more = {
            "https://www.cdc.gov/healthyweight/assessing/bmi/index.html",
            "https://www.nhlbi.nih.gov/health/educational/lose_wt/index.htm",
            "https://www.ucsfhealth.org/education/body_mass_index_tool/"
        };

        public Health(int height, int weight)
        {
            bmi = CalcBMI(height, weight);
            risk = CalcRisk();
        }

        private double CalcBMI(int height, int weight)
        {
            return (double)weight / height / height * 703;
        }
        
        private string CalcRisk()
        {
            if (bmi < 18)
            {
                return "Blue Color, You are underweight with BMI < 18"; 
            } else if (bmi < 25)
            {
                return "Green Color, You are normal with BMI >= 18 and < 25";
            } else if (bmi <= 30)
            {
                return "Purple Color, You are pre-obese with BMI >= 25 and <= 30";
            } else
            {
                return "Red Color, You are obese with BMI > 30";
            }
        }
    }
}
