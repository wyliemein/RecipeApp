using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecipeApp
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }
        private async void SignUp_OnClicked(object sender, EventArgs e)
        {
            if (newPassword.Text == newPasswordCheck.Text && newEmail.Text != null)
            {
                if (IsValidEmail(newEmail.Text))
                {
                    var token = await DependencyService.Get<IFirebaseAuthenticator>().SignupWithEmailPassword(newEmail.Text, newPassword.Text);

                    await DisplayAlert("Signed Up", "Token: " + token, "Ok");
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    await DisplayAlert("Error", "Not a valid email format", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please Fill out all fields and make sure passwords match", "Ok");
            }
     
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
