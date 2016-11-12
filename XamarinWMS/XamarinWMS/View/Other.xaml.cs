using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.View.Product;
using XamarinWMS.View.Stock;

namespace XamarinWMS.View
{
    public partial class Other : ContentPage
    {
        public Other()
        {
            InitializeComponent();
        }

        public void OnManageStockClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageStock());
        }
        public void OnManageLocationClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageLocation());
        }

        public void OnManageProductClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManageProduct());
        }
    }
}
