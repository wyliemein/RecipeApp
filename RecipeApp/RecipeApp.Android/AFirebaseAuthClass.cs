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
                return user.User.Email;
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
            return user.User.Email;
        }
        public void SignOut()
        {
            string user = CurrentUser();
            if (user != null)
            {
                FirebaseAuth.Instance.SignOut();
            }
        }
        public string CurrentUser()
        {
            FirebaseUser currentUser = FirebaseAuth.Instance.CurrentUser;
            if (currentUser != null)
            {
                return currentUser.Email;
            }
            return null;
        }
    }
}
