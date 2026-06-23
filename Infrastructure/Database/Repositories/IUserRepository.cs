using MessengerDesktop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    interface IUserRepository : IRepository<UserModel>
    {
        Task<UserModel> FindByName(string Name);
        Task<UserModel> VerifyPersonalKey(string Key);

    }
}
