using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Marcucu
{
    class NetworkUtility
    {
        public string GetMacAddress()
        {
            //Instantiate new NI Object and get all network related Interfaces
            NetworkInterface[] ni = NetworkInterface.GetAllNetworkInterfaces();
            //Set container for the MAC Address to be retrieved
            String macAddress = string.Empty;

            //Find the particular NI where the MAC Address is located
            foreach (NetworkInterface adapter in ni)
            {
                if (macAddress == string.Empty)
                {
                    //List all IP Properties. e.g. IpAddress and all that shit
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    //Finaly, get the physical address, a.k.a, the MAC Address. Take note: The GetPhysicalAddress() method returns the MAC Address without the colons!
                    macAddress = String.Join(":", (from z in adapter.GetPhysicalAddress().GetAddressBytes() select z.ToString("X2")).ToArray());
                }
            }

            return macAddress;
        }
    }
}
