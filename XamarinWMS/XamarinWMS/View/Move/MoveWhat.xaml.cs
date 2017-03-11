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
    public partial class MoveWhat : ContentPage
    {
        public MoveWhat()
        {
            InitializeComponent();
        }

        public void OnMoveClicked(object sender, EventArgs e)
        {
            int validEntry;
            bool isNumeric = int.TryParse(txtEntry.Text, out validEntry);

            if(isNumeric)
            {
                StockData foundStock = App.StkDatabase.GetStock(validEntry);
                if (foundStock != null)
                {
                    if ((foundStock.StockId != 0) &&
                                        foundStock.StockId > 0)
                    {
                        DisplayAlert("Stock Found: ", foundStock.StockId.ToString(), "OK");
                        Navigation.PushAsync(new MoveWhere(foundStock));
                    }
                    else
                    {
                        DisplayAlert("Alert", "Could not find a Stock", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Alert", "Could not find a Stock!", "OK");
                }
            }
            else
            {
                DisplayAlert("Alert", "Stock Id should be a Numeric!", "OK");
            }

        }

        public async void OnMoveBarcodeClicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();

                    int resultId;
                    bool isNumeric = int.TryParse(result.Text, out resultId);

                    if (isNumeric)
                    {
                        StockData foundStock = App.StkDatabase.GetStock(resultId);
                        if (foundStock != null)
                        {
                            if ((foundStock.StockId != 0) &&
                                foundStock.StockId > 0)
                            {
                                DisplayAlert("Stock Found: ", result.Text, "OK");
                                Navigation.PushAsync(new MoveWhere(foundStock));
                            }
                            else
                            {
                                DisplayAlert("Alert", "Could not find a Stock", "OK");
                            }
                        }
                        else
                        {
                            DisplayAlert("Alert", "Could not find a Stock!", "OK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Alert", "Stock Id should be a Numeric!", "OK");
                    }

                });
            };
            await Navigation.PushAsync(scanPage);
        }

        public void OnMoveNfcClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "This feature is coming soon!", "OK");
        }
    }
}
