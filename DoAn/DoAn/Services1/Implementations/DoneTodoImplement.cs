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
        public async Task<List<TaskDTO>> GetAllDoneTodoItems()
        {
            return (await firebase.Child("TasksDone").OnceAsync<TaskDTO>()).Select(f => new TaskDTO
            {
                taskId = f.Object.taskId,
                taskName = f.Object.taskName,
                taskType = f.Object.taskType,
                taskDate = f.Object.taskDate,
                taskTime = f.Object.taskTime,
            }).ToList();
        }
    }
}
