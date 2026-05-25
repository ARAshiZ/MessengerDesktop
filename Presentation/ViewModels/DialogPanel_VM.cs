using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessengerDesktop.Core.Models;
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
        [ObservableProperty]
        ChatUserModel _chatUser;

        [ObservableProperty]
        private string _messageText = string.Empty;

        [RelayCommand]
        private void Send()
        {
            if (!string.IsNullOrWhiteSpace(MessageText))
            {
                MessageModel msg = new MessageModel();
                msg.Message = MessageText;
                msg.Send = true;
                ChatUser.AddMessage(msg);
                ChatUser.LastMessage = msg;
                MessageText = string.Empty;
            }
        }

        public DialogPanel_VM()
        {

        }

        public void SetChatUserModel(ChatUserModel chatUserModel) => ChatUser = chatUserModel;
    }
}
