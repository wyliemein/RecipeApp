using System;
using System.Collections.Generic;
using XamarinFirebase;
using XamarinFirebase.Model;
using XamarinFirebase.Helper;


using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace RecipeApp
{
    public partial class RecipeListPage : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        ObservableCollection<recipeToDisplay> recipes = new ObservableCollection<recipeToDisplay>();
        public ObservableCollection<recipeToDisplay> SavedRecipes { get { return recipes; } }
        public string[] name = null;
        public int index;

        public RecipeListPage()
        {
            InitializeComponent();
            RecipeListView.ItemsSource = SavedRecipes;
            _ = GetList();
            if (name != null)
            {
                SavedRecipes.Add(new recipeToDisplay { DisplayName = name[index] });

            }
            else
            {
                l.Text = "No recipes saved";
            }
        }

        public async Task GetList()
        {
            List<SavedRecipes> saved = await firebaseHelper.GetAllSavedRecipes();
            if (saved != null)
            {
                int index = 0;
                foreach (var item in saved)
                {
                    name[index] = item.Name;
                    index++;
                }
            }
        }
        public class recipeToDisplay
        {
            public string DisplayName { get; set; }
        }

    }
}
