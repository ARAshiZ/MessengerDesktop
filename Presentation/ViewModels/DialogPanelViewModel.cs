using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Infrastructure.Database.Repositories;
using MessengerDesktop.Infrastructure.Messengers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDesktop.Presentation.ViewModels
{
    public partial class DialogPanelViewModel : ObservableObject
    {
        private readonly IRepository<MessageModel> messageRepository;
        private readonly IRepository<ChatUserModel> chatUserRepository;

        private int chatUserId = 0;

        public DialogPanelViewModel(IRepository<ChatUserModel> chatUserRepo, IRepository<MessageModel> msgRepo)
        {
            messageRepository = msgRepo;
            chatUserRepository = chatUserRepo;
        }

        [ObservableProperty]
        private ObservableCollection<MessageModel> _messages;

        [ObservableProperty]
        private string _messageText = string.Empty;

        [ObservableProperty]
        private string _name = string.Empty;

        [RelayCommand]
        private async Task Send()
        {
            if (!string.IsNullOrWhiteSpace(MessageText)) 
            {
                var msg = new MessageModel();
                msg.ChatUserID = chatUserId;
                msg.Message = MessageText;
                await messageRepository.Add(msg);
                Messages.Add(msg);
                WeakReferenceMessenger.Default.Send(new LastMessageMessage(chatUserId, MessageText));
                MessageText = string.Empty;

            }
        }

        public async Task LoadChatUser(ChatUserViewModel ChatUserData)
        {
           var ChatUser = await chatUserRepository.FindByID(ChatUserData.ChatUserId);
           chatUserId = ChatUser.Id;
           Name = ChatUserData.ChatUserName;
           Messages?.Clear();
           Messages = new ObservableCollection<MessageModel>(ChatUser.Messages);
        }
    }
}
