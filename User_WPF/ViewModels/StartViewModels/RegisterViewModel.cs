using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_WPF.APIService;
using User_WPF.Core.Base;
using User_WPF.Core.Commands;
using User_WPF.Models.Users;

namespace User_WPF.ViewModels.StartViewModels
{
    internal class RegisterViewModel : ObservableObject
    {
        /// <summary>
        /// RelayCommand recieves class method as Action. Fire from view.
        /// </summary>
        public RelayCommand RegisterButtonCommand { get; set; }

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

        public RegisterViewModel()
        {
            RegisterButtonCommand = new RelayCommand(o =>
            {
                Register(this);
            });
        }

        private async void Register(object parameter)
        {
            var response = await new UserService().Register(
                RegisterButtonCommand.ParameterValue as RegisterRequest);

            var content = await response.Content.ReadAsStringAsync();

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                ResponseText = content;
            }
            else
            {
                var message = JObject.Parse(content);

                ResponseText = (string)message["message"];
            }

        }
    }
}
