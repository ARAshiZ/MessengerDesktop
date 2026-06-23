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
    public partial class MainViewModel : ObservableObject
    {

        #region Fields
        public MainPanelViewModel MainPanelVM;
        public AuthPanelViewModel AuthPanelVM;
        #endregion

        #region Properties
        [ObservableProperty]
        private object _viewPanel;
        #endregion

        #region Constructor
        public MainViewModel(MainPanelViewModel _mainPanelVM, AuthPanelViewModel _authPanelVM)
        {
            MainPanelVM = _mainPanelVM;
            AuthPanelVM = _authPanelVM;
            ViewPanel = AuthPanelVM;
        }
        #endregion

        #region Methods
        #endregion
    }
}
