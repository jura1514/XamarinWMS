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
        private RandomThoughtDatabase _database;
        private ListView _thoughtList;

        public DeliveryTable(RandomThoughtDatabase database)
        {
            _database = database;
            Title = "Random Thoughts";
            var thoughts = _database.GetThoughts();

            _thoughtList = new ListView();
            _thoughtList.ItemsSource = thoughts;
            _thoughtList.ItemTemplate = new DataTemplate(typeof(TextCell));
            _thoughtList.ItemTemplate.SetBinding(TextCell.TextProperty, "Thought");
            _thoughtList.ItemTemplate.SetBinding(TextCell.DetailProperty, "CreatedOn");

            var toolbarItem = new ToolbarItem
            {
                Text = "Add",
                Command = new Command(() => Navigation.PushAsync(new ThoughtEntryPage(this, database)))
            };

            ToolbarItems.Add(toolbarItem);

            Content = _thoughtList;
        }

        public void Refresh()
        {
            _thoughtList.ItemsSource = _database.GetThoughts();
        }
    }
}
