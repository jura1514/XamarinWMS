using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View
{
    public partial class ManageLocation : ContentPage
    {
        public ManageLocation()
        {
            InitializeComponent();
            var vList = App.locDatabase.GetAllLoc();
            lstData.ItemsSource = vList;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            var vSelUser = (LocationData)e.SelectedItem;
            Navigation.PushAsync(new ShowLocation(vSelUser));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddLocation());
        }
    }
}
