using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecipeApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void Login_OnClicked(object sender, EventArgs e)
        {
            if (password.Text != null && email.Text != null)
            {
                if (IsValidEmail(email.Text))
                {
                   
                    var token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(email.Text, password.Text);
                    if (token != null)
                    {
                        await DisplayAlert("Logged in", "Token" + token, "Ok");
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Invalid Credentials", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Enter a valid email", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "All Fields Must be filled", "Ok");
            }
            
        }
        private async void SignUpPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        bool IsValidEmail(string emailToCheck)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(emailToCheck);
                return addr.Address == emailToCheck;
            }
            catch
            {
                return false;
            }
        }
    }
}
