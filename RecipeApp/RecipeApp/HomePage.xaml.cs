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
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allRecipes = await firebaseHelper.GetAllRecipes();
           // lstPersons.ItemsSource = allPersons;
        }

        private async void goToSearch_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
        private async void addRecipe_OnClicked(object sender, EventArgs e)
        {
            var Url = recipeUrl.Text;
            var Ingredients = recipeIngredients.Text;
            var RecipeName = recipeName.Text;
            await firebaseHelper.AddRecipe(Url, RecipeName, Ingredients);
            await DisplayAlert("Success", "Recipe Added Successfully", "OK");
            var allRecipes = await firebaseHelper.GetAllRecipes();
            // lstPersons.ItemsSource = allPersons;
        }
    }
}
