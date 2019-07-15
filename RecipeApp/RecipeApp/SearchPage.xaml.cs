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
            string reIn = ReIngredients.Text;
            Console.WriteLine(deIn);
            Console.WriteLine(reIn);

            var person = await firebaseHelper.GetRecipe(DeIngredients.Text, ReIngredients.Text);
            if (person != null)
            {
                
              
                IngredientList = person.RecipeIngredients;
   
                ResName = person.Name;

            
                await DisplayAlert("Success", "Person Retrive Successfully", "OK");
                await Navigation.PushAsync(new RecipePage());
            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "OK");
            }
            //await Navigation.PushAsync(new RecipePage());
        }
    }
}
