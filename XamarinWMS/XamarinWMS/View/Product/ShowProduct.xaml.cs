using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Product
{
    public partial class ShowProduct : ContentPage
    {
        ProductData mSelProd;
        public ShowProduct(ProductData aSelectedProd)
        {
            InitializeComponent();
            mSelProd = aSelectedProd;
            BindingContext = mSelProd;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditProduct(mSelProd));
        }

        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                App.prodDatabase.DeleteProduct(mSelProd);
            }
            await Navigation.PushAsync(new ManageProduct());
        }
    }
}
