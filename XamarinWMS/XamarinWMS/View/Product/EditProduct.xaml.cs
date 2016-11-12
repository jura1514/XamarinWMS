using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Product
{
    public partial class EditProduct : ContentPage
    {
        ProductData mSelProd;
        public EditProduct(ProductData aSelectedProd)
        {
            InitializeComponent();
            mSelProd = aSelectedProd;
            BindingContext = mSelProd;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            mSelProd.ProdId = txtProdId.Text;
            mSelProd.ProdState = txtState.Text;
            mSelProd.StateChangeTime = DateTime.Now;
            App.prodDatabase.EditProduct(mSelProd);
            Navigation.PushAsync(new ManageProduct());
        }
    }
}
