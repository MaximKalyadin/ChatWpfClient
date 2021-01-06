using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.TransmissionModels;
using ClientToServerApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            clientServerService_.AddListener(ListenerType.FriendListDeleteListener, UserDeleteListener);
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = friendViews;
        }

        private void MyFriend_Click(object sender, RoutedEventArgs e)
        {
            Itemsource();
            SendDataInList();
            ScreenListBoxFriends.Visibility = Visibility.Visible;
            ScreenListBoxUsers.Visibility = Visibility.Collapsed;
        }

        private void FindFriend_Click(object sender, RoutedEventArgs e)
        {
            Itemsource();
            SendDataInList();
            ScreenListBoxUsers.Visibility = Visibility.Visible;
            ScreenListBoxFriends.Visibility = Visibility.Collapsed;
        }

        private void SortFriend_Click(object sender, RoutedEventArgs e)
        {
            //in developing
        }
        public void Itemsource()
        {
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = null;
            ScreenListBoxUsers.ListBoxUsers.ItemsSource = null;
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = friendViews;
            ScreenListBoxUsers.ListBoxUsers.ItemsSource = usersViews;
        }

        public void SendDataInList()
        {
            ScreenListBoxUsers._userReceiveModel = _userReceiveModel;
            ScreenListBoxFriends._userReceiveModel = _userReceiveModel;
            ScreenListBoxFriends._friends = friendViews;
            ScreenListBoxUsers._users = usersViews;
        }

        public void ViewFriend()
        {
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = friendViews;
            ScreenListBoxFriends.Visibility = Visibility.Visible;
            ScreenListBoxUsers.Visibility = Visibility.Collapsed;
            Itemsource();
            SendDataInList();
        }

        public void UserDeleteListener(OperationResultInfo operationResultInfo)
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                if (operationResultInfo.JsonData != null)
                {
                    var userListReceiveModels = serializer.Deserialize<UserListReceiveModel>(operationResultInfo.JsonData as string);
                    foreach (var el in friendViews)
                    {
                        if (el.Id == userListReceiveModels.UserId)
                        {
                            friendViews.Remove(el);
                        }
                    }
                }
                Itemsource();
                SendDataInList();
            });
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
                        foreach(var el in friendViews)
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
                Itemsource();
                SendDataInList();
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
                    
                }
                else if (string.IsNullOrEmpty(operationResultInfo.ErrorInfo))
                {
                    MessageBox.Show("нет зарегистрированных пользоателей!");
                }
                else
                {
                    MessageBox.Show(operationResultInfo.ErrorInfo);
                }
                Itemsource();
                SendDataInList();
            });
        }

        private void ScreenListBoxFriends_ListBoxSelectionChange(object sender, EventArgs e)
        {
            friendViews = ScreenListBoxFriends._friends;
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = null;
            ScreenListBoxFriends.ListBoxFriend.ItemsSource = friendViews;
        }
    }
}
