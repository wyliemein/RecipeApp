using System;
using System.Collections.Generic;
using XamarinFirebase.Helper;

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
                    if (ValidatePassword(newPassword.Text))
                    {
                        var token = await DependencyService.Get<IFirebaseAuthenticator>().SignupWithEmailPassword(newEmail.Text, newPassword.Text);
                        await DisplayAlert("Success", "User: " + token + " is signed up.", "Ok");
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Password must be more than 6 digits", "Ok");
                    }
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

        static bool ValidatePassword(string password)
        {
            const int MIN_LENGTH = 6;
            const int MAX_LENGTH = 15;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            return meetsLengthRequirements;

        }
    }
}
