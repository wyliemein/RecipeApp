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
        public static string CalciumList;
        public static int CaloriesList;
        public static string CholesterolList;
        public static string DietaryFiberList;
        public static string FolateList;
        public static string IronList;
        public static string MagnesiumList;
        public static string NiacinList;
        public static string PotassiumList;
        public static string ProteinList;
        public static string SaturatedFatList;
        public static string SodiumList;
        public static string SugarsList;
        public static string ThiaminList;
        public static string TotalCarbohydratesList;
        public static string TotalFatList;
        public static string VitaminAList;
        public static string VitaminB6List;
        public static string VitaminCList;
        public static string Link;
        public static int index;
        public static List<Recipes> temp;


        public SearchPage()
        {
            InitializeComponent();
        }
        private async void recipeSearch_OnClicked(object sender, EventArgs e)
        {

            string deIn = DeIngredients.Text;
            string diet = dietLabel.Text;
            string calIn = calories.Text;
            string type = "";


            List<Recipes> person = await firebaseHelper.GetAllRecipes("Recipes");

            if (diet == null && deIn == null && calIn == null) {
                await DisplayAlert("Fail", "Enter at least one Field", "OK");
                return;
            }

            if (diet != null&& diet != "None") {
                type ="Category";
                person = await firebaseHelper.GetRecipe(diet, person,type);
            }
            if (deIn != null)
            {
                type = "Ingredient";
                person = await firebaseHelper.GetRecipe(deIn, person,type);
            }
            if (calIn != null)
            {
                type = "Calories";
                person = await firebaseHelper.GetRecipe(calIn, person,type);
            }

            if (person.Count != 0)
            {
                Random rnd = new Random();
                index = rnd.Next(0, person.Count);
                IngredientList = person[index].Ingredient;
                CalciumList = person[index].Calcium;
                CaloriesList = person[index].Calories;
                CholesterolList = person[index].Cholesterol;
                DietaryFiberList = person[index].DietaryFiber;
                FolateList = person[index].Folate;
                IronList = person[index].Iron;
                MagnesiumList = person[index].Magnesium;
                NiacinList = person[index].Niacin;
                PotassiumList = person[index].Potassium;
                ProteinList = person[index].Protein;
                SaturatedFatList = person[index].SaturatedFat;
                SodiumList = person[index].Sodium;
                SugarsList = person[index].Sugars;
                ThiaminList = person[index].Thiamin;
                TotalCarbohydratesList = person[index].TotalCarbohydrates;
                TotalFatList = person[index].TotalFat;
                VitaminAList = person[index].VitaminA;
                VitaminB6List = person[index].VitaminB6;
                VitaminCList = person[index].VitaminC;


                char[] toTrim = {'[', '\'', ']'};
                IngredientList = IngredientList.TrimStart(toTrim); //trims " [' " from start
                IngredientList = IngredientList.TrimEnd(toTrim); //trims " ] " from end
                IngredientList = IngredientList.Replace("', '", "\n");

                ResName = person[index].Name;
                Link = person[index].URL;

                temp = person;
                await DisplayAlert("Success", "Recipe Retrive Successfully", "OK");
                clearFeild(DeIngredients);
                clearFeild(calories);
                await Navigation.PushAsync(new RecipePage());
            }
            else
            {
                await DisplayAlert("Success", "No Recipe Available", "OK");
                clearFeild(DeIngredients);
                clearFeild(calories);
                dietLabel.Text = "";
            }
        }
        private void clearFeild(Entry entry)
        {
            entry.Text = null;
        }
    }
}
