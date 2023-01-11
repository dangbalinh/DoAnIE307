using DoAn.ModelDTO;
using DoAn.Services1.Interface;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Services1.Implementations
{
    public class DoneTodoImplement : DoneTodoItem
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarinproject-c7a59-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task AddDoneTodoItem(TaskDTO task)
        {
            await firebase.Child("TasksDone").PostAsync(task);
        }
        public async Task<List<TaskDTO>> GetAllDoneTodoItems(string email)
        {
            // get all done task that belong to the user
            return (await firebase
              .Child("TasksDone")
              .OnceAsync<TaskDTO>()).Where(a => a.Object.user_email == email).Select(item => new TaskDTO
              {
                  taskId = item.Object.taskId,
                  taskName = item.Object.taskName,
                  taskDate = item.Object.taskDate,
                  taskTime = item.Object.taskTime,
                  taskType = item.Object.taskType,
                  user_email = item.Object.user_email
              }).ToList();

        }
    }
}
