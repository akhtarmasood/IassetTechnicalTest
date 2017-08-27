using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

using System.Web.Mvc;
using Iasset.WeatherUpdate;
using Iasset.WeatherUpdate.DIResolver;
using Iasset.WeatherUpdate.Models;

namespace Iasset.WeatherUpdate.App_Start
{
    public static class AppUnityConfig
    {
        public static void ConfigUnity()
        {
            IUnityContainer ConfigContainer = new UnityContainer();
            RegisterDependancies(ConfigContainer);
            DependencyResolver.SetResolver(new DependancyResolver(ConfigContainer));
        }

        private static void RegisterDependancies(IUnityContainer UnityContainer)
        {
            UnityContainer.RegisterType<IWeatherUpdate, LocationWeatherUpdate>();
            //UnityContainer.RegisterType<IWeatherUpdate, WeatherUpdatebyLocation>();
        }
    }
}