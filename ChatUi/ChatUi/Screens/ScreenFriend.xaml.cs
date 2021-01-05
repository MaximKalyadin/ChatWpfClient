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
        public List<AllUsersView> usersViews = new List<AllUsersView>();
        public List<AllUsersView> friendViews = new List<AllUsersView>();
        public UserReceiveModel _userReceiveModel { get; set; }
        static Serializer serializer = new Serializer();
        private readonly ClientServerService clientServerService_;
        public ScreenFriend()
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            clientServerService_.AddListener(ListenerType.UserListListener, UsersList);
            clientServerService_.AddListener(ListenerType.FriendListListener, UsersFriendListener);
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = friendViews;
        }

        private void MyFriend_Click(object sender, RoutedEventArgs e)
        {
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = friendViews;
            ScreenListBoxFriends.Visibility = Visibility.Visible;
            ScreenListBoxUsers.Visibility = Visibility.Collapsed;
        }

        private void FindFriend_Click(object sender, RoutedEventArgs e)
        {
            ScreenListBoxUsers.ListBoxUsers.ItemsSource = usersViews;
            ScreenListBoxUsers.Visibility = Visibility.Visible;
            ScreenListBoxFriends.Visibility = Visibility.Collapsed;
        }

        private void SortFriend_Click(object sender, RoutedEventArgs e)
        {
            //in developing
        }

        public void ViewFriend()
        {
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = friendViews;
            ScreenListBoxFriends.Visibility = Visibility.Visible;
            ScreenListBoxUsers.Visibility = Visibility.Collapsed;
        }

        public void UsersFriendListener(OperationResultInfo operationResultInfo)
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                try
                {
                    if (operationResultInfo.JsonData != null)
                    {
                        var userListReceiveModels = serializer.Deserialize<UserListReceiveModel>(operationResultInfo.JsonData as string);
                        AllUsersView usersView = new AllUsersView();
                        usersView.Id = userListReceiveModels.UserId;
                        usersView.UserName = userListReceiveModels.UserName;
                        usersView.Picture = userListReceiveModels.Picture;
                        if (userListReceiveModels.IsOnline)
                        {
                            usersView.IsOnline = "Online";
                            usersView.Online = true;
                        }
                        else
                        {
                            usersView.IsOnline = "Offline";
                            usersView.Online = false;
                        }
                        int f = 0;
                        foreach(var el in usersViews)
                        {
                            if (el.Id == usersView.Id)
                            {
                                el.IsOnline = usersView.IsOnline;
                                el.Online = usersView.Online;
                                f = 1;
                            }
                        }
                        if (f == 0)
                        {
                            friendViews.Add(usersView);
                        }
                    }
                }
                catch
                {
                    if (operationResultInfo.JsonData != null)
                    {
                        var userListReceiveModels = serializer.Deserialize<List<UserListReceiveModel>>(operationResultInfo.JsonData as string);
                        foreach (var el in userListReceiveModels)
                        {
                            AllUsersView usersView = new AllUsersView();
                            usersView.Id = el.UserId;
                            usersView.UserName = el.UserName;
                            usersView.Picture = el.Picture;
                            if (el.IsOnline)
                            {
                                usersView.IsOnline = "Online";
                                usersView.Online = true;
                            }
                            else
                            {
                                usersView.IsOnline = "Offline";
                                usersView.Online = false;
                            }
                            friendViews.Add(usersView);
                        }
                    }
                    else if (string.IsNullOrEmpty(operationResultInfo.ErrorInfo))
                    {
                        MessageBox.Show("у вас нет друзей!");
                    }
                    else
                    {
                        MessageBox.Show(operationResultInfo.ErrorInfo);
                    }
                }
                ScreenListBoxFriends._friends = friendViews;
                ScreenListBoxFriends._userReceiveModel = _userReceiveModel;
            });
        }

        public void UsersList(OperationResultInfo operationResultInfo)
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                if (operationResultInfo.JsonData != null)
                {
                    var userListReceiveModels = serializer.Deserialize<List<UserListReceiveModel>>(operationResultInfo.JsonData as string);
                    foreach (var el in userListReceiveModels)
                    {
                        AllUsersView usersView = new AllUsersView();
                        usersView.Id = el.UserId;
                        usersView.UserName = el.UserName;
                        usersView.Picture = el.Picture;
                        if (el.IsOnline)
                        {
                            usersView.IsOnline = "Online";
                            usersView.Online = true;
                        }
                        else
                        {
                            usersView.IsOnline = "Offline";
                            usersView.Online = false;
                        }
                        usersViews.Add(usersView);
                    }
                    ScreenListBoxUsers._users = usersViews;
                    ScreenListBoxUsers._userReceiveModel = _userReceiveModel;
                }
                else if (string.IsNullOrEmpty(operationResultInfo.ErrorInfo))
                {
                    MessageBox.Show("нет зарегистрированных пользоателей!");
                }
                else
                {
                    MessageBox.Show(operationResultInfo.ErrorInfo);
                }
            });
        }

        private void ScreenListBoxFriends_ListBoxSelectionChange(object sender, EventArgs e)
        {
            if (ScreenListBoxFriends.SelectedIndexItem != null)
            {
                friendViews.RemoveAt((int)ScreenListBoxFriends.SelectedIndexItem);
                ScreenListBoxFriends.ListBoxFriend.ItemsSource = friendViews;
            }
        }
    }
}
