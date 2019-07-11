using System;
using System.Collections.Generic;
using System.Text;
using XamarinFirebase.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace XamarinFirebase.Helper
{

    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://recipe-37835.firebaseio.com/");

        public async Task<List<Recipe>> GetAllPersons()
        {

            return (await firebase
              .Child("Persons")
              .OnceAsync<Recipe>()).Select(item => new Recipe
              {
                  Name = item.Object.Name,
                  PersonId = item.Object.PersonId
              }).ToList();
        }

        public async Task AddPerson(int personId, string name)
        {

            await firebase
              .Child("Persons")
              .PostAsync(new Recipe() { PersonId = personId, Name = name });
        }
    }
}

       