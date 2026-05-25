using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MessengerDesktop.Core.Models;
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

            UserModel user1 = new UserModel();
            user1.Id = 0;
            user1.Name = "TestUser1";
            UserModel user2 = new UserModel();
            user2.Id = 0;
            user2.Name = "TestUser2";
            ChatUserModel chatUser1 = new ChatUserModel();
            ChatUserModel chatUser2 = new ChatUserModel();

            MessageModel message1 = new MessageModel();
            message1.Send = false;
            message1.Message = "hello!";

            MessageModel message2 = new MessageModel();
            message2.Send = true;
            message2.Message = "Hi!";

            MessageModel message3 = new MessageModel();
            message3.Send = false;
            message3.Message = "Good night.";

            MessageModel message4 = new MessageModel();
            message4.Send = true;
            message4.Message = "bye.";

            chatUser1.User = user1;
            chatUser1.Messages = new ObservableCollection<MessageModel>() {message1, message2};
            chatUser1.LastMessage = chatUser1.Messages.Last();

            chatUser2.User = user2;
            chatUser2.Messages = new ObservableCollection<MessageModel>() { message3, message4 };
            chatUser2.LastMessage = chatUser2.Messages.Last();
            UserList.Add(chatUser1);
            UserList.Add(chatUser2);
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
