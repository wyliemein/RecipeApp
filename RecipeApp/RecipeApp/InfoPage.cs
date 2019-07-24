using System;

using Xamarin.Forms;

namespace RecipeApp
{
    public class InfoPage : ContentPage
    {
        public InfoPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Pick an Ingredient! To find recipes:" +
                    "\n  1. Press the Find Recipe button" +
                    "\n  2. Specify your food preferences" +
                    "\n  3. Cycle through all recipes that fit your" +
                    "\n      requirements" +
                    "\n  4. Save Recipes for later"}
                }
            };
        }
    }
}
