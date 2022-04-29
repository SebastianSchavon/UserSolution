using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_WPF.Core.Base;
using User_WPF.Core.Commands;
using User_WPF.Views.MainViews;

namespace User_WPF.ViewModels.StartViewModels
{
    internal class StartViewModel : ObservableObject
    {
        /// <summary>
        /// RelayCommands to change _ActiveView value from StartView
        /// ActiveView controls current displayed UserControl in StartView-Window
        /// </summary>
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand RegisterViewCommand { get; set; }

        public LoginViewModel _LoginViewModel { get; set; }
        public RegisterViewModel _RegisterViewModel { get; set; }

        // binds with content of StartViews content control
        private object _ActiveView;

        public object ActiveView
        {
            get { return _ActiveView; }
            set
            {
                _ActiveView = value;
                OnPropertyChanged();
            }
        }

        public StartViewModel()
        {
            _LoginViewModel = new LoginViewModel();
            _RegisterViewModel = new RegisterViewModel();

            
            ActiveView = _LoginViewModel;

            LoginViewCommand = new RelayCommand(o =>
            {
                ActiveView = _LoginViewModel;
            });

            RegisterViewCommand = new RelayCommand(o =>
            {
                ActiveView = _RegisterViewModel;
            });

            // Dont ref views in viewmodel, needs to change

        }

    }
}
