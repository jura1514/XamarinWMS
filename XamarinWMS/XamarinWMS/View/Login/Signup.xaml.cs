using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                UserName = username,
                Password = password,
                ConfirmPassword = password,
            };
            App.UserDatabase.SaveUser(vUser);

            bool isNewUser = true;
            await App.UserManager.SaveTaskAsync(vUser, isNewUser);

        }
    }
}
