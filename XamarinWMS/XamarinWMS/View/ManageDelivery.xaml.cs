using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS
{
    public partial class ManageDelivery : ContentPage
    {
        bool isConnected = false;

        public ManageDelivery()
        {
            InitializeComponent();

            if (!isConnected)
            {
                var vList = App.DelDatabase.GetAllDeliveries();
                lstData.ItemsSource = vList;
            }

            //check if current network status changed
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new MainMenu());
            return true;
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

            if (!Constants.RestUrlDel.Contains("mywebwms.azurewebsites.net"))
            {
                await DisplayAlert(
                    "Hosted Back-End",
                    "This app is running against Xamarin's read-only REST service. To create, edit, and delete Deliveries you must update the service endpoint to point to your own hosted REST service.",
                    "OK");
            }

            if( isConnected )
            {
                lstData.ItemsSource = await App.DelManager.GetTasksAsync();

                CreateOrUpdateDeliveries();
                CreateOrUpdateDelLines();
            }
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelUser = (DeliveryData)e.SelectedItem;
            Navigation.PushAsync(new ShowDelivery(vSelUser));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddDelivery());
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

        public async void CreateOrUpdateDeliveries()
        {
            var restList = await App.DelManager.GetTasksAsync();
            
            bool isEmpty = !restList.Any();
            if (!isEmpty)
            {
               for( int k = 0; k < restList.Count(); k++ )
               {
                    var existentDel = App.DelDatabase.GetDeliveryById(restList[k].DeliveryId);

                    if (existentDel != null)
                    {
                        if (restList[k].DeliveryId == existentDel.DeliveryId)
                        {
                            App.DelDatabase.EditDelivery(existentDel);
                        }
                    }
                    else
                    {
                        var vDelivery = new DeliveryData()
                        {
                            DeliveryId = restList[k].DeliveryId,
                            Name = restList[k].Name,
                            State = restList[k].State,
                            ExpectedDate = restList[k].ExpectedDate,
                            StateChangeTime = restList[k].StateChangeTime,
                            Customer = restList[k].Customer,
                        };
                        App.DelDatabase.SaveDelivery(vDelivery);
                    }
                    
                }
            }
        }

        public async void CreateOrUpdateDelLines()
        {
            var restList = await App.DelLineManager.GetTasksAsync();

            bool isEmpty = !restList.Any();
            if (!isEmpty)
            {
                for (int k = 0; k < restList.Count(); k++)
                {
                    var existentDelLine = App.DelLineDatabase.GetDeliveryLine(restList[k].DeliveryLineId);

                    if (existentDelLine != null)
                    {
                        if (restList[k].DeliveryLineId == existentDelLine.DeliveryLineId)
                        {
                            App.DelLineDatabase.EditDelLine(existentDelLine);
                        }
                    }
                    else
                    {
                        var vDeliveryLine = new DeliveryLineData()
                        {
                            DeliveryLineId = restList[k].DeliveryLineId,
                            DeliveryId = restList[k].DeliveryId,
                            Name = restList[k].Name,
                            Product = restList[k].Product,
                            AcceptedQty = restList[k].AcceptedQty,
                            ExpectedQty = restList[k].ExpectedQty,
                            RejectedQty = restList[k].RejectedQty,
                            isUsedForStock = false
                        };
                        App.DelLineDatabase.SaveDelLine(vDeliveryLine);
                    }

                }
            }
        }
    }
}
