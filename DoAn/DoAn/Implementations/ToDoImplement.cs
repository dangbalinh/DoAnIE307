using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DoAn.ModelDTO;
using Firebase.Database;
using Firebase.Database.Query;
using DoAn.Model;
using System.Linq;

namespace DoAn.Implementations
{
    public class ToDoImplement 
    {
        FirebaseClient firebase = new FirebaseClient("https://xamarinproject-c7a59-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public async Task<bool> AddOrUpdateToDoItem(TaskToDo taskModel)
        {
            if (!string.IsNullOrWhiteSpace(taskModel.taskId.ToString()))
            {
                try
                {
                    await firebase.Child(nameof(taskModel)).Child(taskModel.taskId.ToString()).PutAsync(taskModel);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                //var response = await firebase.Child(nameof(taskModel)).PostAsync(taskModel);
                //if (response.taskId != null)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                return true;
            }
        }
        public async Task<List<TaskToDo>> GetAllToDoItems()
        {
            return (await firebase.Child(nameof(TaskToDo)).OnceAsync<TaskToDo>()).Select(f => new TaskToDo
            {
                taskId = f.Object.taskId,
                taskName = f.Object.taskName,
                taskType = f.Object.taskType,
                taskDate = f.Object.taskDate,
                taskTime = f.Object.taskTime,
            }).ToList();
        }
        public async Task<bool> DeleteToDoItem(int Id)
        {
            try
            {
                await firebase.Child(nameof(TaskToDo)).Child(Id.ToString()).DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //public async Task<TaskDTO> GetItemToDoById(int id)
        //{
            
        //}
        //public async Task<TaskDTO> GetListTaskByDate(DateTime date)
        //{

        //}
    }
}
