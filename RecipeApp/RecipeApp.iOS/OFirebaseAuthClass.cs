using System;
using System.Threading.Tasks;
using RecipeApp.iOS;
using Xamarin.Forms;
using Firebase.Auth;
using Firebase.Core;

[assembly: Dependency(typeof(OFirebaseAuthClass))]


namespace RecipeApp.iOS
{
    public class OFirebaseAuthClass
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var authDataResult = await Auth.DefaultInstance.SignInWithPasswordAsync(
                email,
                password);

            return await authDataResult.User.GetIdTokenAsync();

        }

        public async Task<string> SignupWithEmailPasswordAsync(string email, string password)
        {
            var authDataResult = await Auth.DefaultInstance.CreateUserAsync(email, password);

            return await authDataResult.User.GetIdTokenAsync();
        }
    }
}
