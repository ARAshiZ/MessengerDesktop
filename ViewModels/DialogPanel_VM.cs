using CommunityToolkit.Mvvm.ComponentModel;
using MessengerDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.ViewModels
{
    partial class DialogPanel_VM : ObservableObject
    {
        [ObservableProperty]
        private string _messageText = "Введите сообщение...";

        [ObservableProperty]
        private string _userName = string.Empty;

        public DialogPanel_VM(ChatUserModel chatUserModel)
        {
            UserName = chatUserModel.User.Name;
        }
    }
}
