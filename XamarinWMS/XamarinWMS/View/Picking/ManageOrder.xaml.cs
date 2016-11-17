using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
        public void OnNewOrderClicked(object sender, EventArgs args)
        {
            var vOrder = new OrderData()
            {
                OrderState = "CREATED",
                StateChangeTime = DateTime.Now,
            };
            App.orderDatabase.SaveOrder(vOrder);
            Navigation.PushAsync(new OrderDetails(vOrder));
        }
    }
}
