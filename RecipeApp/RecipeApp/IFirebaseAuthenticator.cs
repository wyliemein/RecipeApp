using System;
using System.Threading.Tasks;

namespace RecipeApp
{
    public interface IFirebaseAuthenticator
    {
        Task LoginWithEmailPassword(string text1, string text2);
    }
}
