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
                    new Label { Text = "Welcome to the Recipe App," + "to find recipes:" +
                    "1.press the Find Recipe button." +
                    "2. Choose a diet type and/ or a desired ingredient" +
                    "3. Cycle through all recipes that fit you requirements" +
                    "4. Save Recipes for later"}
                }
            };
        }
    }
}

