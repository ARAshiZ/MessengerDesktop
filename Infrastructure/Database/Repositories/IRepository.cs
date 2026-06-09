using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    public interface IRepository<T>
    {
        Task Add(T Entity);
        Task Delete(T Entity);
        Task Update(T Entity);
        Task<IEnumerable<T>> FindAll();
        Task<T> FindByID(int ID);
    }
}
