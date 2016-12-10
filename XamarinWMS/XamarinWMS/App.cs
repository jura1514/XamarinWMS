using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinWMS.Data;
using XamarinWMS.Data.Web_Service;

namespace XamarinWMS
{
    public class App : Application
    {
        //connections to RestApi
        public static DeliveryManager DelManager { get; private set; }
        public static DeliveryLineManager DelLineManager { get; private set; }
        public static OrderManager OrderManager { get; private set; }
        public static UserManager UserManager { get; private set; }


        //connections to phone Db
        static DeliveryDatabase dbDelivery;
        static DeliveryLineDatabase dbDelLine;
        static StockDatabase dbStock;
        static LocationDatabase dbLocation;
        static ProdDatabase dbProd;
        static OrderDatabase dbOrder;
        static PickDatabase dbPick;
        static UserDatabase dbUser;

        public App()
        {
            DelManager = new DeliveryManager(new RestService());
            DelLineManager = new DeliveryLineManager(new RestService());
            OrderManager = new OrderManager(new RestService());
            UserManager = new UserManager(new RestService());
            // The root page of your application
            MainPage = new NavigationPage(new MainMenu());

        }
        public static DeliveryDatabase DelDatabase
        {
            get
            {
                if (dbDelivery == null)
                {
                    dbDelivery = new DeliveryDatabase();
                }
                return dbDelivery;
            }
        }
        public static DeliveryLineDatabase DelLineDatabase
        {
            get
            {
                if (dbDelLine == null)
                {
                    dbDelLine = new DeliveryLineDatabase();
                }
                return dbDelLine;
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
        public static UserDatabase UserDatabase
        {
            get
            {
                if (dbUser == null)
                {
                    dbUser = new UserDatabase();
                }
                return dbUser;
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
