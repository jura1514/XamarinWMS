using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS
{
    public partial class EditDelivery : ContentPage
    {
        DeliveryData mSelDelivery;
        public EditDelivery(DeliveryData aSelectedDel)
        {
            InitializeComponent();
            mSelDelivery = aSelectedDel;
            BindingContext = mSelDelivery;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtState.Text))
            {
                //var exptDate;
                //exptDate = datePicker.Date.Date;
                //exptDate = datePicker.Date.TimeOfDay;

                mSelDelivery.Name = txtName.Text;
                mSelDelivery.State = txtState.Text;
                mSelDelivery.ExpectedDate = datePicker.Date.Date;
                mSelDelivery.StateChangeTime = DateTime.Now;
                App.DelDatabase.EditDelivery(mSelDelivery);
                Navigation.PushAsync(new ManageDelivery());
            }
            else
            {
                DisplayAlert("Error", "All fields are mandatory!", "OK");
            }
        }
    }
}
