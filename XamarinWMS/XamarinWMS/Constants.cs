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
        public static string RestUrlDel = "http://mywebwms.azurewebsites.net/api/DeliveryModelApi";
        public static string RestUrlDelLine = "http://mywebwms.azurewebsites.net/api/DeliveryLineModelApi";
        public static string RestUrlOrder = "http://mywebwms.azurewebsites.net/api/OrderModelApi";
        public static string RestUrlPick = "http://mywebwms.azurewebsites.net/api/PickModelApi";
        public static string RestUrlUserRegister = "http://mywebwms.azurewebsites.net/api/Account/Register";
        public static string RestUrlLogin = "http://mywebwms.azurewebsites.net/Token";
        public static string RestUrlLogOut = "http://mywebwms.azurewebsites.net/api/Account/Logout";
        // Credentials that are hard coded into the REST service
        public static string Username = "";
        public static string Password = "";
    }
}
