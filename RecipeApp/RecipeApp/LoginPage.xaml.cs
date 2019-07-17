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
            var token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(email.Text, password.Text);

            await DisplayAlert("Logged in", "Token: " + token, "Ok");
            await Navigation.PushAsync(new HomePage());
        }
    }
}
