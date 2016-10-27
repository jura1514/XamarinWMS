using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Models;

namespace XamarinWMS
{
    public partial class ManageDeliveryLines : ContentPage
    {

        public ManageDeliveryLines(DeliveryData aSelectedDel)
        {
            InitializeComponent();
            var vList = App.DelLineDatabase.GetAllDelLinesForDelID(aSelectedDel);
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
            var vSelUser = (DeliveryLineData)e.SelectedItem;
            Navigation.PushAsync(new ShowDeliveryLine(vSelUser));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddDeliveryLine());
        }
    }
}
