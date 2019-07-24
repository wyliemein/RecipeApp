using System;
using System.Collections.Generic;
using XamarinFirebase.Model;
using XamarinFirebase.Helper;



using Xamarin.Forms;

namespace RecipeApp
{
    public partial class ViewSavedPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public ViewSavedPage()
        {
            InitializeComponent();
            name.Text = "Recipe Name: " + RecipeListPage.ViewResName;
            url.Text = RecipeListPage.ViewLink;
            ingredients.Text = "Recipe Ingredients: \n" + RecipeListPage.ViewIngredientList;
            nutrition.Text = "Recipe Nutrition: \n" + " \n Calcium:" + RecipeListPage.ViewCalciumList +
               " \n Calories:" + RecipeListPage.ViewCaloriesList + " \n Cholesterol:" + RecipeListPage.ViewCholesterolList + " \n DietaryFiber:" + RecipeListPage.ViewDietaryFiberList + " \n Folate:" + RecipeListPage.ViewFolateList
                + " \n Iron:" + RecipeListPage.ViewIronList + " \n Magnesium:" + RecipeListPage.ViewMagnesiumList + " \n Niacin:" + RecipeListPage.ViewNiacinList + " \n Potassium:" + RecipeListPage.ViewPotassiumList
               + " \n Protein:" + RecipeListPage.ViewProteinList + " \n Saturated Fat:" + RecipeListPage.ViewSaturatedFatList + " \n Sodium:" + RecipeListPage.ViewSodiumList + " \n Sugars:" + RecipeListPage.ViewSugarsList +
               " \n Thiamin:" + RecipeListPage.ViewThiaminList + " \n Total Carbohydrates:" + RecipeListPage.ViewTotalCarbohydratesList + " \n Total Fat:" + RecipeListPage.ViewTotalFatList + " \n Vitamin A:" + RecipeListPage.ViewVitaminAList
               + " \n Vitamin B6:" + RecipeListPage.ViewVitaminB6List + " \n Vitamin C:" + RecipeListPage.ViewVitaminCList;
        }
        protected void GoGoogle(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(RecipeListPage.ViewLink));
        }

        private async void recipeDelete_OnClicked(object sender, EventArgs e)
        {
            string userUid = DependencyService.Get<IFirebaseAuthenticator>().CurrentUser("Uid");
            await firebaseHelper.DeleteRecipe(RecipeListPage.ViewResName, userUid);
            await Navigation.PushAsync(new RecipeListPage());
        }
        private async void gotoHome_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}
