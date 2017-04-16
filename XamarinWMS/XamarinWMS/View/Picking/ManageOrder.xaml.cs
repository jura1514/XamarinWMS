using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWMS.Model;

namespace XamarinWMS.View.Picking
{
    public partial class ManageOrder : ContentPage
    {
        public ManageOrder()
        {
            InitializeComponent();
            var vList = App.orderDatabase.GetAllOrders();
            lstData.ItemsSource = vList;
                 
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelOrder = (OrderData)e.SelectedItem;
            Navigation.PushAsync(new OrderDetails(vSelOrder));
        }
        public async void OnNewOrderClicked(object sender, EventArgs args)
        {

            var page = new OrderPopUp();

            await Navigation.PushPopupAsync(page);
            // or
                    //  await PopupNavigation.PushAsync(page);


                    //var vOrder = new OrderData()
                    //{
                    //    OrderState = "CREATED",
                    //    StateChangeTime = DateTime.Now,
                    //    IsDispatched = false,
                    //    InQueue = false,
                    //};
                    //App.orderDatabase.SaveOrder(vOrder);
                    //Navigation.PushAsync(new OrderDetails(vOrder));
        }
    }
}
