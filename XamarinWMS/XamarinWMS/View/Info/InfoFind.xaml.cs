﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinWMS.Model;
using ZXing.Net.Mobile.Forms;

namespace XamarinWMS.View.Info
{
    public partial class InfoFind : ContentPage
    {
        public InfoFind()
        {
            InitializeComponent();
        }

        public void OnStockInfoClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "This feature is coming soon!", "OK");
        }

        public void OnLocationInfoClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "This feature is coming soon!", "OK");
        }

        public async void OnInfoBarcodeClicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                    //so it can be a loc id or stock id 
                    int foundStockid;
                    bool isNumerical = int.TryParse(result.Text, out foundStockid);
                    //if true that mean it stock
                    if(isNumerical)
                    {
                        StockData fStock = App.StkDatabase.GetStock(foundStockid);
                        Navigation.PushAsync(new InfoStockDisplay(fStock));

                    }
                    else
                    {
                        List<StockData> fStock = App.StkDatabase.GetAllStockFromLocation(result.Text);
                        LocationData fLoc = App.locDatabase.GetLocationById(result.Text);
                        Navigation.PushAsync(new InfoLocationDisplay());
                    }
                });
            };
            await Navigation.PushAsync(scanPage);
        }

        public void OnInfoNfcClicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "This feature is coming soon!", "OK");
        }
    }
}