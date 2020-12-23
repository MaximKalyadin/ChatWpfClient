using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            ClientServerService.SetApiConfig("127.0.0.1", "8668");
            var authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
        }
    }
}
