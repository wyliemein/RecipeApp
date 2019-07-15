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
    public partial class SearchPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public static string ResName;
        public static string IngredientList;



        public SearchPage()
        {
            InitializeComponent();
        }
        private async void recipeSearch_OnClicked(object sender, EventArgs e)
        {

            string deIn = DeIngredients.Text;
            Console.WriteLine(deIn);

            List<Recipe> person= await firebaseHelper.GetRecipe(deIn);
            if (person != null)
            {


                IngredientList = person[1].Ingredient;
                ResName = person[1].Name;


                await DisplayAlert("Success", "Recipe Retrive Successfully", "OK");
                clearFeild(DeIngredients);
                await Navigation.PushAsync(new RecipePage());
            }
            else
            {
                await DisplayAlert("Success", "No Recipe Available", "OK");
                clearFeild(DeIngredients);
            }
        }
        private void clearFeild(Entry entry)
        {
            entry.Text = string.Empty;
        }
    }
}
