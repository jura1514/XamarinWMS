using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinWMS.View.Login
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        public void OnLoginClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Login());
          //  SignUp(email.Text, password.Text);

        }

        public void OnRegisterClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Signup());
        }

        //public async void SignUp(string username, string password)
        //{
        //    var vUser = new UserData()
        //    {
        //        Email = username,
        //        Password = password,
        //        ConfirmPassword = password,
        //    };
        //    App.UserDatabase.SaveUser(vUser);

        //    bool isNewUser = true;
        //    await App.UserManager.SaveTaskAsync(vUser, isNewUser);

        //}
    }
}
