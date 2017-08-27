using Iasset.WeatherUpdate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iasset.WeatherUpdate.Controllers
{

    /*
     Code Author: Akhtar Masood
     Coding Date: 27/08/2017
     Coding Time: 8 Hours approx
     Assignment: Implementing Weather Update Results

        Coding Approach:
        1- Did Analysis of Web Service/Web API.
        2- Upgraded Development Environnment to Visual Studio 2015 Enterprise as instructed. Previoulsy using 2013
        3- Researched Best Practices for DI implementation for MVC.
        4- Designed Interface and Classes for DI.
        5- Implemneted Microsoft Unity Framework for Dependency Injection Implementation as Best Practice
           a. Installed Unity Framework for Nuget Pacakage Manager
           b. Developed Configuration (AppUnityConfig.cs)
           c. Developed Dependancy Resolver Class (DependancyResolver.cs)
           d. I Could have done it c in simple way, got an opputunity to learn new method, so adapted it.
        6- In Model,
            a. Developed one Interface.(IWeatherUpdate.cs)
            b. One Model Class and Methods.(Location.cs)
            c. One Service Class to have one point of service call with Methods.(WeatherUpdateService.cs)
        7- Front End Developed in Angular JS2.


     
         */
    public class WeatherController : Controller
    {
        //// GET: Weather
        private IWeatherUpdate _WeatherInterface;
        private  List<Cities> clist;

        #region "DI Constructor"
        public WeatherController(IWeatherUpdate WInterface)
        {
            _WeatherInterface = WInterface;
        }

        #endregion

        #region "Mehtods"

        public ActionResult Index()
        {
                return View();
        }


        public ActionResult GetCityList(LocationWeatherUpdate CountryName)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            
            clist =_WeatherInterface.GetCityList(CountryName.Country);
            var Cities = new LocationWeatherUpdate() { Country = CountryName.Country, CityList = (IEnumerable<Cities>)clist };

            Session["Country"] = CountryName.Country;
            Session["CityList"] = clist;
            ViewBag.Message = "";
            return View("Index", Cities);

        }

        public ActionResult GetWeatherUpdate(FormCollection SelectedCity)
        {

            ViewBag.Message = "";
            if (SelectedCity["CityList"].ToString()=="")
            {

                var Cities = new LocationWeatherUpdate() { Country = Session["Country"].ToString(), CityList = (IEnumerable<Cities>)Session["CityList"] };
                ViewBag.Message = "Select City fro weather update report!";
                return View("Index", Cities);
            }

            List<string> WeatherUpdate = _WeatherInterface.GetWeatherUpdate(Session["Country"].ToString(), SelectedCity["CityList"].ToString());



            Session["City"] = SelectedCity["CityList"].ToString();

            var TheUpdate = new LocationWeatherUpdate()
            {
                Country = Session["Country"].ToString(),
                CityList = (IEnumerable<Cities>)Session["CityList"],
                Status = WeatherUpdate[0].ToString(),
                CompleteLocation = WeatherUpdate[1].ToString(),
                Time = WeatherUpdate[2].ToString(),
                Wind = WeatherUpdate[3].ToString(),
                Visibility = WeatherUpdate[4].ToString(),
                SkyConditions = WeatherUpdate[5].ToString(),
                Temperature = WeatherUpdate[6].ToString(),
                DewPoint= WeatherUpdate[7].ToString(),
                RelativeHumidity = WeatherUpdate[8].ToString(),
                Pressure= WeatherUpdate[9].ToString()
            };
        
            return View("Index",TheUpdate);
        }

        #endregion
    }
}