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
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                if (!string.IsNullOrEmpty(txtState.Text))
                {
                    mSelProd.ProdState = txtState.Text;
                    mSelProd.StateChangeTime = DateTime.Now;

                    App.prodDatabase.EditProduct(mSelProd);
                    App.ProdManager.SaveTaskAsync(mSelProd, false);

                    Navigation.PushAsync(new ManageProduct());
                }
                else
                {
                    DisplayAlert("Error", "Enter State", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Cannot update a record without connection!", "OK");

            }
        }
    }
}
