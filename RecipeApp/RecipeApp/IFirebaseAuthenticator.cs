using System;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IFirebaseAuthenticator
    {
        Task<string> LoginWithEmailPassword(string email, string password);
        Task<string> SignupWithEmailPassword(string email, string password);
        bool CurrentUser(bool initial);

    }
}
