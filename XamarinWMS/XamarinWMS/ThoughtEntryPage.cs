using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWMS
{
    public class ThoughtEntryPage : ContentPage
    {
        private DeliveryTable _parent;
        private RandomThoughtDatabase _database;

        public ThoughtEntryPage(DeliveryTable parent, RandomThoughtDatabase database)
        {
            _parent = parent;
            _database = database;
            Title = "Enter a Thought";

            var entry = new Entry();
            var button = new Button
            {
                Text = "Add"
            };

            button.Clicked += async (object sender, EventArgs e) => {
                var thought = entry.Text;

                _database.AddThought(thought);

                await Navigation.PopAsync();


                _parent.Refresh();
            };

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = new Thickness(20),
                Children = { entry, button },
            };
        }
    }
}
