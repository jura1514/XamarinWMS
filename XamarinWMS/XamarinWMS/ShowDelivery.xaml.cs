using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Models;

namespace XamarinWMS
{
    public partial class ShowDelivery : ContentPage
    {
        DeliveryData mSelDelivery;
        public ShowDelivery(DeliveryData aSelectedDel)
        {
            InitializeComponent();
            mSelDelivery = aSelectedDel;
            BindingContext = mSelDelivery;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditDelivery(mSelDelivery));
        }

        public void OnShowClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ManageDeliveryLines(mSelDelivery));
        }

        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                App.DelDatabase.DeleteDelivery(mSelDelivery);
            }
            await Navigation.PushAsync(new ManageDelivery());
        }
    }
}
