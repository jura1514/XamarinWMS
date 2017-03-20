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
    public partial class EditDelivery : ContentPage
    {
        DeliveryData mSelDelivery;
        public EditDelivery(DeliveryData aSelectedDel)
        {
            InitializeComponent();
            mSelDelivery = aSelectedDel;
            BindingContext = mSelDelivery;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtState.Text) && !string.IsNullOrEmpty(txtCustomer.Text))
                {
                    mSelDelivery.Name = txtName.Text;
                    mSelDelivery.Customer = txtCustomer.Text;
                    mSelDelivery.State = txtState.Text;
                    mSelDelivery.ExpectedDate = datePicker.Date.Date;
                    mSelDelivery.StateChangeTime = DateTime.Now;
                    //update locally
                    App.DelDatabase.EditDelivery(mSelDelivery);
                    //update on a server
                    App.DelManager.SaveTaskAsync(mSelDelivery,false);

                    Navigation.PushAsync(new ManageDelivery());
                }
                else
                {
                    DisplayAlert("Error", "All fields are mandatory!", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Cannot update a record without connection!", "OK");

            }
        }
    }
}
