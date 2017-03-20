using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Picking
{
    public partial class OrderPopUp : PopupPage
    {
        string action;

        public OrderPopUp()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            FrameContainer.HeightRequest = -1;

            StateButton.Scale = 0.3;
            StateButton.Opacity = 0;

            CreateButton.Scale = 0.3;
            CreateButton.Opacity = 0;

            Description.TranslationX = Description.TranslationX = -10;
            Description.Opacity = Description.Opacity = 0;
        }

        protected async override Task OnAppearingAnimationEnd()
        {
            var translateLength = 400u;

            await Task.WhenAll(
                Description.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
                Description.FadeTo(1));

            await Task.WhenAll(
                CreateButton.ScaleTo(1),
                CreateButton.FadeTo(1),
                StateButton.ScaleTo(1),
                StateButton.FadeTo(1)
                );
        }

        protected async override Task OnDisappearingAnimationBegin()
        {
            var taskSource = new TaskCompletionSource<bool>();

            var currentHeight = FrameContainer.Height;

            await Task.WhenAll(
                Description.FadeTo(0),
                CreateButton.FadeTo(0),
                StateButton.FadeTo(0)
                );

            FrameContainer.Animate("HideAnimation", d =>
            {
                FrameContainer.HeightRequest = d;
            },
            start: currentHeight,
            end: 170,
            finished: async (d, b) =>
            {
                await Task.Delay(300);
                taskSource.TrySetResult(true);
            });

            await taskSource.Task;
        }

        async void OnActionStateClicked(object sender, EventArgs e)
        {
           action = await DisplayActionSheet("State: Which one?", "Cancel", null, "URGENT", "NORMAL");
        }

        private void OnCreate(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(action) && !string.IsNullOrEmpty(Description.Text))
            {
                var vOrder = new OrderData()
                {
                    OrderState = action,
                    Description = Description.Text,
                    StateChangeTime = DateTime.Now,
                    IsDispatched = false,
                    InQueue = false,
                };
                App.orderDatabase.SaveOrder(vOrder);
                CloseAllPopup();
                Navigation.PushAsync(new OrderDetails(vOrder));
            }
            else
            {
                DisplayAlert("Error", "All fields are mandatory!", "OK");
            }
        }

        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
        }

        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();

            return false;
        }

        private async void CloseAllPopup()
        {
            await Navigation.PopAllPopupAsync();
        }
    }
}
