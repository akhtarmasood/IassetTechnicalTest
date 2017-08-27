using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Iasset.WeatherUpdate.Startup))]
namespace Iasset.WeatherUpdate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
