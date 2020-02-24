using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Client.Supports
{
    public class ConstantCuaSang
    {
        public static string IP4()
        {
            string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1].ToString();
            return ip;
        }
    }
}
