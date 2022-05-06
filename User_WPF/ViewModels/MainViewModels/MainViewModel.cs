using Newtonsoft.Json;
using System.Collections.Generic;
using User_WPF.APIService;
using User_WPF.Core.Base;
using User_WPF.Core.Commands;
using User_WPF.Entities;
using User_WPF.Helpers;
using User_WPF.Models.Users;

namespace User_WPF.ViewModels.MainViewModels;

internal class MainViewModel : ObservableObject
{
    public RelayCommand LogoutButtonCommand { get; set; }

    public List<UserResponse> users { get; set; }
    public List<UserResponse> Users
    {
        get { return users; }
        set
        {
            users = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        
        LogoutButtonCommand = new RelayCommand(o =>
        {
            Logout();
        });

        GetAllUsers();
    }

    private void Logout()
    {
        SettingsManager.DeleteAuthenticatedUserSettings();
        WindowManager.OpenStartView();
        WindowManager.CloseWindow("mainView");
        
    }

    private async void GetAllUsers()
    {
        var response = await new UserService().GetAll();

        var content = await response.Content.ReadAsStringAsync();

        var allUsers = JsonConvert.DeserializeObject<List<UserResponse>>(content);
        Users = allUsers;
    }
}
