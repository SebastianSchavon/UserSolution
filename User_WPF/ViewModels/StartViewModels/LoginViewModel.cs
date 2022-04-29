using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_WPF.APIService;
using User_WPF.Core.Base;
using User_WPF.Core.Commands;
using User_WPF.Entities;
using User_WPF.Models.Users;

namespace User_WPF.ViewModels.StartViewModels;

internal class LoginViewModel : ObservableObject
{
    /// <summary>
    /// RelayCommand recieves class method as Action. Fire from view.
    /// </summary>
    public RelayCommand LoginButtonCommand { get; set; }
    

    public LoginViewModel()
    {
        LoginButtonCommand = new RelayCommand(o =>
        {
            Login(this);
        });

        
    }

    private async void Login(object parameter)
    {
        var response = await new UserService().Authenticate(
            LoginButtonCommand.ParameterValue as AuthenticateRequest);
        
        var content = await response.Content.ReadAsStringAsync();

        var user = JsonConvert.DeserializeObject<User>(content);

        SaveUserSettings(user);

        Console.WriteLine();

    }

    
    private void SaveUserSettings(User user)
    {
        Properties.Settings.Default.Username = user.Username;
        Properties.Settings.Default.Token = user.Token;
        Properties.Settings.Default.Save();
    }
}
