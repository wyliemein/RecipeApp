using System;
using System.Threading.Tasks;
using XamarinFirebase;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace RecipeApp
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> SignupWithEmailPassword(string email, string password);
        void SignOut();
        string CurrentUser();
    }
}
