using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecipeApp
{
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
            url.Text = "Recipe Url: " + SearchPage.ResName;
            ingredients.Text = "Recipe Ingredients: " + SearchPage.IngredientList;

        }

        private int getRandomNumber(int size)
            //Takes an int value = to size of an array and returns a random index within that range
        {
            Random generator = new Random();
            int num = generator.Next(size);
            return num;
        }
    }
}
