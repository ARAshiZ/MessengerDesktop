using CommunityToolkit.Mvvm.ComponentModel;
using MessengerDesktop.Models;
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

namespace MessengerDesktop.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        #region Fields
        private object choiceDialogPlaceholder_VM = new ChoiceDialogPlaceholder_VM();
        #endregion

        #region Properties
        [ObservableProperty]
        private ObservableCollection<ChatUserModel> _userList = new();

        [ObservableProperty]
        private object _dialogPanel;

        [ObservableProperty]
        private ChatUserModel _selectUserDialog;
        #endregion

        #region Constructor
        public MainViewModel() 
        {
            DialogPanel = new ChoiceDialogPlaceholder_VM();
            UserModel user1 = new UserModel();
            user1.Id = 0;
            user1.Name = "TestUser1";
            UserModel user2 = new UserModel();
            user2.Id = 0;
            user2.Name = "TestUser2";
            ChatUserModel chatUser1 = new ChatUserModel();
            ChatUserModel chatUser2 = new ChatUserModel();
            chatUser1.User = user1;
            chatUser1.LastMessage = "Hello!";
            chatUser2.User = user2;
            chatUser2.LastMessage = "Bye.";
            UserList.Add(chatUser1);
            UserList.Add(chatUser2);
        }
        #endregion

        #region Methods
        partial void OnSelectUserDialogChanged(ChatUserModel chatUserModel)
        {
            DialogPanel = new DialogPanel_VM(chatUserModel);
        }
        #endregion
    }
}
