using System;
using System.Collections.Generic;
using System.Text;
using XamarinFirebase.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Globalization;

namespace XamarinFirebase.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://recipe-37835.firebaseio.com/");

        public async Task<List<Recipes>> GetAllRecipes(string type)
        {

            return (await firebase
              .Child(type)
              .OnceAsync<Recipes>()).Select(item => new Recipes
              {
                  Name = item.Object.Name,
                  URL = item.Object.URL,
                  Ingredient = item.Object.Ingredient,
                  Calcium = item.Object.Calcium,
                  Calories = item.Object.Calories,
                  Categroy = item.Object.Categroy,
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

        public async Task AddSavedRecipe(string RecipeUrl, string name, string RecipeIngredients, string Calcium, int Calories,
            string Cholesterol, string Fiber, string Folate, string Iron, string Magnesium, string Niacin, string Potasium, string Protien,
            string SatFats, string Sodium, string Sugars, string Thiamin, string Carbs, string Fats, string VitA, string VitB6,
            string VitC, string Category, string Uid)
        {

            await firebase
              .Child(Uid)
              .PostAsync(new SavedRecipes()
              {
                  URL = RecipeUrl,
                  Name = name,
                  Ingredient = RecipeIngredients,
                  Calcium = Calcium,
                  Calories = Calories,
                  Cholesterol = Cholesterol,
                  DietaryFiber = Fiber,
                  Folate = Folate,
                  Iron = Iron,
                  Magnesium = Magnesium,
                  Niacin = Niacin,
                  Potassium = Potasium,
                  Protein = Protien,
                  SaturatedFat = SatFats,
                  Sodium = Sodium,
                  Sugars = Sugars,
                  Thiamin = Thiamin,
                  TotalCarbohydrates = Carbs,
                  TotalFat = Fats,
                  VitaminA = VitA,
                  VitaminB6 = VitB6,
                  VitaminC = VitC,
                  Category = Category
              });
        }

        public async Task<List<Recipes>> GetRecipe(string search, List<Recipes> initialrecipes, string type)
        {


            await firebase
              .Child("Recipes")
              .OnceAsync<Recipes>();

            if (type == "Ingredient")
            {
                return initialrecipes.Where(a => a.Ingredient.Contains(search.ToLower()) == true).ToList();
            }
            if (type == "unIngredient")
            {
                return initialrecipes.Where(a => a.Ingredient.Contains(search.ToLower()) == false).ToList();
            }
            if (type == "Category")
            {
                return initialrecipes.Where(a => a.Categroy.Contains(search.ToLower()) == true).ToList();
            }
            if (type == "Calories")
            {
                return initialrecipes.Where(a => Convert.ToDouble(a.Calories) <= double.Parse(search, CultureInfo.InvariantCulture)).ToList();
            }

            return null;

        }

        public async Task DeleteRecipe(string recipeName, string type)
        {
            var toDeletePerson = (await firebase
              .Child(type)
              .OnceAsync<SavedRecipes>()).Where(a => a.Object.Name == recipeName).FirstOrDefault();
            await firebase.Child(type).Child(toDeletePerson.Key).DeleteAsync();

        }
    }
}
