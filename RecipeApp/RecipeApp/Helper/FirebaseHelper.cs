using System;
using System.Collections.Generic;
using System.Text;
using XamarinFirebase.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace XamarinFirebase.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://recipe-37835.firebaseio.com/");

        public async Task<List<Recipe>> GetAllRecipes()
        {

            return (await firebase
              .Child("Recipes")
              .OnceAsync<Recipe>()).Select(item => new Recipe
              {
                  Name = item.Object.Name,
                  URL = item.Object.URL,
                  Ingredient = item.Object.Ingredient,
                  Calcium = item.Object.Calcium,
                  Calories = item.Object.Calories,
                  Category = item.Object.Category,
                  Cholesterol = item.Object.Cholesterol,
                  DietaryFiber = item.Object.DietaryFiber,
                  Folate = item.Object.Folate,
                  Iron = item.Object.Iron,
                  Magnesium = item.Object.Magnesium,
                  Niacin = item.Object.Niacin,
                  Potassium = item.Object.Potassium,
                  Protein = item.Object.Protein,
                  SaturatedFat = item.Object.SaturatedFat,
                  Sodium = item.Object.Sodium,
                  Sugars = item.Object.Sugars,
                  Thiamin = item.Object.Thiamin,
                  TotalCarbohydrates = item.Object.TotalCarbohydrates,
                  TotalFat = item.Object.TotalFat,
                  VitaminA = item.Object.VitaminA,
                  VitaminB6 = item.Object.VitaminB6,
                  VitaminC = item.Object.VitaminC
              }).ToList();
        }

        public async Task AddRecipe(string RecipeUrl, string name, string RecipeIngredients)
        {

            await firebase
              .Child("Recipes")
              .PostAsync(new Recipe() { URL = RecipeUrl, Name = name, Ingredient = RecipeIngredients });
        }

        public async Task<List<Recipe>> GetRecipe(string search, string type)
        {
            var allRecipies = await GetAllRecipes();


            await firebase
              .Child("Recipes")
              .OnceAsync<Recipe>();
            if (type == "Ingredient")//if there are restricted ingredients filter for them.
            {
                return allRecipies.Where(a => a.Ingredient.Contains(search.ToLower()) == true).ToList();
            }
            if (type == "Category")//if there are restricted ingredients filter for them.
            {
                return allRecipies.Where(a => a.Category.Contains(search.ToLower()) == true).ToList();
            }
            return null;
        }
    }
}
