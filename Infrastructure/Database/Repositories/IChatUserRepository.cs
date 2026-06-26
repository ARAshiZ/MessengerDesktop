using MessengerDesktop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Infrastructure.Database.Repositories
{
    public interface IChatUserRepository : IRepository<ChatUserModel>
    {
        Task<IEnumerable<ChatUserModel>> FindAllByContact(int contactUserId);
    }
}
