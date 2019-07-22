using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinFirebase.Helper;
using XamarinFirebase.Model;


using Xamarin.Forms;
using System.Threading.Tasks;

namespace RecipeApp
{
    public partial class RecipePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public RecipePage()
        {
            InitializeComponent();
            Uri uri = new Uri(SearchPage.Link);
            name.Text = "Recipe Name: " +SearchPage.ResName;
            url.Text = SearchPage.Link;
            ingredients.Text = "Recipe Ingredients: \n" + SearchPage.IngredientList;
            nutrition.Text = "Recipe Nutrition: \n"+ " \n Calcium:" + SearchPage.CalciumList +
               " \n Calories:" + SearchPage.CaloriesList + " \n Cholesterol:" + SearchPage.CholesterolList + " \n DietaryFiber:" + SearchPage.DietaryFiberList + " \n Folate:" + SearchPage.FolateList
                + " \n Iron:" + SearchPage.IronList + " \n Magnesium:" + SearchPage.MagnesiumList + " \n Niacin:" + SearchPage.NiacinList + " \n Potassium:" + SearchPage.PotassiumList 
               + " \n Protein:" + SearchPage.ProteinList + " \n Saturated Fat:" + SearchPage.SaturatedFatList + " \n Sodium:" + SearchPage.SodiumList + " \n Sugars:" + SearchPage.SugarsList +
               " \n Thiamin:" + SearchPage.ThiaminList + " \n Total Carbohydrates:" + SearchPage.TotalCarbohydratesList + " \n Total Fat:" + SearchPage.TotalFatList + " \n Vitamin A:" + SearchPage.VitaminAList 
               + " \n Vitamin B6:" + SearchPage.VitaminB6List + " \n Vitamin C:" + SearchPage.VitaminCList;
        }
        int index = SearchPage.index;

        private async void nextRecipe_OnClicked(object sender, EventArgs e)
        {
            if (SearchPage.temp.Count != 0)
            {


                Random rnd = new Random();
                int i = rnd.Next(0, SearchPage.temp.Count);
                index = i;
                string IngredientList = SearchPage.temp[i].Ingredient;

                char[] toTrim = { '[', '\'', ']' };
                SearchPage.IngredientList = IngredientList.TrimStart(toTrim); //trims " [' " from start
                SearchPage.IngredientList = IngredientList.TrimEnd(toTrim); //trims " ] " from end
                SearchPage.IngredientList = IngredientList.Replace(", ", "\n");

                SearchPage.ResName = SearchPage.temp[i].Name;
                SearchPage.Link = SearchPage.temp[i].URL;
              
                
                SearchPage.temp.RemoveAt(i);
                

                await Navigation.PushAsync(new RecipePage());
            }
            else
            {
                await DisplayAlert("All Out", "There are no more recipes available", "OK");
                await Navigation.PushAsync(new SearchPage());
            }

        }
        protected void GoGoogle(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(SearchPage.Link));
        }
        private int getRandomNumber(int size)
            //Takes an int value = to size of an array and returns a random index within that range
        {
            Random generator = new Random();
            int num = generator.Next(size);
            return num;
        }
        private async void SaveRecipe_OnClicked(object sender, EventArgs e)
        {
            await SaveAsync();
            await Navigation.PushAsync(new RecipeListPage());
        }
        private async Task SaveAsync()
        {
            string tempname = SearchPage.temp[index].Name;
            string tempnURL = SearchPage.temp[index].URL;
            string tempIng = SearchPage.temp[index].Ingredient;
            await firebaseHelper.AddSavedRecipe(tempnURL, tempname, tempIng);
        }
    }
}
