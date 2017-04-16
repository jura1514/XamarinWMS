using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;
using XamarinWMS.View;

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

        public void OnContinueClicked(object sender, EventArgs args)
        {
            int accQty = 0;
            accQty += mSelDelLine.AcceptedQty;

            int rejQty = 0;
            rejQty += mSelDelLine.RejectedQty;

            int extQty = 0;
            extQty += mSelDelLine.ExpectedQty;

            if ((accQty - rejQty) == extQty)
            {
                Navigation.PushAsync(new Tagging(mSelDelLine));
            }
            else
            {
                DisplayAlert("Error", "The acc. qty and rej. qty is not equal to expected qty!", "OK");
            }
        }

        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
                if (accepted)
                {
                    App.DelLineDatabase.DeleteDelLine(mSelDelLine);
                    await App.DelLineManager.DeleteTaskAsync(mSelDelLine);
                }
                await Navigation.PushAsync(new ManageDeliveryLines(mSelectedDel));
            }
            else
            {
                await DisplayAlert("Error", "Cannot delete a record without connection!", "OK");
            }
        }
    }
}
