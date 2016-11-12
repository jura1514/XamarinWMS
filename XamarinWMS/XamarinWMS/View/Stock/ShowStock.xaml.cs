using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Stock
{
    public partial class ShowStock : ContentPage
    {
        StockData mSelStock;
        public ShowStock(StockData aSelectedStock)
        {
            InitializeComponent();
            mSelStock = aSelectedStock;
            BindingContext = mSelStock;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditStock(mSelStock));
        }

        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                App.StkDatabase.DeleteStock(mSelStock);
            }
            await Navigation.PushAsync(new ManageStock());
        }
    }
}
