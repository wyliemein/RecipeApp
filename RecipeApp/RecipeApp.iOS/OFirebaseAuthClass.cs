using System;
using System.Threading.Tasks;
using RecipeApp.iOS;
using RecipeApp;
using Xamarin.Forms;
using Firebase.Auth;

[assembly: Dependency(typeof(OFirebaseAuthClass))]


namespace RecipeApp.iOS
{
    public class OFirebaseAuthClass
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "";
            }

        }
    }
}
