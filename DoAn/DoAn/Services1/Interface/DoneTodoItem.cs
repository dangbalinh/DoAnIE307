using DoAn.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.Services1.Interface
{
    public interface DoneTodoItem
    {
        Task AddDoneTodoItem(TaskDTO task);

        Task<List<TaskDTO>> GetAllDoneTodoItems(string email);

    }
}
