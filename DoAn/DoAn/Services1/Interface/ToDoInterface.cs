using DoAn.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using DoAn.ModelDTO;

namespace DoAn.Services1.Interface
{
    public interface ToDoInterface
    {
        Task AddTodoItem(TaskDTO task);

        Task UpdateTodoItem(string id, TaskDTO task);
        Task DeleteTodoItem(string id);

        Task<List<TaskDTO>> GetAllTodoItems(string email);

        Task<List<TaskDTO>> GetListTaskByDate(string date);

    }
}
