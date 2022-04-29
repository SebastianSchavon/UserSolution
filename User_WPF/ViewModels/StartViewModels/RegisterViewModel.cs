using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_WPF.Core.Base;
using User_WPF.Core.Commands;

namespace User_WPF.ViewModels.StartViewModels
{
    internal class RegisterViewModel : ObservableObject
    {
        /// <summary>
        /// RelayCommand recieves class method as Action. Fire from view.
        /// </summary>
        public RelayCommand RegisterButtonCommand { get; set; }

        public RegisterViewModel()
        {
            RegisterButtonCommand = new RelayCommand(o =>
            {
                Register(this);
            });
        }

        private void Register(object parameter)
        {
            //var api = new APICommunication.ApiUser();
            //var response = api.Register(parameter as RegisterRequest);

            //if (response.ReasonPhrase == "OK")
            //    ResponseText = $"{response.ReasonPhrase} ";
            //else
            //    ResponseText = $"ERROR: {response.ReasonPhrase}";
        }
    }
}
