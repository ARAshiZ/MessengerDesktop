using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Core.Services.Interfaces;
using MessengerDesktop.Infrastructure.Database.Repositories;
using MessengerDesktop.Infrastructure.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Core.Services
{
    public class UserService : ObservableObject, IUserService
    {
        private readonly IUserRepository UserRepository;
        private UserModel _currentUser;
        public UserModel CurrentUser => _currentUser;
        public bool IsLoggedIn => _currentUser != null;

        public event Action<UserModel> UserChanged;

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public async Task<bool> LoginAsync(string key)
        {
            var user = await UserRepository.VerifyPersonalKey(key);
            if (user != null)
            {
                _currentUser = user;
                UserChanged?.Invoke(_currentUser);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            _currentUser = null;
            UserChanged.Invoke(null);
        }
    }
}
