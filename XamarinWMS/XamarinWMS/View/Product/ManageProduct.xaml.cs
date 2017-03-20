using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Product
{
    public partial class ManageProduct : ContentPage
    {
        public ManageProduct()
        {
            InitializeComponent();
            var vList = App.prodDatabase.GetAllProducts();
            lstData.ItemsSource = vList;
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushAsync(new Other());
            return true;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelUser = (ProductData)e.SelectedItem;
            Navigation.PushAsync(new ShowProduct(vSelUser));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddProduct());
        }
    }
}
