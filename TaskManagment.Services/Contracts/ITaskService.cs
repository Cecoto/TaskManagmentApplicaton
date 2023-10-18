namespace TaskManagment.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITaskService
    {

        Task<IEnumerable<Task>> GetAllTasks();

        Task<IEnumerable<Task>> GetTaskById();

        
    }
}
