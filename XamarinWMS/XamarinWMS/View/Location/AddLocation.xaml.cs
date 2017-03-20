using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View
{
    public partial class AddLocation : ContentPage
    {
        public AddLocation()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                if (!string.IsNullOrEmpty(txtLocId.Text) && !string.IsNullOrEmpty(txtState.Text))
                {
                    LocationData existentLoc = App.locDatabase.GetLocationById(txtLocId.Text);

                    if (existentLoc == null)
                    {
                        var vLocation = new LocationData()
                        {
                            LocationId = txtLocId.Text,
                            LocState = txtState.Text,
                            StateChangeTime = DateTime.Now,
                        };
                       // App.locDatabase.SaveLoc(vLocation);
                        App.LocManager.SaveTaskAsync(vLocation,true);
                        Navigation.PushAsync(new MainMenu());
                    }
                    else
                    {
                        DisplayAlert("Error", "Product already exist in database", "OK");
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
