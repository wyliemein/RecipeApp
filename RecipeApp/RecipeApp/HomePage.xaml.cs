using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinFirebase.Helper;
using XamarinFirebase.Model;

namespace RecipeApp
{
    public partial class HomePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public HomePage()
        {
            InitializeComponent();
            Navigation.PushAsync(new LoginPage());
        }

        //protected async override void OnAppearing()
        //{

        //   // base.OnAppearing();
        //    //var allRecipes = await firebaseHelper.GetAllRecipes();
        //   // lstPersons.ItemsSource = allPersons;
        //}

        private async void goToSearch_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
        private async void signOut_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void infoButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }
        private async void goToSaved_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipeListPage());
        }

    }
}
