using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWMS
{
    class MainMenu : ContentPage
    {
        public MainMenu()
        {
            Title = "Main Menu";
            var rootLabel = new Label { Text = "XamarinWMS" };
            var pageLabel = new Label { Text = "new page Hello!" };
            var buttonInfo = new Button
            {
                Text = "Info"
            };
            //buttonInfo.Clicked += OnNextPageButtonClicked;
            var buttonReceive = new Button
            {
                Text = "Receive"
            };
            var buttonStockMove = new Button
            {
                Text = "Move"
            };
            var buttonPickAndDispatch = new Button
            {
                Text = "Picking"
            };
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = { rootLabel, buttonReceive, buttonStockMove, buttonPickAndDispatch, buttonInfo }
            };
            var newPage = new ContentPage
            {
                Content = pageLabel
            };
            var database = new RandomThoughtDatabase();

            buttonReceive.Clicked += (sender, args) => Navigation.PushAsync(new DeliveryTable(database));
            buttonStockMove.Clicked += (sender, args) => Navigation.PushAsync(newPage);
            buttonPickAndDispatch.Clicked += (sender, args) => Navigation.PushAsync(newPage);
            buttonInfo.Clicked += (sender, args) => Navigation.PushAsync(new PageInfo());

        }
        //async void OnNextPageButtonClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new PageInfo());
        //}
    }
}
