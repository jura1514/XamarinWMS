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
        StockData fStock = null;

        public OrderDetails( OrderData selectedOrder )
        {
            InitializeComponent();
            mOrder = selectedOrder;
            BindingContext = mOrder;

            if (mOrder != null)
            {
                var vList = App.pickDatabase.GetAllPicksForOrder(mOrder.OrderId);
                lstData.ItemsSource = vList;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new ManageOrder());
            return true;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelPick = (PickData)e.SelectedItem;
            Navigation.PushAsync(new ShowPick(vSelPick, mOrder));
        }

        public void OnNewPickClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new NewPick(mOrder, fStock));
        }

        public void OnDispatchClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new DispatchOrder(mOrder));
        }
    }
}
