using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.Services
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
