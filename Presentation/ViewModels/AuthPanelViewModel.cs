using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessengerDesktop.Core.Services;
using MessengerDesktop.Core.Services.Interfaces;
using MessengerDesktop.Infrastructure.Database.Repositories;
using MessengerDesktop.Infrastructure.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Presentation.ViewModels
{
    public partial class AuthPanelViewModel : ObservableObject
    {
        private IUserService UserService;
        public event Action<bool> LoginSuccess;

        [ObservableProperty]
        private string _personalKey;

        [RelayCommand]
        private async Task Auth()
        {
            bool isAuthSuccess = await UserService.LoginAsync(PersonalKey);
            if (isAuthSuccess)
            {
                LoginSuccess?.Invoke(true);
            }
        }
        public AuthPanelViewModel(IUserService userService) 
        {
            UserService = userService;
        }
    }
}
