using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Picking
{
    public partial class DispatchOrder : ContentPage
    {
        OrderData mSelOrder;
        public DispatchOrder(OrderData aSelectedOrder)
        {
            InitializeComponent();
            mSelOrder = aSelectedOrder;
            BindingContext = mSelOrder;
        }

        public void OnReturnClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new OrderDetails(mSelOrder));
        }

        public async void OnFinishClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                await App.OrderManager.SaveTaskAsync(mSelOrder);

                //App.orderDatabase.DeleteOrder(mSelOrder);
            }
            await Navigation.PushAsync(new MainMenu());
        }
    }
}
