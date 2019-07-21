﻿using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using XamarinFirebase.Helper;
using XamarinFirebase.Model;


using Xamarin.Forms;
using System.Threading.Tasks;

namespace RecipeApp
{
    public partial class RecipePage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        public RecipePage()
        {
            InitializeComponent();
            Uri uri = new Uri(SearchPage.Link);
            name.Text = "Recipe Name: " +SearchPage.ResName;
            url.Text = "Recipe Url: " + SearchPage.Link;
            ingredients.Text = "Recipe Ingredients: \n" + SearchPage.IngredientList;
        }
        int index = SearchPage.index;

        private async void nextRecipe_OnClicked(object sender, EventArgs e)
        {
            if (SearchPage.temp.Count != 0)
            {


                Random rnd = new Random();
                int i = rnd.Next(0, SearchPage.temp.Count);
                index = i;
                string IngredientList = SearchPage.temp[i].Ingredient;

                char[] toTrim = { '[', '\'', ']' };
                SearchPage.IngredientList = IngredientList.TrimStart(toTrim); //trims " [' " from start
                SearchPage.IngredientList = IngredientList.TrimEnd(toTrim); //trims " ] " from end
                SearchPage.IngredientList = IngredientList.Replace(", ", "\n");

                SearchPage.ResName = SearchPage.temp[i].Name;
                SearchPage.Link = SearchPage.temp[i].URL;
              
                
                SearchPage.temp.RemoveAt(i);
                

                await Navigation.PushAsync(new RecipePage());
            }
            else
            {
                await DisplayAlert("All Out", "There are no more recipes available", "OK");
                await Navigation.PushAsync(new SearchPage());
            }

        }
        
        private int getRandomNumber(int size)
            //Takes an int value = to size of an array and returns a random index within that range
        {
            Random generator = new Random();
            int num = generator.Next(size);
            return num;
        }
        private async void SaveRecipe_OnClicked(object sender, EventArgs e)
        {
            await SaveAsync();
            await Navigation.PushAsync(new RecipeListPage());
        }
        private async Task SaveAsync()
        {
            string tempname = SearchPage.temp[index].Name;
            string tempnURL = SearchPage.temp[index].URL;
            string tempIng = SearchPage.temp[index].Ingredient;
            await firebaseHelper.AddSavedRecipe(tempnURL, tempname, tempIng);
        }
    }
}
