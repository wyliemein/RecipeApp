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
                  Ingredients = item.Object.Ingredients,
                  Calcium = item.Object.Calcium,
                  Calories = item.Object.Calories,
                  Category = item.Object.Category,
                  Cholesterol = item.Object.Cholesterol,
                  DietaryFiber = item.Object.DietaryFiber,
                  Folate = item.Object.Folate,
                  Iron = item.Object.Iron,
                  Magnesium = item.Object.Iron,
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
              .PostAsync(new Recipe() { URL = RecipeUrl, Name = name, Ingredients = RecipeIngredients });
        }

        public async Task<Recipe> GetRecipe(string deIn)
        {
            var allRecipies = await GetAllRecipes();
            
            await firebase
              .Child("Recipes")
              .OnceAsync<Recipe>();
            //if(deIn != null)
            //{
                return allRecipies.Where(a => a.Ingredients.Contains(deIn.ToLower()) == true).FirstOrDefault();
           //}

        }

    }
}
