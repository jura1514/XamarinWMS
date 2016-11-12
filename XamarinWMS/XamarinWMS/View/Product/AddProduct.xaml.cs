using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Product
{
    public partial class AddProduct : ContentPage
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            var vProduct = new ProductData()
            {
                ProdId = txtProdId.Text,
                ProdState = txtState.Text,
                StateChangeTime = DateTime.Now,
            };
            App.prodDatabase.SaveProduct(vProduct);
            Navigation.PushAsync(new ManageProduct());
        }
    }
}
