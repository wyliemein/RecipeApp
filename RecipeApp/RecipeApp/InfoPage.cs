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
                    new Label { Text = "Welcome to the Recipe App! To find recipes:" +
                    "\n  1. Press the Find Recipe button" +
                    "\n  2. Choose a diet type and/or a desired ingredient" +
                    "\n  3. Cycle through all recipes that fit your requirements" +
                    "\n  4. Save Recipes for later"}
                }
            };
        }
    }
}
