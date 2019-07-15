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
    }
}
