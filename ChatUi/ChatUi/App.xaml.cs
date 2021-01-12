using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ClientToServerApi;

namespace ChatUi
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            ClientServerService.SetApiConfig("25.68.135.116", "8668");
            var authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
		}

	}
}
