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
        {
            Random generator = new Random();
            int num = generator.Next(size);
            return num;
        }
    }
}
