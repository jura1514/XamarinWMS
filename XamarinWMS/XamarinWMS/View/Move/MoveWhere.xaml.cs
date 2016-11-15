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
        string PickerLocationId;
        string test;

        public MoveWhere(StockData aFoundStock)
        {
            InitializeComponent();
            mFoundStock = aFoundStock;
            Locations = App.locDatabase.GetAllLoc();
            BindingContext = mFoundStock;

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
                    PickerLocationId = LocationPicker.Items[LocationPicker.SelectedIndex];
                }
            };
        }

        public void UpdateStockLocation(LocationData foundLoc)
        {
            mFoundStock.Location = foundLoc.LocationId;          
            App.StkDatabase.EditStock(mFoundStock);
            DisplayAlert("Moved to Location:", foundLoc.LocationId, "OK");
            Navigation.PushAsync(new MainMenu());
        }

        public void OnMoveClicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(PickerLocationId))
            {
                LocationData foundLoc = App.locDatabase.GetLocationById(PickerLocationId);
                if (foundLoc != null)
                {
                    UpdateStockLocation(foundLoc);
                }
                else
                {
                    DisplayAlert("Alert", "Could not find a Location!", "OK");
                }
            }
            else
            {
                DisplayAlert("Alert", "Choose a Location!", "OK");
            }
        }

        public async void OnMoveYesorNo(LocationData barcodeLocation)
        {
            var answer = await DisplayAlert("Attention!", "Would you like to move to this Location", "Yes", "No");
            if (answer.Equals(true))
            {
                UpdateStockLocation(barcodeLocation);
            }
        }

        public async void OnMoveBarcodeClicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();

                LocationData barcodeLocation = App.locDatabase.GetLocationById(result.Text);
        
                    if (barcodeLocation != null)
                    {

                        OnMoveYesorNo(barcodeLocation);
                        DisplayAlert("Found Location:", result.Text, "OK"); 

                    }
                    else
                    {
                        DisplayAlert("Alert", "Could not find a Location!", "OK");
                    }
                });
            };
            await Navigation.PushAsync(scanPage);
        }
    }
}
