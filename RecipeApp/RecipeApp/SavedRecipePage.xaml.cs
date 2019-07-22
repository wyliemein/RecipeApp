using System;
using System.Collections.Generic;
using XamarinFirebase;
using XamarinFirebase.Model;
using XamarinFirebase.Helper;


using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace RecipeApp
{
    public partial class RecipeListPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        ObservableCollection<Recipes> recipes = new ObservableCollection<Recipes>();
        public ObservableCollection<Recipes> SavedRecipes { get { return recipes; } }
        public string[] name;
        public int index;
        public static string ViewResName;
        public static string ViewIngredientList;
        public static string ViewCalciumList;
        public static int ViewCaloriesList;
        public static string ViewCholesterolList;
        public static string ViewDietaryFiberList;
        public static string ViewFolateList;
        public static string ViewIronList;
        public static string ViewMagnesiumList;
        public static string ViewNiacinList;
        public static string ViewPotassiumList;
        public static string ViewProteinList;
        public static string ViewSaturatedFatList;
        public static string ViewSodiumList;
        public static string ViewSugarsList;
        public static string ViewThiaminList;
        public static string ViewTotalCarbohydratesList;
        public static string ViewTotalFatList;
        public static string ViewVitaminAList;
        public static string ViewVitaminB6List;
        public static string ViewVitaminCList;
        public static string ViewLink;

        public RecipeListPage()
        {
            InitializeComponent();
            RecipeListView.ItemsSource = SavedRecipes;
            GetSaved();
        }

        private async void GetSaved()
        {
            List<Recipes> saved = await firebaseHelper.GetAllRecipes("Saved Recipes").ConfigureAwait(false);
            if (saved !=null)
            {
                foreach (Recipes item in saved)
                {
                    SavedRecipes.Add(new Recipes { Name = item.Name, URL = item.URL, Calcium = item.Calcium,
                    Calories = item.Calories, Ingredient = item.Ingredient, Cholesterol = item.Cholesterol,
                    Categroy = item.Categroy, DietaryFiber = item.DietaryFiber, Folate = item.Folate, Iron = item.Iron,
                    Magnesium = item.Magnesium, Niacin = item.Niacin, Potassium = item.Potassium, Protein = item.Protein,
                    SaturatedFat = item.SaturatedFat, Sodium = item.Sodium, Sugars = item.Sugars, Thiamin = item.Thiamin,
                    TotalCarbohydrates = item.TotalCarbohydrates, TotalFat = item.TotalFat, VitaminA = item.VitaminA,
                    VitaminB6 = item.VitaminB6, VitaminC = item.VitaminC});
                }
            }
            else
            {
                l.Text = "No Recipes saved";
            }

        }
        async void Handle_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            Recipes tappedRecipe = e.SelectedItem as Recipes;
            Console.WriteLine(tappedRecipe.Name);
            ViewLink = tappedRecipe.URL;
            ViewResName = tappedRecipe.Name;
            ViewIngredientList = tappedRecipe.Ingredient;
            ViewCalciumList = tappedRecipe.Calcium;
            ViewCaloriesList = tappedRecipe.Calories;
            ViewCholesterolList = tappedRecipe.Cholesterol;
            ViewDietaryFiberList = tappedRecipe.DietaryFiber;
            ViewFolateList = tappedRecipe.Folate;
            ViewIronList = tappedRecipe.Iron;
            ViewMagnesiumList = tappedRecipe.Magnesium;
            ViewPotassiumList = tappedRecipe.Potassium;
            ViewProteinList = tappedRecipe.Protein;
            ViewNiacinList = tappedRecipe.Niacin;
            ViewSaturatedFatList = tappedRecipe.SaturatedFat;
            ViewSodiumList = tappedRecipe.Sodium;
            ViewSugarsList = tappedRecipe.Sugars;
            ViewThiaminList = tappedRecipe.Thiamin;
            ViewTotalCarbohydratesList = tappedRecipe.TotalCarbohydrates;
            ViewTotalFatList = tappedRecipe.TotalFat;
            ViewVitaminAList = tappedRecipe.VitaminA;
            ViewVitaminB6List = tappedRecipe.VitaminB6;
            ViewVitaminCList = tappedRecipe.VitaminC;
            await Navigation.PushAsync(new ViewSavedPage());
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }

    }
}
