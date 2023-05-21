using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Weather_Application.Models;
using static System.Net.WebRequestMethods;

namespace Weather_Application.Controllers
{
    public class WeatherController : Controller
    {
        string apikey = "fc0d85e7b2ec78dc8bfd62454d7f651a";//weather api key for access the api
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(City objCity) 
        {
            try
            {
               string[] wResult = getWather(objCity.CityName);

                ViewBag.Weather = wResult[0];
                ViewBag.CityName = objCity.CityName;
                ViewBag.Img = wResult[1];
            }
            catch(Exception e) 
            {
                return View("Error " + e.Message);
            }
            return View();
        }
        public string[] getWather(string city)
        {
            string[] result = new string[3];
            using (WebClient web = new WebClient()) //seding a requect to the url
            {
                if (string.IsNullOrEmpty(city))
                {
                    //MessageBox.Show("uh? Please Provide a City Name!");
                }
                else
                {
                    try
                    {
                        string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", city, apikey);
                        var json = web.DownloadString(url);
                        cWeather.root info = JsonConvert.DeserializeObject<cWeather.root>(json);
                        string sInfo = info.main.temp.ToString(); // calling a class from weather.cs
                        
                        //Convert Temperature into Celsius
                        float f = float.Parse(sInfo);
                        int k = Convert.ToInt32(f - 273); //convert the temperature into celsius

                        result[0] = k.ToString() + "°C";
                        result[1] = "https://openweathermap.org/img/w/" + info.weather[0].icon + ".png";
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Please Enter valid City Name\n" + ex.Message, "Error");
                        result[2] = ex.Message;
                    }
                }
                return result;
            }
        }
    }
}