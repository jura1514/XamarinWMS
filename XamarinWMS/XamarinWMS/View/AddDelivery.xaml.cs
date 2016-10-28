using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Models;

namespace XamarinWMS
{
    public partial class AddDelivery : ContentPage
    {
        public AddDelivery()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            var vDelivery = new DeliveryData()
            {
                DeliveryId = int.Parse(txtDelId.Text),
                Name = txtName.Text,
                Status = txtStatus.Text,
                ExpectedDate = DateTime.Now,/*DateTime.Parse(txtExpDate.Text),*/
                StatusChangeTime = DateTime.Now, /*DateTime.Parse(txtChangeTime.Text)*/
            };
            App.DelDatabase.SaveDelivery(vDelivery);
            Navigation.PushAsync(new ManageDelivery());
        }
    }
}
