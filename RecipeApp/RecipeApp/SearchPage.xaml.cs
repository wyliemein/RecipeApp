﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinFirebase.Helper;
using XamarinFirebase.Model;


namespace RecipeApp
{
    public partial class SearchPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public static string ResName;
        public static string IngredientList;
        public static string Link;

        public static List<Recipe> temp;


        public SearchPage()
        {
            InitializeComponent();
        }
        private async void recipeSearch_OnClicked(object sender, EventArgs e)
        {

            string deIn = DeIngredients.Text;
            string diet = dietLabel.Text;
            string search = deIn;
            string type = "Ingredient";
            List<Recipe> person = await firebaseHelper.GetRecipe(search, type);

            if (person.Count != 0)
            {
                Random rnd = new Random();
                int i = rnd.Next(0, person.Count);
                IngredientList = person[i].Ingredient;

                char[] toTrim = {'[', '\'', ']'};
                IngredientList = IngredientList.TrimStart(toTrim); //trims " [' " from start
                IngredientList = IngredientList.TrimEnd(toTrim); //trims " ] " from end
                IngredientList = IngredientList.Replace(", ", "\n");

                ResName = person[i].Name;
                Link = person[i].URL;
                if (person.Count!=1) {
                    person.RemoveAt(i); }

                temp = person;

                await DisplayAlert("Success", "Recipe Retrive Successfully", "OK");
                clearFeild(DeIngredients);
                await Navigation.PushAsync(new RecipePage());
            }
            else
            {
                await DisplayAlert("Success", "No Recipe Available", "OK");
                clearFeild(DeIngredients);
            }
        }
        private void clearFeild(Entry entry)
        {
            entry.Text = string.Empty;
        }
    }
}
