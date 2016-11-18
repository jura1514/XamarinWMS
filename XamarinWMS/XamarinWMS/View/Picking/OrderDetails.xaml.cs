using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Picking
{
    public partial class OrderDetails : ContentPage
    {
        OrderData mOrder;

        public OrderDetails( OrderData selectedOrder )
        {
            InitializeComponent();
            mOrder = selectedOrder;
            BindingContext = mOrder;

            if (mOrder != null)
            {
                var vList = App.pickDatabase.GetAllPicksForOrder(mOrder.OrderId);
            }
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
           // var vSelStock = (StockData)e.SelectedItem;
            Navigation.PushAsync(new ManageOrder());
        }

        public void OnNewPickClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NewPick(mOrder.OrderId));
        }

        public void OnBarcodeClicked(object sender, EventArgs args)
        {

        }
    }
}
