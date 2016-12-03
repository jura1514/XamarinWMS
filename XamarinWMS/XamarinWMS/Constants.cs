using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinWMS
{
    public static class Constants
    {
        // URL of REST service
        public static string RestUrlDel = "http://192.168.0.37:52326/api/DeliveryWeb";
        public static string RestUrlDelLine = "http://192.168.0.37:52326/api/DeliveryLineWeb";
        public static string RestUrlOrder = "http://192.168.0.37:52326/api/OrderWeb";
        // Credentials that are hard coded into the REST service
        public static string Username = "";
        public static string Password = "";
    }
}
