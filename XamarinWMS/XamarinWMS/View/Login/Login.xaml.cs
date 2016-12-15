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

        public Login()
        {
            InitializeComponent();
        }

        public void OnLoginClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Login());
            ProcessLogin(email.Text, password.Text);

        }

        public void OnRegisterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Signup());
        }

        public async void ProcessLogin(string username, string password)
        {
            UserData _user = App.UserDatabase.GetUserById(username);

            _accessToken = await App.UserManager.LoginTaskAsync(username, password);

            if (_accessToken != null)
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
