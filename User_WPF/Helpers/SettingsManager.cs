using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_WPF.Entities;

namespace User_WPF.Helpers
{
    public static class SettingsManager
    {
        public static void CheckToken()
        {
            if (Properties.Settings.Default.Token != "")
                WindowManager.OpenMainView();
            else
                WindowManager.OpenStartView();
        }

        public static void StoreAuthenticatedUserSettings(User user)
        {
            Properties.Settings.Default.Username = user.Username;
            Properties.Settings.Default.Token = user.Token;
            Properties.Settings.Default.Save();
        }

        public static void DeleteAuthenticatedUserSettings()
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.Save();
        }
    }
}
