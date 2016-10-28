using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Models;

namespace XamarinWMS
{
    public partial class EditDelivery : ContentPage
    {
        DeliveryData mSelDelivery;
        public EditDelivery(DeliveryData aSelectedDel)
        {
            InitializeComponent();
            mSelDelivery = aSelectedDel;
            BindingContext = mSelDelivery;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            mSelDelivery.DeliveryId = int.Parse(txtDelId.Text);
            mSelDelivery.Name = txtName.Text;
            mSelDelivery.Status = txtStatus.Text;
            mSelDelivery.ExpectedDate = DateTime.Now;/*DateTime.Parse(txtExpDate.Text);*/
            mSelDelivery.StatusChangeTime = DateTime.Now;/*DateTime.Parse(txtChangeTime.Text);*/
            App.DelDatabase.EditDelivery(mSelDelivery);
            Navigation.PushAsync(new ManageDelivery());
        }
    }
}
