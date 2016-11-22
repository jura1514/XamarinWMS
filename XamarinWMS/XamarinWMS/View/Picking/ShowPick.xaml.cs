using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Picking
{
    public partial class ShowPick : ContentPage
    {
        PickData mSelPick;
        OrderData mSelOrder;
        public ShowPick(PickData aSelectedPick, OrderData selectedOrder)
        {
            InitializeComponent();
            mSelPick = aSelectedPick;
            mSelOrder = selectedOrder;
            BindingContext = mSelPick;
        }

        public void OnReturnClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new OrderDetails(mSelOrder));
        }

        public async void OnUnpickClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                App.pickDatabase.DeletePick(mSelPick);
            }
            await Navigation.PushAsync(new OrderDetails(mSelOrder));
        }
    }
}
