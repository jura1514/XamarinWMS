using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View
{
    public partial class ShowLocation : ContentPage
    {
        LocationData mSelLoc;
        public ShowLocation(LocationData aSelectedLoc)
        {
            InitializeComponent();
            mSelLoc = aSelectedLoc;
            BindingContext = mSelLoc;
        }

        public void OnEditClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new EditLocation(mSelLoc));
        }

        public async void OnDeleteClicked(object sender, EventArgs args)
        {
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");
            if (accepted)
            {
                App.locDatabase.DeleteLoc(mSelLoc);
            }
            await Navigation.PushAsync(new ManageLocation());
        }
    }
}
