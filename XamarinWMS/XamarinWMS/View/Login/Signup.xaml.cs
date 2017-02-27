using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using XamarinWMS.Model;

namespace XamarinWMS.View.Login
{
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }

        public void OnSignUpClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(email.Text) && !string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(confPassword.Text))
            {
                if (password.Text != confPassword.Text)
                {
                    DisplayAlert("Error", "Passwords do not match!", "OK");
                }
                else
                {
                    SignUp(email.Text, password.Text, confPassword.Text);
                }
            }
            else
            {
                DisplayAlert("Error", "All fields are mandatory!", "OK");
            }
        }

        public async void SignUp(string username, string password, string confPassword)
        {
            var vUser = new UserData()
            {
                Email = username,
                Password = password,
                ConfirmPassword = confPassword,
            };

            bool CanCreate = false;
            List<UserData> _users = App.UserDatabase.GetAllUsers();

            for (int i = 0; i < _users.Count(); i++)
            {
                if (_users[i].Email != vUser.Email)
                {
                    CanCreate = true;
                }
                else
                {
                    await DisplayAlert("Error", "Register Failed!", "OK");
                }
            }

            //use this if you want to create users in local db
            if(CanCreate)
            {
                //App.UserDatabase.SaveUser(vUser);
            }

            bool succ = await App.UserManager.SaveTaskAsync( vUser, true );

            if (!succ)
            {
                await DisplayAlert("Error", "Register Failed!", "OK");
            }
            else
            {
                await DisplayAlert("Success", "User Regitered", "OK");
                await Navigation.PushAsync(new Login());
            }
        }

    }
}
