using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS
{
    public partial class AddDeliveryLine : ContentPage
    {
        DeliveryData dData;
        public AddDeliveryLine(DeliveryData dSelectedData)
        {
            InitializeComponent();
            dData = dSelectedData;
        }
        public void OnSaveClicked(object sender, EventArgs args)
        {
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                if (!string.IsNullOrEmpty(txtDelLineId.Text) && !string.IsNullOrEmpty(txtAccQty.Text) && !string.IsNullOrEmpty(txtExpQty.Text)
                && !string.IsNullOrEmpty(txtRejQty.Text) && !string.IsNullOrEmpty(txtProd.Text) && !string.IsNullOrEmpty(txtName.Text))
                {
                    DeliveryLineData existantDelLine = App.DelLineDatabase.GetDeliveryLine(int.Parse(txtDelLineId.Text));

                    if (existantDelLine == null)
                    {
                        var vDeliveryLine = new DeliveryLineData()
                        {
                            DeliveryLineId = int.Parse(txtDelLineId.Text),
                            DeliveryId = dData.DeliveryId,
                            Name = txtName.Text,
                            Product = txtProd.Text,
                            AcceptedQty = int.Parse(txtAccQty.Text),
                            ExpectedQty = int.Parse(txtExpQty.Text),
                            RejectedQty = int.Parse(txtRejQty.Text),
                            isUsedForStock = false
                        };
                        //create locally
                       // App.DelLineDatabase.SaveDelLine(vDeliveryLine);
                        //create on a server
                        App.DelLineManager.SaveTaskAsync(vDeliveryLine, true);
                        Navigation.PushAsync(new ManageDeliveryLines(dData));
                    }
                    else
                    {
                        DisplayAlert("Error", "Delivery Line already exist in database!", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "All fields are mandatory!", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Cannot create a record without connection!", "OK");

            }
        }
    }
}
