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
            //Navigation.PushAsync(new Login());
            SignUp(email.Text, password.Text);

        }

        public async void SignUp(string username, string password)
        {

            var vUser = new UserData()
            {
                Email = username,
                Password = password,
                ConfirmPassword = password,
            };
            App.UserDatabase.SaveUser(vUser);
            //List<UserData> _users = App.UserDatabase.GetAllUsers();

            //for( int i = 0; i < _users.Count(); i++ )
            //{
            //    if( _users[i].Email != vUser.Email )
            //    {
            //        App.UserDatabase.SaveUser(vUser);
            //    }
            //}

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
