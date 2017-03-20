using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
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
            bool isConnected = CrossConnectivity.Current.IsConnected;

            if (isConnected)
            {
                if (!string.IsNullOrEmpty(txtState.Text))
                {
                    mSelLoc.LocState = txtState.Text;
                    mSelLoc.StateChangeTime = DateTime.Now;
                    //update locally
                    App.locDatabase.EditLoc(mSelLoc);
                    //update on a server
                    App.LocManager.SaveTaskAsync(mSelLoc, false);

                    Navigation.PushAsync(new ManageLocation());
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
