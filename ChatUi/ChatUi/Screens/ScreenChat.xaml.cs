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

namespace ChatUi.Screens
{
    /// <summary>
    /// Логика взаимодействия для ScreenChat.xaml
    /// </summary>
    public partial class ScreenChat : UserControl
    {
        public ScreenChat()
        {
            InitializeComponent();
        }

        private void ButtonMore_MouseEnter(object sender, MouseEventArgs e)
        {
            this.PopupMore.IsOpen = true;
        }

        private void PopupBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            this.PopupMore.IsOpen = false;
        }

        private void OpenProfileFriend_Click(object sender, RoutedEventArgs e)
        {
            FriendProfile.Visibility = Visibility.Visible;
            FriendProfile.ProfileFriend.Visibility = Visibility.Visible;
        }

        public void LiatBoxChat_ListBoxSelectionChange(object sender, EventArgs e)
        {
            if (ChatList.SelectedIndex >= 0)
            {
                BorderSendMassege.Visibility = Visibility.Visible;
            }
        }

        private void CloseChat_Click(object sender, RoutedEventArgs e)
        {
            BorderSendMassege.Visibility = Visibility.Collapsed;
        }

    }
}
