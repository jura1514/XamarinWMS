using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Login
{
    public partial class Login : ContentPage
    {
        private string _accessToken = "";

        //check if phone has access to network
        bool isConnected = false;

        public Login()
        {
            InitializeComponent();
            _accessToken = "";

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return true;
        }

        public void OnLoginClicked(object sender, EventArgs e)
        {
            ProcessLogin(email.Text, password.Text);
        }

        public void OnRegisterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Signup());
        }

        public async void ProcessLogin(string username, string password)
        {
            if (isConnected)
            {
                _accessToken = await App.UserManager.LoginTaskAsync(username, password);

                if (!string.IsNullOrEmpty(_accessToken))
                {
                    await DisplayAlert("Success", "Login complete", "OK");
                    await Navigation.PushAsync(new MainMenu());
                }
                else
                {
                    await DisplayAlert("Error", "Login failed", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Cannot login without connection!", "OK");
            }
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (!e.IsConnected)
            {
                await DisplayAlert("Error", "Check for your connection.", "OK");
                isConnected = false;
            }
            else
            {
                isConnected = true;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Error", "Check for your connection.", "OK");
                isConnected = false;
            }
            else
            {
                isConnected = true;
            }
        }
    }
}
