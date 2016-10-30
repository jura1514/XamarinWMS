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
            var vDelivery = new DeliveryLineData()
            {
                DeliveryLineId = int.Parse(txtDelLineId.Text),
                DeliveryId = int.Parse(txtDelId.Text),
                Name = txtName.Text,
                AcceptedQty = int.Parse(txtAccQty.Text),
                ExpectedQty = int.Parse(txtExpQty.Text),
                RejectedQty = int.Parse(txtRejQty.Text)
            };
            App.DelLineDatabase.SaveDelLine(vDelivery);
            Navigation.PushAsync(new ManageDeliveryLines(dData));
        }
    }
}
