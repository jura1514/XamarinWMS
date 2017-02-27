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
        //TokenResponseModel _response;

        public Login()
        {
            InitializeComponent();
            _accessToken = "";
           // _response.AccessToken = "";
           // _response = null;

            var existingPages = Navigation.NavigationStack.ToList();
            if (Navigation.NavigationStack.Count != 0)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            }
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
    }
}
