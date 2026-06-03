using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Infrastructure.Database.Repositories;
using MessengerDesktop.Infrastructure.DataTransferObjects;
using MessengerDesktop.Infrastructure.Factories;
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
    public partial class MainViewModel : ObservableObject
    {

        #region Fields
        private readonly ChatUserRepository chatUserRepository = new();
        private ChoiceDialogPlaceholder_VM choiceDialogPlaceholder_VM = new ChoiceDialogPlaceholder_VM();
        private DialogPanel_VM DialogPanel_VM = new DialogPanel_VM();
        #endregion

        #region Properties
        [ObservableProperty]
        private ObservableCollection<ChatUserData> _userList = new();

        [ObservableProperty]
        private object _dialogPanel;

        [ObservableProperty]
        private ChatUserData _selectUserDialog;
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


            var userList = chatUserRepository.FindAll()
                .Select(entity => ChatUserDataFactory.CreateChatUser(
                    entity.User.Name, 
                    entity.Messages.LastOrDefault()?.Message ?? "message_not_found",
                    entity.Id))
                .ToList();
            UserList = new ObservableCollection<ChatUserData>(userList);
            
        }
        #endregion

        #region Methods
        partial void OnSelectUserDialogChanged(ChatUserData? value)
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
        #endregion
    }
}
