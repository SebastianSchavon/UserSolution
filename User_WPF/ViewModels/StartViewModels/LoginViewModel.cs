using Newtonsoft.Json;
using User_WPF.APIService;
using User_WPF.Core.Base;
using User_WPF.Core.Commands;
using User_WPF.Entities;
using User_WPF.Helpers;
using User_WPF.Models.Users;

namespace User_WPF.ViewModels.StartViewModels;

internal class LoginViewModel : ObservableObject
{
    /// <summary>
    /// RelayCommand recieves class method as Action. Fire from view.
    /// </summary>
    public RelayCommand LoginButtonCommand { get; set; }

    private string responseText;
    public string? ResponseText
    {
        get { return responseText; }
        set
        {
            responseText = value;
            OnPropertyChanged();
        }
    }

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

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            ResponseText = content;
        }
        else
        {
            var user = JsonConvert.DeserializeObject<User>(content);

            SettingsManager.StoreAuthenticatedUserSettings(user);

            WindowManager.OpenMainView();
            WindowManager.CloseWindow("startView");
        }

    }

}
