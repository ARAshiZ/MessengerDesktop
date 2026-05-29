using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Infrastructure.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Presentation.ViewModels
{
    public partial class DialogPanel_VM : ObservableObject
    {
        private readonly MessageRepository messageRepository = new MessageRepository();

        [ObservableProperty]
        ChatUserModel _chatUser;

        [ObservableProperty]
        private string _messageText = string.Empty;

        [RelayCommand]
        private void Send()
        {
            if (ChatUser != null && !string.IsNullOrWhiteSpace(MessageText)) 
            {
                var msg = new MessageModel();
                msg.ChatUser = ChatUser;
                msg.Message = MessageText;
                messageRepository.Add(msg);
                MessageText = string.Empty;
            }

        }

        public DialogPanel_VM()
        {

        }

        public void SetChatUserModel(ChatUserModel chatUserModel) => ChatUser = chatUserModel;
    }
}
