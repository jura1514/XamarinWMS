using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS
{
    public partial class EditDeliveryLine : ContentPage
    {
        DeliveryLineData mSelDelLine;
        DeliveryData mSelDel;
        List<ProductData> Products;
        string ProdId;

        public EditDeliveryLine(DeliveryLineData aSelectedDelLine, DeliveryData aSelDel)
        {
            InitializeComponent();
            mSelDelLine = aSelectedDelLine;
            mSelDel = aSelDel;
            BindingContext = mSelDelLine;

            ProdId = mSelDelLine.Product;
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
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtDelId.Text) && !string.IsNullOrEmpty(ProdId)
                 && !string.IsNullOrEmpty(txtAccQty.Text) && !string.IsNullOrEmpty(txtExpQty.Text) && !string.IsNullOrEmpty(txtRejQty.Text))
                {
                    mSelDelLine.DeliveryId = int.Parse(txtDelId.Text);
                    mSelDelLine.Name = txtName.Text;
                    mSelDelLine.Product = ProdId;
                    mSelDelLine.AcceptedQty = int.Parse(txtAccQty.Text);
                    mSelDelLine.ExpectedQty = int.Parse(txtExpQty.Text);
                    mSelDelLine.RejectedQty = int.Parse(txtRejQty.Text);
                    //update in local db
                    App.DelLineDatabase.EditDelLine(mSelDelLine);
                    //update on a server
                    App.DelLineManager.SaveTaskAsync(mSelDelLine, false);

                    Navigation.PushAsync(new ManageDeliveryLines(mSelDel));
                }
                else
                {
                    DisplayAlert("Error", "All fields are mandatory!", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Cannot update a record without connection!", "OK");

            }
        }
    }
}
