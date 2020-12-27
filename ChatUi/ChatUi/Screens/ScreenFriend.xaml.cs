using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.TransmissionModels;
using ClientToServerApi.Models.ViewModels;
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
    /// Логика взаимодействия для ScreenFriend.xaml
    /// </summary>
    public partial class ScreenFriend : UserControl
    {
        List<AllUsersView> usersViews = new List<AllUsersView>();
        List<AllUsersView> friendViews = new List<AllUsersView>();
        static Serializer serializer = new Serializer();
        private readonly ClientServerService clientServerService_;
        public ScreenFriend()
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            clientServerService_.AddListener(ListenerType.UserListListener, UsersList);
            clientServerService_.AddListener(ListenerType.FriendListListener, UsersFriendListener);
            ScreenListBoxUsers.ListBoxFriend.ItemsSource = friendViews;
        }

        private void MyFriend_Click(object sender, RoutedEventArgs e)
        {
            ScreenListBoxUsers.ListBoxFriend.ItemsSource = friendViews;
        }

        private void FindFriend_Click(object sender, RoutedEventArgs e)
        {
            ScreenListBoxUsers.ListBoxFriend.ItemsSource = usersViews;
        }

        private void SortFriend_Click(object sender, RoutedEventArgs e)
        {
            //in developing
        }

        public void ViewFriend()
        {
            ScreenListBoxUsers.ListBoxFriend.ItemsSource = friendViews;
        }

        public void UsersFriendListener(OperationResultInfo operationResultInfo)
        {
            if (operationResultInfo.JsonData != null)
            {
                var userListReceiveModels = serializer.Deserialize<List<UserListReceiveModel>>(operationResultInfo.JsonData as string);
                foreach (var el in userListReceiveModels)
                {
                    AllUsersView usersView = new AllUsersView();
                    usersView.Id = el.Id;
                    usersView.UserName = el.UserName;
                    usersView.Picture = el.Picture;
                    if (el.IsOnline)
                    {
                        usersView.IsOnline = "Online";
                    }
                    else
                    {
                        usersView.IsOnline = "Offline";
                    }
                    friendViews.Add(usersView);
                }
            }
            else if (string.IsNullOrEmpty(operationResultInfo.ErrorInfo))
            {
                MessageBox.Show("у вас нет друзей!");
            } else
            {
                MessageBox.Show(operationResultInfo.ErrorInfo);
            }
        }

        public void UsersList(OperationResultInfo operationResultInfo)
        {
            if (operationResultInfo.JsonData != null)
            {
                var userListReceiveModels = serializer.Deserialize<List<UserListReceiveModel>>(operationResultInfo.JsonData as string);
                foreach (var el in userListReceiveModels)
                {
                    AllUsersView usersView = new AllUsersView();
                    usersView.Id = el.Id;
                    usersView.UserName = el.UserName;
                    usersView.Picture = el.Picture;
                    if (el.IsOnline)
                    {
                        usersView.IsOnline = "Online";
                    }
                    else
                    {
                        usersView.IsOnline = "Offline";
                    }
                    usersViews.Add(usersView);
                }
            }
            else if (string.IsNullOrEmpty(operationResultInfo.ErrorInfo))
            {
                MessageBox.Show("нет зарегистрированных пользоателей!");
            } else
            {
                MessageBox.Show(operationResultInfo.ErrorInfo);
            }
        }
    }
}
