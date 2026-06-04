using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Infrastructure.Database.Repositories;
using MessengerDesktop.Infrastructure.Factories;
using MessengerDesktop.Infrastructure.Messengers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace MessengerDesktop.Presentation.ViewModels
{
    public partial class MainViewModel : ObservableObject, IRecipient<LastMessageMessage>
    {

        #region Fields
        private readonly ChatUserRepository chatUserRepository = new();
        private ChoiceDialogPlaceholder_VM choiceDialogPlaceholder_VM = new ChoiceDialogPlaceholder_VM();
        private DialogPanel_VM DialogPanel_VM = new DialogPanel_VM();
        #endregion

        #region Properties
        [ObservableProperty]
        private ObservableCollection<ChatUserViewModel> _userList = new();

        [ObservableProperty]
        private object _dialogPanel;

        [ObservableProperty]
        private ChatUserViewModel _selectUserDialog;
        #endregion

        #region Commands
        [RelayCommand]
        private void Escape() 
        {
            SelectUserDialog = null;
        }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            DialogPanel = choiceDialogPlaceholder_VM;
            WeakReferenceMessenger.Default.Register<LastMessageMessage>(this, (r, m) => Receive(m));

                var userList = chatUserRepository.FindAll()
                .Select(entity => ChatUserViewModelFactory.CreateChatUser(
                    entity.User.Name,
                    entity.Id,
                    entity.Messages.LastOrDefault()?.Message ?? "message_not_found"))
                .ToList();
            UserList = new ObservableCollection<ChatUserViewModel>(userList);
            
        }
        #endregion

        #region Methods
        partial void OnSelectUserDialogChanged(ChatUserViewModel? value)
        {
            if (value is null)
            {
                DialogPanel = choiceDialogPlaceholder_VM;
            }
            else
            {
                DialogPanel_VM.LoadChatUser(value);
                DialogPanel = DialogPanel_VM;
            }
        }

        public void Receive(LastMessageMessage message)
        {
            var ChatUser = UserList.First(x => x.ChatUserId == message.Id);
            if (ChatUser != null)
            {
                ChatUser.LastMessage = message.lastMessage;
            }
        }
        #endregion
    }
}
