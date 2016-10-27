using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinWMS
{
    public class App : Application
    {
        static DeliveryDatabase dbUtils;
        static DeliveryLineDatabase dbLineUtils;
        public App()
        {

            // The root page of your application
            MainPage = new NavigationPage(new MainMenu());

        }
        public static DeliveryDatabase DelDatabase
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DeliveryDatabase();
                }
                return dbUtils;
            }
        }
        public static DeliveryLineDatabase DelLineDatabase
        {
            get
            {
                if (dbLineUtils == null)
                {
                    dbLineUtils = new DeliveryLineDatabase();
                }
                return dbLineUtils;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
