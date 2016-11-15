using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;
using ZXing.Net.Mobile.Forms;

namespace XamarinWMS.View.Move
{
    public partial class MoveWhere : ContentPage
    {
        StockData mFoundStock;
        List<LocationData> Locations;
        string LocationId;

        public MoveWhere(StockData aFoundStock)
        {
            InitializeComponent();
            mFoundStock = aFoundStock;
            Locations = App.locDatabase.GetAllLoc();

            for (int i = 0; i < Locations.Count; i++)
            {
                LocationPicker.Items.Add(Locations[i].LocationId);

            }
            LocationPicker.SelectedIndexChanged += (sender, args) =>
            {
                if (LocationPicker.SelectedIndex == -1)
                {
                    string defaultValue = "Click to select";
                    defaultValue = LocationPicker.Items[LocationPicker.SelectedIndex];
                }
                else
                {
                    LocationId = LocationPicker.Items[LocationPicker.SelectedIndex];
                }
            };
        }

        public void OnMoveClicked(object sender, EventArgs e)
        {
           DisplayAlert("Alert", "Stock Id should be a Numeric!", "OK");

        }

        public async void OnMoveBarcodeClicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();

                    DisplayAlert("Stock Found: ", result.Text, "OK");
                });
            };
            await Navigation.PushAsync(scanPage);
        }
    }
}
