using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace XamarinWMS
{
    public class DeliveryTable : ContentPage{
        private DeliveryDatabase _database;
        private ListView _deliveryList;

        public DeliveryTable(DeliveryDatabase database)
        {
            _database = database;
            Title = "List of Deliveries";
            var deliveries = _database.GetDeliveries();

            _deliveryList = new ListView();
            _deliveryList.ItemsSource = deliveries;
            _deliveryList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _deliveryList.ItemTemplate.SetBinding(TextCell.TextProperty, "DeliveryId");
            _deliveryList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Name");
            _deliveryList.ItemTemplate.SetBinding(TextCell.DetailProperty, "Status");
            _deliveryList.ItemTemplate.SetBinding(TextCell.DetailProperty, "ExpectedDate");
            _deliveryList.ItemTemplate.SetBinding(TextCell.DetailProperty, "StatusChangeTime");

            var toolbarItem = new ToolbarItem
            {
                Text = "Add",
                Command = new Command(() => Navigation.PushAsync(new DeliveryEntryPage(this, database)))
            };

            ToolbarItems.Add(toolbarItem);

            Content = _deliveryList;
        }

        public void Refresh()
        {
            _deliveryList.ItemsSource = _database.GetDeliveries();
        }
    }
}
