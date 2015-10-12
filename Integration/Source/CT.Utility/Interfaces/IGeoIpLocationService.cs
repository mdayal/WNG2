using System.Net;
using CT.Utility.GeoIpAddress;

namespace CT.Utility.Interfaces
{
    public interface IGeoIpLocationService
    {
        Country GetCountry(IPAddress ipAddress);
        Country GetCountry(string ipAddress);
    }
}
