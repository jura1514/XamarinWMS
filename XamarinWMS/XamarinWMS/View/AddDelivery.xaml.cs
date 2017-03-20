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
    public partial class AddDelivery : ContentPage
    {
        public AddDelivery()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                if (!string.IsNullOrEmpty(txtDelId.Text) && !string.IsNullOrEmpty(txtName.Text)
                    && !string.IsNullOrEmpty(txtCustomer.Text) )
                {
                    DeliveryData existantDel = App.DelDatabase.GetDeliveryById(int.Parse(txtDelId.Text));

                    if (existantDel == null)
                    {
                        var vDelivery = new DeliveryData()
                        {
                            DeliveryId = int.Parse(txtDelId.Text),
                            Name = txtName.Text,
                            Customer = txtCustomer.Text,
                            State = txtState.Text,
                            ExpectedDate = DateTime.Now,
                            StateChangeTime = DateTime.Now,
                        };
                        //create locally
                       // App.DelDatabase.SaveDelivery(vDelivery);
                        //create on a server
                        App.DelManager.SaveTaskAsync(vDelivery, true);

                        Navigation.PushAsync(new ManageDelivery());
                    }
                    else
                    {
                        DisplayAlert("Error", "Delivery already exist in database", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "All fields are mandatory!", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Cannot create a record without connection!", "OK");

            }
        }
    }
}
