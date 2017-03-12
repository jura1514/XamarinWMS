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
        public EditDeliveryLine(DeliveryLineData aSelectedDelLine, DeliveryData aSelDel)
        {
            InitializeComponent();
            mSelDelLine = aSelectedDelLine;
            mSelDel = aSelDel;
            BindingContext = mSelDelLine;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtDelId.Text) && !string.IsNullOrEmpty(txtProd.Text)
                 && !string.IsNullOrEmpty(txtAccQty.Text) && !string.IsNullOrEmpty(txtExpQty.Text) && !string.IsNullOrEmpty(txtRejQty.Text))
            {
                mSelDelLine.DeliveryId = int.Parse(txtDelId.Text);
                mSelDelLine.Name = txtName.Text;
                mSelDelLine.Product = txtProd.Text;
                mSelDelLine.AcceptedQty = int.Parse(txtAccQty.Text);
                mSelDelLine.ExpectedQty = int.Parse(txtExpQty.Text);
                mSelDelLine.RejectedQty = int.Parse(txtRejQty.Text);
                App.DelLineDatabase.EditDelLine(mSelDelLine);
                Navigation.PushAsync(new ManageDeliveryLines(mSelDel));
            }
            else
            {
                DisplayAlert("Error", "All fields are mandatory!", "OK");
            }
        }
    }
}
