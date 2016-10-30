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
        public ManageDelivery()
        {
            InitializeComponent();
            var vList = App.DelDatabase.GetAllDeliveries();
            lstData.ItemsSource = vList;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
                //ItemSelected is called on deselection, 
                //which results in SelectedItem being set to null
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
