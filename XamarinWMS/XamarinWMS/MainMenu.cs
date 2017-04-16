using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWMS.Model;
using XamarinWMS.View;
using XamarinWMS.View.Info;
using XamarinWMS.View.Login;
using XamarinWMS.View.Move;
using XamarinWMS.View.Picking;
using ZXing.Net.Mobile.Forms;

namespace XamarinWMS
{
    class MainMenu : ContentPage
    {

        //check if phone has access to network
        bool isConnected = false;

        public MainMenu()
        {
            NavigationPage.SetHasBackButton(this, false);

            ToolbarItems.Add(new ToolbarItem("Log Out", "", async () =>
            {
                var page = new ContentPage();
                var result = await page.DisplayAlert("LogOut", "Are you sure you want to Log Out?", "Accept", "Cancel");

                if( result )
                {
                    App.UserManager.ResetUserDetails();
                    await Navigation.PushAsync(new Login());
                }
            }));

            Title = "Main Menu";
            var rootLabel = new Label { Text = "XamarinWMS" };

            var buttonInfo = new Button
            {
                Text = "Info"
            };
            var buttonReceive = new Button
            {
                Text = "Receive"
            };
            var buttonStockMove = new Button
            {
                Text = "Move"
            };
            var buttonPickAndDispatch = new Button
            {
                Text = "Picking"
            };
            var buttonOther = new Button
            {
                Text = "Other"
            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = { rootLabel, buttonReceive, buttonStockMove, buttonPickAndDispatch, buttonInfo, buttonOther }
            };

            buttonReceive.Clicked += (sender, args) => Navigation.PushAsync(new ManageDelivery());
            buttonStockMove.Clicked += (sender, args) => Navigation.PushAsync(new MoveWhat());
            buttonPickAndDispatch.Clicked += (sender, args) => Navigation.PushAsync(new ManageOrder());
            buttonInfo.Clicked += (sender, args) => Navigation.PushAsync(new InfoFind());
            buttonOther.Clicked += (sender, args) => Navigation.PushAsync(new Other());


            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;

            CheckForOrdersAndPicks();

            // Get Locations and Products
            CreateOrUpdateLocations();
            CreateOrUpdateProducts();

        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if(!e.IsConnected)
            {
               await DisplayAlert("Error", "Check for your connection.", "OK");
                isConnected = false;
            }
            else
            {
                isConnected = true;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if(!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Error", "Check for your connection.", "OK");
                isConnected = false;
            }
            else
            {
                isConnected = true;
            }
        }

        public async void CheckForOrdersAndPicks()
        {
            if (isConnected)
            {
                List<OrderData> allOrders = App.orderDatabase.GetAllOrders();
                bool isNewOrder;

                for (int i = 0; i < allOrders.Count(); i++)
                {
                    if (allOrders[i].InQueue == true)
                    {
                        isNewOrder = true;
                        allOrders[i].IsDispatched = true;

                        await App.OrderManager.SaveTaskAsync(allOrders[i], isNewOrder);
                        SendPicks(allOrders[i].OrderId);

                        App.orderDatabase.EditOrder(allOrders[i]);
                    }
                }
            }
        }

        public async void SendPicks( int orderId)
        {
            List<PickData> allPicks = App.pickDatabase.GetAllPicksForOrder(orderId);

            for (int k = 0; k < allPicks.Count(); k++)
            {
                await App.PickManager.SaveTaskAsync(allPicks[k], true);
            }
        }

        public async void CreateOrUpdateLocations()
        {
            var restList = await App.LocManager.GetTasksAsync();

            bool isEmpty = !restList.Any();
            if (!isEmpty)
            {
                for (int k = 0; k < restList.Count(); k++)
                {
                    var existentLoc = App.locDatabase.GetLocationById(restList[k].LocationId);

                    if (existentLoc != null)
                    {
                        if (restList[k].LocationId == existentLoc.LocationId)
                        {
                            App.locDatabase.EditLoc(existentLoc);
                        }
                    }
                    else
                    {
                        var vLoc = new LocationData()
                        {
                            LocationId = restList[k].LocationId,
                            StateChangeTime = restList[k].StateChangeTime,
                            LocState = restList[k].LocState,
                        };
                        App.locDatabase.SaveLoc(vLoc);
                    }
                }
            }
        }

        public async void CreateOrUpdateProducts()
        {
            var restList = await App.ProdManager.GetTasksAsync();

            bool isEmpty = !restList.Any();
            if (!isEmpty)
            {
                for (int k = 0; k < restList.Count(); k++)
                {
                    var existentProd = App.prodDatabase.GetProdById(restList[k].ProdId);

                    if (existentProd != null)
                    {
                        if (restList[k].ProdId == existentProd.ProdId)
                        {
                            App.prodDatabase.EditProduct(existentProd);
                        }
                    }
                    else
                    {
                        var vProd = new ProductData()
                        {
                            ProdId = restList[k].ProdId,
                            StateChangeTime = restList[k].StateChangeTime,
                            ProdState = restList[k].ProdState,
                        };
                        App.prodDatabase.SaveProduct(vProd);
                    }
                }
            }
        }

    }
}
