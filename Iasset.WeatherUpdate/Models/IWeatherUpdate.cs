using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iasset.WeatherUpdate.Models
{
    public interface IWeatherUpdate
    {
        List<Cities> GetCityList(string Country);
        List<string> GetWeatherUpdate(string Country, string City);
    }
}
