using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View
{
    public partial class EditLocation : ContentPage
    {
        LocationData mSelLoc;
        public EditLocation(LocationData aSelectedLoc)
        {
            InitializeComponent();
            mSelLoc = aSelectedLoc;
            BindingContext = mSelLoc;
        }

        public void OnSaveClicked(object sender, EventArgs args)
        {
            mSelLoc.LocationId = txtLocId.Text;
            mSelLoc.LocState = txtState.Text;
            mSelLoc.StateChangeTime = DateTime.Now;
            App.locDatabase.EditLoc(mSelLoc);
            Navigation.PushAsync(new ManageLocation());
        }
    }
}
