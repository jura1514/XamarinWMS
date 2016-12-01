using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS
{
    public partial class ManageDeliveryLines : ContentPage
    {
        DeliveryData dData;
        bool alertShown = false;

        public ManageDeliveryLines(DeliveryData aSelectedDel)
        {
            InitializeComponent();
            var vList = App.DelLineDatabase.GetAllDelLinesForDelID(aSelectedDel);
            lstData.ItemsSource = vList;
            dData = aSelectedDel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Constants.RestUrlDelLine.Contains("localhost"))
            {
                if (!alertShown)
                {
                    await DisplayAlert(
                        "Hosted Back-End",
                        "This app is running against Xamarin's read-only REST service. To create, edit, and delete Del Lines you must update the service endpoint to point to your own hosted REST service.",
                        "OK");
                    alertShown = true;
                }
            }

            var restList = await App.DelLineManager.GetTasksAsync();

            foreach ( var newList in restList)
            {
                await App.DelLineManager.SaveTaskAsync(newList);
            }
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
                //ItemSelected is called on deselection, 
                //which results in SelectedItem being set to null
            }
            var vSelUser = (DeliveryLineData)e.SelectedItem;
            Navigation.PushAsync(new ShowDeliveryLine(vSelUser, dData));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddDeliveryLine(dData));
        }
    }
}
