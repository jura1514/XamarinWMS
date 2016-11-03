using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;
using ZXing.Net.Mobile.Forms;

namespace XamarinWMS.View
{
    public partial class Tagging : ContentPage
    {
        DeliveryLineData mSelDelLine;
        public Tagging(DeliveryLineData aSelectedDelLine)
        {
            InitializeComponent();
            mSelDelLine = aSelectedDelLine;
            BindingContext = mSelDelLine;
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
                    DisplayAlert("Scanned Barcode", result.Text, "OK");

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
            DisplayAlert("Alert", "This feature is coming soon!", "OK");
        }
    }
}
