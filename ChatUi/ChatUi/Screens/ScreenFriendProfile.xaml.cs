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
using ClientToServerApi.Models.ViewModels;

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

        public void ViewFriend(FriendProfileView profileView)
        {
            if(profileView.Name != null && profileView.SecondName != null)
            {
                FriendNameSurnameTextblock.Text = profileView.Name + " " + profileView.SecondName;
            }
            if (profileView.City != null && profileView.Country != null)
            {
                FriendCountryCityTextBlock.Text = profileView.Country + " " + profileView.City;
            }
            if (profileView.Phone != null)
            {
                FriendPhoneRun.Text = profileView.Phone;
            }
            if (profileView.UserName != null)
            {
                FriendNickRun.Text = profileView.UserName;
            }
            ImageFriend.IsOnline = profileView.IsOnline;
        }

        private void CloseProfileFriend_Click(object sender, RoutedEventArgs e)
        {
            ProfileFriend.Visibility = Visibility.Collapsed;
        }
    }
}
