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

            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            if (user.User.IsEmailVerified)
            {
                var token = await user.User.GetIdTokenAsync(false);
                if (token != null)
                {
                    return token.Token;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> SignupWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }
    }
}
