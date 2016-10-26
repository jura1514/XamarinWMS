using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWMS
{
    public class DeliveryEntryPage : ContentPage
    {
        private DeliveryTable _parent;
        private DeliveryDatabase _database;

        public DeliveryEntryPage(DeliveryTable parent, DeliveryDatabase database)
        {
            var labelId = new Label
            {
                Text = "Deliver Id",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            var labelName = new Label
            {
                Text = "Name",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            var labelStatus = new Label
            {
                Text = "Status",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            _parent = parent;
            _database = database;
            Title = "Enter a Delivery Details";

            var entryId = new Entry()
            {
                Keyboard = Keyboard.Numeric
            };
            var entry = new Entry();
            var entryStatus = new Entry();

            var button = new Button
            {
                Text = "Add"
            };

            button.Clicked += async (object sender, EventArgs e) => {
                var id = int.Parse(entryId.Text);
                var name = entry.Text;
                var status = entryStatus.Text;

                _database.AddDelivery(id, name, status);

                await Navigation.PopAsync();

                _parent.Refresh();
            };

            Content = new StackLayout
            {
                Spacing = 20,
                Padding = new Thickness(20),
                Children = { labelId, entryId, labelName, entry, labelStatus, entryStatus, button },
            };
        }
    }
}
