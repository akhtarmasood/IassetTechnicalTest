using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Iasset.WeatherUpdate.Models
{
    public class LocationWeatherUpdate:IWeatherUpdate
    {


        private WeatherUpdateService ws;
        private  List<Cities> Cities;
      

        [Required]
        [StringLength(15)]
        [Display(Name = "Country")]
        public string Country { get; set; }


        [Display(Name = "City:")]
        public IEnumerable<Cities> CityList { get; set; }


        [Display(Name = "Location:")]
        public string CompleteLocation { get; set; }

        [Display(Name = "Time:")]
        public string Time { get; set; }

        [Display(Name = "Wind:")]
        public string Wind { get; set; }

        [Display(Name = "Visibility:")]
        public string Visibility { get; set; }

        [Display(Name = "Sky Condition:")]
        public string SkyConditions { get; set; }

        [Display(Name = "Temperature:")]
        public string Temperature { get; set; }

        [Display(Name = "Dew Point:")]
        public string DewPoint { get; set; }

        [Display(Name = "Humidity:")]
        public string RelativeHumidity { get; set; }

        [Display(Name = "Pressure:")]
        public string Pressure { get; set; }


        [Display(Name = "Status:")]
        public string Status { get; set; }

        public List<Cities> GetCityList(string Country)
        {

            ws = new Models.WeatherUpdateService();
            return  ws.GetCityListbyCountry(Country);
           

        }

        public List<string> GetWeatherUpdate(string Country, string City)
        {
            ws = new Models.WeatherUpdateService();
            return ws.GetWeatherUpdate(Country,City);
        }
    }

    public class Cities
    {
        public string CityName { get; set; }
    }
}