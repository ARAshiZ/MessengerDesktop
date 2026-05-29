using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessengerDesktop.Core.Models;
using MessengerDesktop.Infrastructure.Database.Repositories;
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
        private readonly UserRepository userRepository = new();
        private readonly ChatUserRepository chatUserRepository = new();
        private ChoiceDialogPlaceholder_VM choiceDialogPlaceholder_VM = new ChoiceDialogPlaceholder_VM();
        private DialogPanel_VM DialogPanel_VM = new DialogPanel_VM();
        #endregion

        #region Properties
        [ObservableProperty]
        private ObservableCollection<ChatUserModel> _userList = new();

        [ObservableProperty]
        private object _dialogPanel;

        [ObservableProperty]
        private ChatUserModel _selectUserDialog;
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

            //var user1 = new UserModel();
            //user1.Name = "TestUser1";
            //userRepository.Add(user1);

            //var user2 = new UserModel();
            //user2.Name = "TestUser2";
            //userRepository.Add(user2);

            //var chatUser1 = new ChatUserModel();
            //chatUser1.User = user1;
            //chatUser1.Messages = null;
            //chatUserRepository.Add(chatUser1);

            //var chatUser2 = new ChatUserModel();
            //chatUser2.User = user2;
            //chatUser2.Messages = null;
            //chatUserRepository.Add(chatUser2);

            foreach (var chatUser in chatUserRepository.FindAll()) 
            {
                UserList.Add(chatUser);
            }
            
        }
        #endregion

        #region Methods
        partial void OnSelectUserDialogChanged(ChatUserModel? value)
        {
            if (value is null)
            {
                DialogPanel = choiceDialogPlaceholder_VM;
            }
            else
            {
                DialogPanel_VM.SetChatUserModel(value);
                DialogPanel = DialogPanel_VM;
            }
        }
        #endregion
    }
}
