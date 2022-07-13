using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Data.Entities;
using ToDo.Data.Repository;

namespace ToDo.Data.UoW
{
    public interface IUnitOfWork
    {
        IGenericRepository<Activity> ToDoRepository { get; set; }

        Task<int> CommitAsync();
    }
}