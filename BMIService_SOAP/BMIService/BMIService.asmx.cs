using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace BMIService
{
    /// <summary>
    /// Summary description for BMIService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BMIService : System.Web.Services.WebService
    {

        [WebMethod]
        public double MyBMI(int height, int weight)
        {
            Health health = new Health(height, weight);
            return health.bmi;
        }

        [WebMethod]
        public Health MyHealth(int height, int weight)
        {
            Health health = new Health(height, weight);
            return health;
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

        public Health() { }

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
            }
            else if (bmi < 25)
            {
                return "Green Color, You are normal with BMI >= 18 and < 25";
            }
            else if (bmi <= 30)
            {
                return "Purple Color, You are pre-obese with BMI >= 25 and <= 30";
            }
            else
            {
                return "Red Color, You are obese with BMI > 30";
            }
        }
    }
}
