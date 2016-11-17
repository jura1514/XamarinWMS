using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinWMS.Data;

namespace XamarinWMS
{
    public class App : Application
    {
        static DeliveryDatabase dbUtils;
        static DeliveryLineDatabase dbLineUtils;
        static StockDatabase dbStock;
        static LocationDatabase dbLocation;
        static ProdDatabase dbProd;
        static OrderDatabase dbOrder;
        static PickDatabase dbPick;

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

        public static StockDatabase StkDatabase
        {
            get
            {
                if (dbStock == null)
                {
                    dbStock = new StockDatabase();
                }
                return dbStock;
            }
        }

        public static LocationDatabase locDatabase
        {
            get
            {
                if (dbLocation == null)
                {
                    dbLocation = new LocationDatabase();
                }
                return dbLocation;
            }
        }

        public static ProdDatabase prodDatabase
        {
            get
            {
                if (dbProd == null)
                {
                    dbProd = new ProdDatabase();
                }
                return dbProd;
            }
        }

        public static OrderDatabase orderDatabase
        {
            get
            {
                if (dbOrder == null)
                {
                    dbOrder = new OrderDatabase();
                }
                return dbOrder;
            }
        }

        public static PickDatabase pickDatabase
        {
            get
            {
                if (dbPick == null)
                {
                    dbPick = new PickDatabase();
                }
                return dbPick;
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
