using System;
using System.Threading.Tasks;
using RecipeApp.Droid;
using Xamarin.Forms;
using Firebase.Auth;

[assembly: Dependency(typeof(AFirebaseAuthClass))]

namespace RecipeApp.Droid
{
    public class AFirebaseAuthClass : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password).ConfigureAwait(false);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (FirebaseAuthException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        public async Task<string> SignupWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }
        public async void SignOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
            }
            catch (FirebaseAuthException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool CurrentUser(bool initial)
        {
            var current = FirebaseAuth.Instance.CurrentUser;
            if (current != null)
            {
                return true;
            }
            return false;
        }
    }
}
