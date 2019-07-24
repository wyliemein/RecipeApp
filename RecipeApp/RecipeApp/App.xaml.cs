using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipeApp
{
    public partial class App : Application
    {
		public App()
        {
            switch (Device.RuntimePlatform)
            {

                case Device.iOS:
                    MainPage = new NavigationPage(new RecipeApp.HomePage());
                    break;
                case Device.Android:
                    MainPage = new RecipeApp.HomePage();
                    break;
            }
        }

		protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}