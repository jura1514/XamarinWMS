using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Stock
{
    public partial class ManageStock : ContentPage
    {
        public ManageStock()
        {
            InitializeComponent();
            var vList = App.StkDatabase.GetAllStock();
            lstData.ItemsSource = vList;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelUser = (StockData)e.SelectedItem;
            Navigation.PushAsync(new ShowStock(vSelUser));
        }
        public void OnBackClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new Other());
        }
    }
}
