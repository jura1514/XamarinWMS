using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;
using ZXing.Net.Mobile.Forms;

namespace XamarinWMS.View.Picking
{
    public partial class NewPick : ContentPage
    {
        StockData fStock;
        int orderId;

        public NewPick(int selOrderId)
        {
            InitializeComponent();
            orderId = selOrderId;
            BindingContext = fStock;

        }

        public void OnCreateClicked(object sender, EventArgs args)
        {

        }

        public void PickCreate(StockData selStock)
        {
            var vPick = new PickData()
            {
                OrderId = orderId,
                DeliveryLineId = selStock.DeliveryLineId,
                Product = selStock.Product,
                PickState = "CREATED",
                StateChangeTime = DateTime.Now,
                Description = selStock.Description,
                ActualQty = selStock.Qty,

        };
            App.pickDatabase.SavePick(vPick);
            Navigation.PushAsync(new NewPick(orderId));
        }

        public async void OnBarcodeClicked(object sender, EventArgs e)
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
                    if (isNumerical)
                    {
                        fStock = App.StkDatabase.GetStock(foundStockid);

                        if (fStock != null)
                        {
                            PickCreate(fStock);
                        }
                        else
                        {
                            DisplayAlert("Alert", "Stock not found!", "OK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Alert", "Wrong Barcode!", "OK");
                    }
                });
            };
            await Navigation.PushAsync(scanPage);
        }
    }
}
