using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using User_WPF.Views.MainViews;

namespace User_WPF.Helpers
{
    public static class WindowManager
    {
        public static void CloseWindow(string viewTitle)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Name.Contains(viewTitle))
                    window.Close();
                
            }
        }

        public static void OpenMainView()
        {
            MainView mainView = new MainView();
            mainView.Show();
        }
    }
}
