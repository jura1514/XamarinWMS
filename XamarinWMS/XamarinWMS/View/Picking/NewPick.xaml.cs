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
        OrderData mOrder;

        public NewPick(OrderData selOrder, StockData selStock)
        {
            InitializeComponent();
            mOrder = selOrder;
            fStock = selStock;
            BindingContext = fStock;

        }

        public void OnCreateClicked(object sender, EventArgs args)
        {
            int pickQty;
            int plannedQty;
            bool isNumerical = int.TryParse(txtPickQty.Text, out pickQty);
            bool isPlannedNumerical = int.TryParse(txtPlannedQty.Text, out plannedQty);

            if (isNumerical && isPlannedNumerical)
            {
                if (fStock != null)
                {
                    if(pickQty <= fStock.Qty)
                    {
                        PickCreate(fStock);
                    }
                    else
                    {
                        DisplayAlert("Alert", "Pick Quantity Can't be Higher than Selected Stock Quantity", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Alert", "Please scan Stock barcode!", "OK");
                }
            }
            else
            {
                DisplayAlert("Alert", "Please enter a valid quantity for pick!", "OK");
            }
        }

        public void PickCreate(StockData selStock)
        {
            var vPick = new PickData()
            {
                OrderId = mOrder.OrderId,
                DeliveryLineId = selStock.DeliveryLineId,
                Product = selStock.Product,
                PickState = "CREATED",
                StateChangeTime = DateTime.Now,
                Description = txtDesc.Text,
                ActualQty = int.Parse(txtPickQty.Text),
                PlannedQty = int.Parse(txtPlannedQty.Text),
            };
            App.pickDatabase.SavePick(vPick);
            Navigation.PushAsync(new OrderDetails(mOrder));
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
                            Navigation.PushAsync(new NewPick(mOrder, fStock));
                            DisplayAlert("Stock found:", result.Text, "OK");                           
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
