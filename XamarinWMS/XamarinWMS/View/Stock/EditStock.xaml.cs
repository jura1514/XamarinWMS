using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Stock
{
    public partial class EditStock : ContentPage
    {
        StockData mSelStock;
        public EditStock(StockData aSelectedStock)
        {
            InitializeComponent();
            mSelStock = aSelectedStock;
            BindingContext = mSelStock;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtDelLineId.Text) && !string.IsNullOrEmpty(txtState.Text)
                && !string.IsNullOrEmpty(txtProduct.Text) && !string.IsNullOrEmpty(txtLocation.Text) && !string.IsNullOrEmpty(txtQty.Text))
            {
                mSelStock.Name = txtName.Text;
                mSelStock.DeliveryLineId = int.Parse(txtDelLineId.Text);
                mSelStock.StockState = txtState.Text;
                mSelStock.Product = txtProduct.Text;
                mSelStock.Location = txtLocation.Text;
                mSelStock.Qty = int.Parse(txtQty.Text);
                mSelStock.StateChangeTime = DateTime.Now;
                App.StkDatabase.EditStock(mSelStock);
                Navigation.PushAsync(new ManageStock());
            }
            else
            {
                DisplayAlert("Error", "All fields are mandatory!", "OK");
            }
        }
    }
}
