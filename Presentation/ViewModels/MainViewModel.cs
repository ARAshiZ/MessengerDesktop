using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Infrastructure.Database.Repositories;
using MessengerDesktop.Infrastructure.Messengers;
using MessengerDesktop.Presentation.Views;
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
        private readonly IRepository<ChatUserModel> _chatUserRepository;
        public DialogPlaceholderViewModel DialogPlaceholder_VM;
        public DialogPanelViewModel DialogPanel_VM;
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
        public MainViewModel(
            DialogPanelViewModel _dialogPanel, 
            DialogPlaceholderViewModel _dialogPlaceholder,
            IRepository<ChatUserModel> chatUserRepo)
        {
            _chatUserRepository = chatUserRepo;
            DialogPlaceholder_VM = _dialogPlaceholder;
            DialogPanel_VM = _dialogPanel;
            DialogPanel = DialogPlaceholder_VM;
            WeakReferenceMessenger.Default.Register<LastMessageMessage>(this, (r, m) => Receive(m));
            GetUserList();
            
        }
        #endregion

        #region Methods
        private async void GetUserList()
        {
            var entites = await _chatUserRepository.FindAll();
            var userList = entites
                .Select(entity => new ChatUserViewModel(
                    entity.User.Name,
                    entity.Id,
                    entity.Messages.LastOrDefault()?.Message ?? "message_not_found"))
                .ToList();
            UserList = new ObservableCollection<ChatUserViewModel>(userList);
        }

        partial void OnSelectUserDialogChanged(ChatUserViewModel? value)
        {
            if (value is null)
            {
                DialogPanel = DialogPlaceholder_VM;
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
