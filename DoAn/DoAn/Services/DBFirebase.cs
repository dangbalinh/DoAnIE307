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

namespace DoAn.Services
{
    public class DBFirebase
    {
        FirebaseClient client = new FirebaseClient("https://todolista-baa40-default-rtdb.asia-southeast1.firebasedatabase.app/");


        public async Task<List<Tip>> GetAllTips()
        {
            return (await client.Child("Tips").OnceAsync<Tip>()).Select(item => new Tip
            {
                Id = (int)item.Object.Id,
                Image = item.Object.Image,
                Title = item.Object.Title,
                Tag = item.Object.Tag,
                Content = item.Object.Content,
            }).ToList();

        }

        public async Task<bool> SaveTip(Tip t)
        {
            var data = await client.Child("Tips").PostAsync(JsonConvert.SerializeObject(t));

            if (string.IsNullOrEmpty(data.Key))
                return true;
            return false;
        }
    }
}

