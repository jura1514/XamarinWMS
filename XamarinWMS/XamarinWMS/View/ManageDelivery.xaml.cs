using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS
{
    public partial class ManageDelivery : ContentPage
    {
        bool alertShown = false;

        public ManageDelivery()
        {
            InitializeComponent();
            var vList = App.DelDatabase.GetAllDeliveries();
            //lstData.ItemsSource = vList;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Constants.RestUrl.Contains("localhost"))
            {
                if (!alertShown)
                {
                    await DisplayAlert(
                        "Hosted Back-End",
                        "This app is running against Xamarin's read-only REST service. To create, edit, and delete data you must update the service endpoint to point to your own hosted REST service.",
                        "OK");
                    alertShown = true;
                }
            }

            lstData.ItemsSource = await App.DelManager.GetTasksAsync();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelUser = (DeliveryData)e.SelectedItem;
            Navigation.PushAsync(new ShowDelivery(vSelUser));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddDelivery());
        }
    }
}
