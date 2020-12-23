using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ChatUi.Screens;

namespace ChatUi.Screens
{
    /// <summary>
    /// Логика взаимодействия для ScreenFriendProfile.xaml
    /// </summary>
    public partial class ScreenFriendProfile : UserControl
    {
        public ScreenFriendProfile()
        {
            InitializeComponent();
        }

        private void CloseProfileFriend_Click(object sender, RoutedEventArgs e)
        {
            ProfileFriend.Visibility = Visibility.Collapsed;
        }
    }
}
