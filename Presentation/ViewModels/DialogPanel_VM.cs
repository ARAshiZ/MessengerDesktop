using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Infrastructure.Database.Repositories;
using MessengerDesktop.Infrastructure.DataTransferObjects;
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
        private readonly MessageRepository messageRepository = new ();
        private readonly ChatUserRepository chatUserRepository = new();

        private int chatUserId = 0;

        [ObservableProperty]
        private ObservableCollection<MessageModel> _messages;

        [ObservableProperty]
        private string _messageText = string.Empty;

        [ObservableProperty]
        private string _name = string.Empty;

        [RelayCommand]
        private void Send()
        {
            if (!string.IsNullOrWhiteSpace(MessageText)) 
            {
                var msg = new MessageModel();
                msg.ChatUserID = chatUserId;
                msg.Message = MessageText;
                messageRepository.Add(msg);
                Messages.Add(msg);
                MessageText = string.Empty;
            }

        }

        public DialogPanel_VM()
        {

        }

        public void LoadChatUser(ChatUserData ChatUserData)
        {
           var ChatUser = chatUserRepository.FindByID(ChatUserData.ID);
           chatUserId = ChatUser.Id;
           Name = ChatUserData.Name;
           Messages?.Clear();
           Messages = new ObservableCollection<MessageModel>(ChatUser.Messages);
        }
    }
}
