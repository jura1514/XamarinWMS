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
        List<ProductData> Products;
        string ProdId;

        List<LocationData> Locations;
        string LocId;

        public EditStock(StockData aSelectedStock)
        {
            InitializeComponent();
            mSelStock = aSelectedStock;
            BindingContext = mSelStock;

            //Prod Picker

            ProdId = mSelStock.Product;
            Products = App.prodDatabase.GetAllProducts();

            for (int i = 0; i < Products.Count; i++)
            {
                ProdPicker.Items.Add(Products[i].ProdId);

            }
            ProdPicker.SelectedIndex = ProdPicker.Items.IndexOf(ProdId);

            ProdPicker.SelectedIndexChanged += (sender, args) =>
            {
                if (ProdPicker.SelectedIndex == -1)
                {
                    string defaultValue = "Click to select";
                    defaultValue = ProdPicker.Items[ProdPicker.SelectedIndex];
                }
                else
                {
                    ProdId = ProdPicker.Items[ProdPicker.SelectedIndex];
                }
            };

            //Location Picker

            LocId = mSelStock.Location;
            Locations = App.locDatabase.GetAllLoc();

            for (int i = 0; i < Locations.Count; i++)
            {
                LocPicker.Items.Add(Locations[i].LocationId);

            }
            LocPicker.SelectedIndex = LocPicker.Items.IndexOf(LocId);

            LocPicker.SelectedIndexChanged += (sender, args) =>
            {
                if (LocPicker.SelectedIndex == -1)
                {
                    string defaultValue = "Click to select";
                    defaultValue = LocPicker.Items[LocPicker.SelectedIndex];
                }
                else
                {
                    LocId = LocPicker.Items[LocPicker.SelectedIndex];
                }
            };
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtDelLineId.Text) && !string.IsNullOrEmpty(txtState.Text)
                && !string.IsNullOrEmpty(ProdId) && !string.IsNullOrEmpty(LocId) && !string.IsNullOrEmpty(txtQty.Text))
            {
                int delLineId = int.Parse(txtDelLineId.Text);

                if (validDelLine(delLineId))
                {
                    mSelStock.Name = txtName.Text;
                    mSelStock.DeliveryLineId = delLineId;
                    mSelStock.StockState = txtState.Text;
                    mSelStock.Product = ProdId;
                    mSelStock.Location = LocId;
                    mSelStock.Qty = int.Parse(txtQty.Text);
                    mSelStock.StateChangeTime = DateTime.Now;
                    App.StkDatabase.EditStock(mSelStock);
                    Navigation.PushAsync(new ManageStock());
                }
                else
                {
                    DisplayAlert("Error", "Delivery Line with this ID does not exist!", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "All fields are mandatory!", "OK");
            }
        }

        public bool validDelLine(int delLineId)
        {
            bool foundDelLineId = false;
            var listOfDelLines = App.DelLineDatabase.GetAllDelLines();

            for (int i = 0; i < listOfDelLines.Count; i++)
            {
                if (listOfDelLines[i].DeliveryLineId == delLineId)
                {
                    foundDelLineId = true;
                    break;
                }
            }

            return foundDelLineId;
        }
    }
}
