using Plugin.Connectivity;
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
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                if (!string.IsNullOrEmpty(txtProdId.Text) && !string.IsNullOrEmpty(txtState.Text))
                {
                    ProductData existentProd = App.prodDatabase.GetProdById(txtProdId.Text);

                    if (existentProd == null)
                    {
                        var vProduct = new ProductData()
                        {
                            ProdId = txtProdId.Text,
                            ProdState = txtState.Text,
                            StateChangeTime = DateTime.Now,
                        };
                       // App.prodDatabase.SaveProduct(vProduct);
                        App.ProdManager.SaveTaskAsync(vProduct, true);
                        Navigation.PushAsync(new MainMenu());
                    }
                    else
                    {
                        DisplayAlert("Error", "Product already exist in database", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Error", "All fields are mandatory!", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Cannot create a record without connection!", "OK");

            }
        }
    }
}
