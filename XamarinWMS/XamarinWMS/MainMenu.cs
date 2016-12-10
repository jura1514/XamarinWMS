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

        public async void CheckForOrders()
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
                        App.orderDatabase.EditOrder(allOrders[i]);
                    }
                }
            }
        }
    }
}
