using System;
using System.Collections.ObjectModel;
using Firebase.Database;
using DoAn.Model;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Newtonsoft.Json;
using DoAn.OriginalPage.User;
using Firebase.Database.Query;
using Firebase.Storage;
using System.IO;

namespace DoAn.Services
{
	public class UserService
	{
        readonly FirebaseClient client = new FirebaseClient("https://xamarinproject-c7a59-default-rtdb.asia-southeast1.firebasedatabase.app/");
        readonly FirebaseStorage firebaseStorage = new FirebaseStorage("xamarinproject-c7a59.appspot.com");

        // save user to firebase database after register
        public async Task<bool> SaveUser(User user)
        {
            var data = await client.Child("Users").PostAsync(JsonConvert.SerializeObject(user));

            if (string.IsNullOrEmpty(data.Key))
                return true;
            return false;
        }

        // get user info from firebase database with email
        public async Task<User> GetUser(string email)
        {
            var data = await client.Child("Users").OnceAsync<User>();
            var user = data.Where(x => x.Object.email == email).FirstOrDefault();
            User result = new User
            {
                name = user.Object.name,
                email = user.Object.email,
                phone = user.Object.phone,
                address = user.Object.address,
                img = user.Object.img
            };
            return result;
        }

        // update user info to firebase database
        public async Task<bool> UpdateUser(User user)
        {
            var data = await client.Child("Users").OnceAsync<User>();
            var userUpdate = data.Where(x => x.Object.email == user.email).FirstOrDefault();
            await client.Child("Users").Child(userUpdate.Key).PutAsync(JsonConvert.SerializeObject(user));
            return true;
        }

        // upload image to firebase storage
        public async Task<string> UploadImage(Stream img, string filePath)
        {
            var image = await firebaseStorage.Child("Images").Child(filePath).PutAsync(img);
            return image;
        }
    }
}

