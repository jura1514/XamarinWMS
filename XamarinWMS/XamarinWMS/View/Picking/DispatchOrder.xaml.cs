using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Picking
{
    public partial class DispatchOrder : ContentPage
    {
        bool alertShown = false;
        bool isConnected = false;
        bool isNewOrder = false;

        OrderData mSelOrder;

        public DispatchOrder(OrderData aSelectedOrder)
        {
            InitializeComponent();
            mSelOrder = aSelectedOrder;
            BindingContext = mSelOrder;

            //check if current network status changed
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Error", "Check for your connection.", "OK");
                isConnected = false;

            }
            else
            {
                isConnected = true;
            }

            if (Constants.RestUrlDel.Contains("192.168.0.37:52326"))
            {
                if (!alertShown)
                {
                    await DisplayAlert(
                        "Hosted Back-End",
                        "This app is running against Xamarin's read-only REST service. To create, edit, and delete Deliveries you must update the service endpoint to point to your own hosted REST service.",
                        "OK");
                    alertShown = true;
                }
            }
        }

        public void OnReturnClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new OrderDetails(mSelOrder));
        }

        public async void OnFinishClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                if (isConnected)
                {
                    if (mSelOrder.IsDispatched)
                    {
                        isNewOrder = true;
                        mSelOrder.IsDispatched = true;
                        await App.OrderManager.SaveTaskAsync(mSelOrder, isNewOrder);
                        App.orderDatabase.EditOrder(mSelOrder);
                    }
                }
                else
                {
                    mSelOrder.InQueue = true;
                }
            }
            await Navigation.PushAsync(new MainMenu());
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (!e.IsConnected)
            {
                await DisplayAlert("Error", "Check for your connection.", "OK");
                isConnected = false;
            }
            else
            {
                isConnected = true;
            }
        }
    }
}
