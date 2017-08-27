using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iasset.WeatherUpdate.WeatherUpdateService;
using System.Net;
using System.Xml;

namespace Iasset.WeatherUpdate.Models
{
    public class WeatherUpdateService
    {

       
        GlobalWeatherSoapClient WService;
        
        public WeatherUpdateService()
        {
            WService = new GlobalWeatherSoapClient("GlobalWeatherSoap");
            
        }
            
        public List<string> GetWeatherUpdate(string Country, string City)
        {
            List<string> WeatherUpdate = new List<string>();
            string ServiceResponse = WService.GetWeather(Country, City);
            string Status = "";

            if (ServiceResponse == "Data Not Found")
            {
                //Webclient Code will be executed here
                //Time for a break.g

                using (var client = new WebClient())
                {
                    try
                    {
                        client.Headers.Add("content-type", "application/json");//
                        string response = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + City);
                    }
                    catch (Exception p)
                    {
                        Status = "WebAPIError";
                    }

                }
            }

            if (Status != "" || Status == "WebAPIError")////It Means the Webservice and WebAPI Service both did not provided any Results so provided Mocked Data
            {
                Random rnum = new Random();
                
                WeatherUpdate.Add("The data is Mocked. The service did not gave any WeatherUpdate");//Status
                WeatherUpdate.Add(City +", "+ Country);//Location
                WeatherUpdate.Add(System.DateTime.Now.ToLongDateString());//Time
                WeatherUpdate.Add( rnum.Next(0,99).ToString() +" Km/h");//Wind
                WeatherUpdate.Add(rnum.Next(0, 99).ToString() + "%");//Visibility
                WeatherUpdate.Add("Windy");//SkyConditions
                WeatherUpdate.Add(rnum.Next(0, 99).ToString() + "C | "+ rnum.Next(0, 99).ToString() + "F");//Temperature
                WeatherUpdate.Add(rnum.Next(0, 99).ToString() + "%");//DewPoint
                WeatherUpdate.Add(rnum.Next(0, 99).ToString() + "%");//RelativeHumidity
                WeatherUpdate.Add(rnum.Next(0, 99).ToString() + " mph");//Pressure

            }
           
            
            return WeatherUpdate;



        }
       public List<Cities> GetCityListbyCountry(string CountryName)
        {
            List<Cities> clist=null;
            string Countries = WService.GetCitiesByCountry(CountryName);//Add Timeout Exception

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Countries);

            XmlNodeList list = doc.GetElementsByTagName("City");

            if (list.Count > 0)
            {
                clist = new List<Cities>();
                for (int i = 0; i <= list.Count - 1; i++)
                {
                    clist.Add(new Cities() { CityName = list.Item(i).InnerText });
                }

            }

            return clist;
        }
    }
}