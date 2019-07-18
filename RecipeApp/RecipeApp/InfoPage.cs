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
                    new Label { Text = "Welcome to the Recipe App. To find recipes press the Find Recipe button." +
                    "You can choose a diet type and a desired ingredient, then when you press search it will present " +
                    "you a recipe meeting those requirements. If you want another, just click next to cycle through all recipes that fit you requirements"}
                }
            };
        }
    }
}

