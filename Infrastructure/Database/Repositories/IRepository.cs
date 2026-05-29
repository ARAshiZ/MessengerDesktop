using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    public interface IRepository<T>
    {
        void Add(T Entity);
        void Delete(T Entity);
        void Update(T Entity);
        IEnumerable<T> FindAll();
        T FindByID(int ID);
    }
}
