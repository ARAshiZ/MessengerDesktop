using MessengerDesktop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Core.Services.Interfaces
{
    public interface IUserService
    {
        UserModel CurrentUser { get; }
        bool IsLoggedIn { get; }
        Task<bool> LoginAsync(string key);
        event Action<UserModel> UserChanged;
        void Logout();

    }
}
