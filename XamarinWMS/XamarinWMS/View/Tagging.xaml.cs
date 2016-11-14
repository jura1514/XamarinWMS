using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWMS.Model;
using ZXing.Net.Mobile.Forms;

namespace XamarinWMS.View
{
    public partial class Tagging : ContentPage
    {
        DeliveryLineData mSelDelLine;
        List<LocationData> Locations;
        string LocationId;
        
        public Tagging(DeliveryLineData aSelectedDelLine)
        {
            Locations = App.locDatabase.GetAllLoc();
            InitializeComponent();
            mSelDelLine = aSelectedDelLine;
            BindingContext = mSelDelLine;
            
            for ( int i=0; i < Locations.Count; i++)
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

        public void CreateStock(DeliveryLineData FoundDelLine)
        {
            var vStock = new StockData()
            {
                DeliveryLineId = FoundDelLine.DeliveryLineId,
                Name = FoundDelLine.Name,
                Product = FoundDelLine.Product,
                StockState = "PENDING",
                StateChangeTime = DateTime.Now,
                Qty = FoundDelLine.ExpectedQty,
                Location = LocationId
            };
            App.StkDatabase.SaveStock(vStock);
            // update delivery line that we would not use it again
            mSelDelLine.isUsedForStock = true;
            App.DelLineDatabase.EditDelLine(mSelDelLine);
        }

        public async void OnBarcodeClicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();

                    int resultId;
                    bool isNumeric = int.TryParse(result.Text, out resultId);

                    if (isNumeric)
                    {

                        DeliveryLineData FoundDelLine = App.DelLineDatabase.GetDeliveryLine(resultId);

                        if ((FoundDelLine.DeliveryLineId != 0) &&
                                FoundDelLine.DeliveryLineId > 0)
                        {
                            if ( FoundDelLine.isUsedForStock == false )
                            {
                                CreateStock(FoundDelLine);
                                DisplayAlert("Stock Created, Scanned Barcode:", result.Text, "OK");
                                Navigation.PushAsync(new MainMenu());
                            }
                            else
                            {
                                DisplayAlert("Alert", "Stock with this delivery line id already in use", "OK");
                            }
                        }
                        else
                        {
                            DisplayAlert("Alert", "Could not find a Delivery Line", "OK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Alert", "Delivery Line should be a Numeric!", "OK");
                    }

                });
            };
            await Navigation.PushAsync(scanPage);
        }

        public void OnNfcClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "This feature is coming soon!", "OK");
        }

        public void OnTagClicked(object sender, EventArgs e)
        {
            if ( mSelDelLine.isUsedForStock == false)
            {
                CreateStock(mSelDelLine);
                DisplayAlert("Alert", "Stock Created", "OK");
                Navigation.PushAsync(new MainMenu());
            }
            else
            {
                DisplayAlert("Alert", "Stock with this delivery line id already in use", "OK");
            }
        }
    }
}
