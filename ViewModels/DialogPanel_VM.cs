using CommunityToolkit.Mvvm.ComponentModel;
using MessengerDesktop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.ViewModels
{
    partial class DialogPanel_VM : ObservableObject
    {
        [ObservableProperty]
        private string _messageText = string.Empty;

        [ObservableProperty]
        private string _userName = string.Empty;

        [ObservableProperty]
        private ObservableCollection<MessageModel> _messages = new();

        public DialogPanel_VM(ChatUserModel chatUserModel)
        {
            UserName = chatUserModel.User.Name;
            Messages = chatUserModel.Messages;
        }
    }
}
