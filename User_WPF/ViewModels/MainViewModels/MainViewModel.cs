using System.Collections.Generic;

using User_WPF.APIService;
using User_WPF.Core.Base;
using User_WPF.Core.Commands;
using User_WPF.Entities;
using User_WPF.Helpers;

namespace User_WPF.ViewModels.MainViewModels;

internal class MainViewModel : ObservableObject
{
    public RelayCommand LogoutButtonCommand { get; set; }

    public List<User> Users { get; set; }
    public List<User> _Users
    {
        get { return Users; }
        set
        {
            Users = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        LogoutButtonCommand = new RelayCommand(o =>
        {
            Logout();
        });
    }

    private void Logout()
    {
        SettingsManager.DeleteAuthenticatedUserSettings();
        WindowManager.OpenStartView();
        WindowManager.CloseWindow("mainView");
        
    }

    private async void GetAllUsers()
    {

    }
}
