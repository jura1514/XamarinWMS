﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace XamarinWMS
{
    class PageInfo : ContentPage
    {
        public PageInfo() : base()
        {


            Title = "Info Page";
            var button = new Button
            {

                Text = "Scan Barcode"
            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    button
               }
            };
            button.Clicked += OnScan;
        }
        async void OnScan(object sender, EventArgs e)
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
    }
}
