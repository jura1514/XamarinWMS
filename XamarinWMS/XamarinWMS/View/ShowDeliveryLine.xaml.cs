using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Models;

namespace XamarinWMS
{
    public partial class ShowDeliveryLine : ContentPage
    {
        DeliveryLineData mSelDelLine;
        DeliveryData mSelectedDel;
        public ShowDeliveryLine(DeliveryLineData aSelectedDelLine, DeliveryData aSelectedDel)
        {
            InitializeComponent();
            mSelDelLine = aSelectedDelLine;
            mSelectedDel = aSelectedDel;
            BindingContext = mSelDelLine;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditDeliveryLine(mSelDelLine, mSelectedDel));
        }

        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                App.DelLineDatabase.DeleteDelLine(mSelDelLine);
            }
            await Navigation.PushAsync(new ManageDeliveryLines(mSelectedDel));
        }
    }
}
