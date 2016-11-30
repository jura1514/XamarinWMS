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
        public static string RestUrl = "http://localhost:52326/api/deliveries{0}";
        // Credentials that are hard coded into the REST service
        public static string Username = "Xamarin";
        public static string Password = "Password";
    }
}
