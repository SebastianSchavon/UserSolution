using System.Collections.Generic;

using User_WPF.APIService;
using User_WPF.Core.Base;
using User_WPF.Entities;

namespace User_WPF.ViewModels.MainViewModels;

internal class MainViewModel : ObservableObject
{
    public IUserService _userService { get; set; }

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
        GetAllUsers();
    }


    private async void GetAllUsers()
    {

    }
}
