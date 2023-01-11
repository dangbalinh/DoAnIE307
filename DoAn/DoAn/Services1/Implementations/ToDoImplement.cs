using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DoAn.ModelDTO;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using DoAn.Services1.Interface;  

namespace DoAn.Services1.Implementations
{
    public class ToDoImplement : ToDoInterface
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarinproject-c7a59-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public async Task AddTodoItem(TaskDTO task)
        {
                await firebase.Child("Tasks").PostAsync(task);
        }


        public async Task<List<TaskDTO>> GetAllTodoItems()
        {
            return (await firebase.Child("Tasks").OnceAsync<TaskDTO>()).Select(f => new TaskDTO
            {
                taskId = f.Object.taskId,
                taskName = f.Object.taskName,
                taskType = f.Object.taskType,
                taskDate = f.Object.taskDate,
                taskTime = f.Object.taskTime,
                //user_email = f.Object.user_email,
            }).ToList();
        }

        public async Task UpdateTodoItem(string id, TaskDTO task)
        {
            var toUpdateItem = (await firebase
               .Child("Tasks")
               .OnceAsync<TaskDTO>()).Where(a => a.Object.taskId == id).FirstOrDefault();

            await firebase
              .Child("Tasks")
              .Child(toUpdateItem.Key)
              .PutAsync(task);
        }
        public async Task DeleteTodoItem(string id)
        {
            var toDeleteItem = (await firebase
              .Child("Tasks")
              .OnceAsync<TaskDTO>()).Where(a => a.Object.taskId == id).FirstOrDefault();
            await firebase.Child("Tasks").Child(toDeleteItem.Key).DeleteAsync();  
        }
        public async Task<TaskDTO> GetItemTodoById(string id)
        {
            var allItemTodos = await GetAllTodoItems();
            await firebase
              .Child("Tasks")
              .OnceAsync<TaskDTO>();
            return allItemTodos.Where(a => a.taskId == id).FirstOrDefault();
        }
        public async Task<List<TaskDTO>> GetListTaskByDate(string date)
        { 
            List<TaskDTO> tasks = new List<TaskDTO>();
            var allItemTodos = await GetAllTodoItems();
            await firebase
              .Child("Tasks")
              .OnceAsync<TaskDTO>();
            foreach (var item in allItemTodos)
            {
                if(item.taskDate == date)
                {
                    tasks.Add(item);
                }
            }
            return tasks;
            
        }
        public async Task<List<TaskDTO>> GetListTaskByType(string type)
        {
            List<TaskDTO> tasks = new List<TaskDTO>();
            var allItemTodos = await GetAllTodoItems();
            await firebase
              .Child("Tasks")
              .OnceAsync<TaskDTO>();
            foreach (var item in allItemTodos)
            {
                if (item.taskType == type)
                {
                    tasks.Add(item);
                }
            }
            return tasks;

        }
    }
}
