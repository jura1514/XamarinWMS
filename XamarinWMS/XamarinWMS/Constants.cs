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
        public static string RestUrlDel = "http://192.168.0.37:52326/api/DeliveryModelApi";
        public static string RestUrlDelLine = "http://192.168.0.37:52326/api/DeliveryLineModelApi";
        public static string RestUrlOrder = "http://192.168.0.37:52326/api/OrderModelApi";
        public static string RestUrlPick = "http://192.168.0.37:52326/api/PickModelApi";
        public static string RestUrlUserRegister = "http://192.168.0.37:52326/api/Account/Register";
        public static string RestUrlLogin = "http://192.168.0.37:52326/Token";
        public static string RestUrlLogOut = "http://192.168.0.37:52326/api/Account/Logout";
        // Credentials that are hard coded into the REST service
        public static string Username = "";
        public static string Password = "";
    }
}
