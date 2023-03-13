using System.Net;
using System.Net.Sockets;

namespace Core.Application.Helpers
{
    public static class GetIpAddress
    {
        public static string GetIpAddres()
        {
            IPHostEntry iphostInfo = Dns.GetHostEntry(Dns.GetHostName());
            string ipAddress = Convert.ToString(iphostInfo.AddressList.FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork));
            return ipAddress;
        }
              
    }
}