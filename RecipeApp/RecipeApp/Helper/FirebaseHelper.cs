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
                  RecipeUrl = item.Object.RecipeUrl,
                  RecipeIngredients =item.Object.RecipeIngredients
              }).ToList();
        }

        public async Task AddRecipe(string RecipeUrl, string name, string RecipeIngredients)
        {

            await firebase
              .Child("Recipes")
              .PostAsync(new Recipe() { RecipeUrl = RecipeUrl, Name = name, RecipeIngredients = RecipeIngredients });
        }
        
        public async Task<Recipe> GetRecipe(string deIn)
        {
            var allRecipies = await GetAllRecipes();
            await firebase
              .Child("Recipes")
              .OnceAsync<Recipe>();
           // if(deIn != null)
           // {
                return allRecipies.Where(a => a.RecipeIngredients.Contains(deIn.ToLower()) == true).FirstOrDefault();
          //  }

        }
        
    }
}

       