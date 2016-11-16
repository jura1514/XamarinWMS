using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Info
{
    public partial class InfoStockDisplay : ContentPage
    {
        StockData mSelStock;
        public InfoStockDisplay(StockData aSelectedStock)
        {
            InitializeComponent();
            mSelStock = aSelectedStock;
            BindingContext = mSelStock;
        }

        public void OnBackClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new InfoFind());
        }

        public void OnMainMenuClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MainMenu());
        }
    }
}
