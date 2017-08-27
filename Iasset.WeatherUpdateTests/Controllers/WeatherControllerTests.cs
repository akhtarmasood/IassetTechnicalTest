using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iasset.WeatherUpdate.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iasset.WeatherUpdate.Controllers.Tests
{
    [TestClass()]
    public class WeatherControllerTests
    {
        [TestMethod()]
        public void GetCityListFromServiceTest()
        {
            
            WeatherUpdate.Models.LocationWeatherUpdate Test1 = new WeatherUpdate.Models.LocationWeatherUpdate();
            List<Models.Cities> Cities = Test1.GetCityList("Australia");
            Console.Write(Cities.Count.ToString());
            Assert.IsTrue(Cities.Count > 0, "City Retrieving Service is working in proper order");
                        
        }


        [TestMethod()]
        public void GetWeatherUpdateFromService()
        {
            WeatherUpdate.Models.LocationWeatherUpdate Test2 = new WeatherUpdate.Models.LocationWeatherUpdate();

            List<string> WeatherUpdateResult = Test2.GetWeatherUpdate("Australia","Sydney");

            Assert.IsTrue(WeatherUpdateResult[0].ToString().Contains("Mocked"), "The Service is not Function");

            Assert.Fail();
        }
    }
}