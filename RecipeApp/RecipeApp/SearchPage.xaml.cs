using System;
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
        public static string CalciumList;
        public static int CaloriesList;
        public static string CholesterolList;
        public static string DietaryFiberList;
        public static string FolateList;
        public static string IronList;
        public static string MagnesiumList;
        public static string NiacinList;
        public static string PotassiumList;
        public static string ProteinList;
        public static string SaturatedFatList;
        public static string SodiumList;
        public static string SugarsList;
        public static string ThiaminList;
        public static string TotalCarbohydratesList;
        public static string TotalFatList;
        public static string VitaminAList;
        public static string VitaminB6List;
        public static string VitaminCList;
        public static string Link;
        public static int index;
        public static List<Recipes> temp;
        public static string[] symbols = new string[]{"@", "!" , "#", "$", "%", "^", "&", "*", "(", ")", "`", "~", "{", "}"
            ,"[", "]", ";", ":", ".","/", "?","|" };
        public static string[] vegan = new string[] { "bacon", "beef", "lamb", "pork", "snail",
                "chicken", "turkey", "goose", "duck", "quail" ,"salmon", "tuna", "albacore", "anchovies",
                "shrimp", "squid", "scallops", "calamari", "mussels", "crab", "lobster", "fish",
            "milk", "yogurt", "cheese", "butter", "ice cream","cream", "eggs", "honey", "bee pollen",
            "whey", "gelatin", "honeycomb", "lard", "fish sauce", "chicken broth","bone broth"};
        public static string[] vegetarian = new string[] { "bacon", "beef", "lamb", "pork", "snail",
                "chicken", "turkey", "goose", "duck", "quail" ,"salmon", "tuna", "albacore", "anchovies",
                "shrimp", "squid", "scallops", "calamari", "mussels", "crab", "lobster", "fish" };
        public static string[] pescatarian = new string[] { "bacon", "beef", "lamb", "pork", "snail",
                "chicken", "turkey", "goose", "duck", "quail" };
        public static string[] glutenfree = new string[] { "Pasta", "bread", "crackers", "semolina"
                , "barley", "oats", "rye", "soy sauce", "chicken broth" };


        public SearchPage()
        {
            InitializeComponent();
        }
        private async void recipeSearch_OnClicked(object sender, EventArgs e)
        {

            string deIn = DeIngredients.Text;
            string diet = dietLabel.Text;
            string calIn = calories.Text;
            string unIn = UnIngredients.Text;
            string type = "";

            if (deIn != null)
            {
                bool inValidsymbol = ContainsAny(deIn, symbols);
                if (inValidsymbol)
                {
                    await DisplayAlert("Fail", "Entered Invalid Symbol", "OK");
                    return;
                }
            }

            List<Recipes> person = await firebaseHelper.GetAllRecipes("Recipes");

            if ((diet == null|| diet == "None") && deIn == null && calIn == null&& unIn==null) {
                await DisplayAlert("Fail", "Enter at least one Field", "OK");
                return;
            }
            if(diet != "None"&&diet != null && deIn != null){
                
                if (Checkdup(diet,deIn)) {
                    await DisplayAlert("Fail", "Diet type and desired Ingredients are contradicting", "OK");
                    return;
                }
            }
            if (diet != "None" && diet != null && unIn != null)
            {

                if (Checkdup(diet, unIn))
                {
                    await DisplayAlert("Fail", "Diet type and unwished Ingredients are contradicting", "OK");
                    return;
                }
            }


            if (diet != null && diet != "None") {
                type ="Category";
                person = await firebaseHelper.GetRecipe(diet, person,type);
            }
            if (deIn != null)
            {
                string[] ingres = deIn.Split(',');
                type = "Ingredient";
                foreach (var word in ingres)
                {
                    person = await firebaseHelper.GetRecipe(word, person, type);
                }
            }
            if (unIn != null)
            {
                string[] ingres = unIn.Split(',');
                type = "unIngredient";
                foreach (var word in ingres)
                {
                    person = await firebaseHelper.GetRecipe(word, person, type);
                }
            }
            if (calIn != null) {
                if (calIn.Contains("-"))
                {
                    await DisplayAlert("Fail", "Cannot enter negative number", "OK");
                    return;
                }
                type = "Calories";
                person = await firebaseHelper.GetRecipe(calIn, person, type);
            }

            if (person.Count != 0)
            {
                Random rnd = new Random();
                index = rnd.Next(0, person.Count);
                IngredientList = person[index].Ingredient;
                CalciumList = person[index].Calcium;
                CaloriesList = person[index].Calories;
                CholesterolList = person[index].Cholesterol;
                DietaryFiberList = person[index].DietaryFiber;
                FolateList = person[index].Folate;
                IronList = person[index].Iron;
                MagnesiumList = person[index].Magnesium;
                NiacinList = person[index].Niacin;
                PotassiumList = person[index].Potassium;
                ProteinList = person[index].Protein;
                SaturatedFatList = person[index].SaturatedFat;
                SodiumList = person[index].Sodium;
                SugarsList = person[index].Sugars;
                ThiaminList = person[index].Thiamin;
                TotalCarbohydratesList = person[index].TotalCarbohydrates;
                TotalFatList = person[index].TotalFat;
                VitaminAList = person[index].VitaminA;
                VitaminB6List = person[index].VitaminB6;
                VitaminCList = person[index].VitaminC;


                char[] toTrim = {'[', '\'', ']'};
                IngredientList = IngredientList.TrimStart(toTrim); //trims " [' " from start
                IngredientList = IngredientList.TrimEnd(toTrim); //trims " ] " from end
                IngredientList = IngredientList.Replace("', '", "\n");

                ResName = person[index].Name;
                Link = person[index].URL;

                temp = person;
                
                await DisplayAlert("Success", "Recipe Retrive Successfully", "OK");
                clearFeild(DeIngredients);
                clearFeild(calories);
                await Navigation.PushAsync(new RecipePage());
            }
            else
            {
                await DisplayAlert("Error", "No Recipe Available", "Search Again");
                clearFeild(DeIngredients);
                clearFeild(calories);
                dietLabel.Text = "";
            }
        }
        private void clearFeild(Entry entry)
        {
            entry.Text = null;
        }

        private static bool Checkdup(string diet, string inPut)
        {
            bool duplicated = false;
            if (diet == "Vegan")
            {
                duplicated = ContainsAny(inPut, vegan);
            }
            else if (diet == "Vegetarian")
            {
                duplicated = ContainsAny(inPut, vegetarian);
            }
            else if (diet == "Pescatarian")
            {
                duplicated = ContainsAny(inPut, pescatarian);
            }
            else if (diet == "Gluten Free")
            {
                duplicated = ContainsAny(inPut, glutenfree);
            }
            return duplicated;
        }
        private static bool ContainsAny(string oriString, string[] inValids)
        {
            foreach (string inValid in inValids)
            {
                if (oriString.ToLower().Contains(inValid))
                    return true;
            }

            return false;
        }
    }
}
