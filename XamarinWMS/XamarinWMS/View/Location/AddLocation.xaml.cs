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
                    App.locDatabase.SaveLoc(vLocation);
                    Navigation.PushAsync(new ManageLocation());
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
    }
}
