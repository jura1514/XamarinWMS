﻿using Newtonsoft.Json;
using Plugin.Connectivity;
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
        //check if phone has access to network
        bool isConnected = false;

        public Signup()
        {
            InitializeComponent();

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        public void OnSignUpClicked(object sender, EventArgs e)
        {
            if (isConnected)
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
            else
            {
                DisplayAlert("Error", "Cannot signup without connection!", "OK");
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
