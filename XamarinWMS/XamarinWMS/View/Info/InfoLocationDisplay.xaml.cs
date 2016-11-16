using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Info
{
    public partial class InfoLocationDisplay : ContentPage
    {
        LocationData mSelLoc;
        List<StockData> fStock;

        public InfoLocationDisplay(LocationData fLoc)
        {
            InitializeComponent();
            mSelLoc = fLoc;
            BindingContext = mSelLoc;

            fStock = App.StkDatabase.GetAllStockFromLocation(fLoc.LocationId);

            if (fStock != null)
            {
                lstData.ItemsSource = fStock;
            }
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelStock = (StockData)e.SelectedItem;
            Navigation.PushAsync(new InfoStockDisplay(vSelStock));
        }
        public void OnBackClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new InfoFind());
        }
    }
}
