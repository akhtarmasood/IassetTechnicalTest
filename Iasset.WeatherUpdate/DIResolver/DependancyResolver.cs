using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Iasset.WeatherUpdate.DIResolver
{
    public class DependancyResolver : IDependencyResolver
    {
        private IUnityContainer _thisContainer;

        public DependancyResolver(IUnityContainer ConfigContainer)
        {

            _thisContainer = ConfigContainer;
        }
        public object GetService(Type serviceType)
        {

            try
            {
                return _thisContainer.Resolve(serviceType);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return null;
            }

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _thisContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<Object>();
            }

        }
    }
}