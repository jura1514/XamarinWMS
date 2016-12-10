using Plugin.Connectivity;
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

        public ManageDeliveryLines(DeliveryData aSelectedDel)
        {
            InitializeComponent();

            var vList = App.DelLineDatabase.GetAllDelLinesForDelID(aSelectedDel);
            lstData.ItemsSource = vList;
            
            dData = aSelectedDel;

        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
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
