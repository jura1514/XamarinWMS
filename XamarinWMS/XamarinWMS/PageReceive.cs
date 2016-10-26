using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWMS
{
    class PageReceive : ContentPage
    {
        public PageReceive()
        {
            Title = "Receive Page";
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "welcome to xamarin forms!"
                    }
               }
            };
        }
    }
}
