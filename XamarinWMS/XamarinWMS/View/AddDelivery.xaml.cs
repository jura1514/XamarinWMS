using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

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
                State = txtStatus.Text,
                ExpectedDate = DateTime.Now,/*DateTime.Parse(txtExpDate.Text),*/
                StateChangeTime = DateTime.Now, /*DateTime.Parse(txtChangeTime.Text)*/
            };
            App.DelDatabase.SaveDelivery(vDelivery);
            Navigation.PushAsync(new ManageDelivery());
        }
    }
}
