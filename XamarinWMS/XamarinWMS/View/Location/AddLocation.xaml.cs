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
            var vLocation = new LocationData()
            {
                LocationId = txtLocId.Text,
                LocState = txtState.Text,
                StateChangeTime = DateTime.Now,
            };
            App.locDatabase.SaveLoc(vLocation);
            Navigation.PushAsync(new ManageLocation());
        }
    }
}
