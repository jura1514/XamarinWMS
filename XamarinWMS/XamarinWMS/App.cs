using Xamarin.Forms;
using XamarinWMS.Data;
using XamarinWMS.Data.Web_Service;
using XamarinWMS.View.Login;

namespace XamarinWMS
{
    public class App : Application
    {
        //connections to RestApi
        public static DeliveryManager DelManager { get; private set; }
        public static DeliveryLineManager DelLineManager { get; private set; }
        public static OrderManager OrderManager { get; private set; }
        public static PickManager PickManager { get; private set; }
        public static UserManager UserManager { get; private set; }
        public static LocationManager LocManager { get; private set; }
        public static ProductManager ProdManager { get; private set; }


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
            PickManager = new PickManager(new RestService());
            UserManager = new UserManager(new RestService());
            LocManager = new LocationManager(new RestService());
            ProdManager = new ProductManager(new RestService());
            // The root page of your application
            MainPage = new NavigationPage(new MainMenu());

        }

        public static DeliveryDatabase DelDatabase
        {
            get
            {
                if (dbDelivery == null)
                {
                    dbDelivery = new DeliveryDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinWMS.db3"));
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
                    dbDelLine = new DeliveryLineDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinWMS.db3"));
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
                    dbStock = new StockDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinWMS.db3"));
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
                    dbLocation = new LocationDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinWMS.db3"));
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
                    dbProd = new ProdDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinWMS.db3"));
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
                    dbOrder = new OrderDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinWMS.db3"));
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
                    dbPick = new PickDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinWMS.db3"));
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
                    dbUser = new UserDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("XamarinWMS.db3"));
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
