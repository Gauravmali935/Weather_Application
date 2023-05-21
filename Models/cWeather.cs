using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather_Application.Models
{
    public class cWeather
    {
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
        public class weather
        {
            public string icon { get; set; }
        }
        public class main
        {
            public double temp { get; set; }
            public double temp_max { get; set; }    
        }
        public class root
        {
            public coord coord { get; set; }
            public main main { get; set; }
            public List<weather> weather { get; set; }
        }
    }
}