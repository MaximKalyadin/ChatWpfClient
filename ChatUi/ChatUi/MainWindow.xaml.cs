using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.ResponseModels.UserModel;
using ClientToServerApi.Models.TransmissionModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatUi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsFitToWidth { set; get; }

        public UserReceiveModel userReceiveModel { get; set; }
        public UserResponseModel UserResponseModel { get; set; }
        public readonly ClientServerService clientServerService_;
        static Serializer serializer = new Serializer();
        public MainWindow(UserReceiveModel model)
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            IsFitToWidth = false;
            UserResponseModel userResponseModel = new UserResponseModel();
            userResponseModel.UserName = model.UserName;
            userResponseModel.SecondName = model.SecondName;
            userResponseModel.File = model.File;
            userResponseModel.PhoneNumber = model.PhoneNumber;
            userResponseModel.Name = model.Name;
            userResponseModel.IsOnline = model.IsOnline;
            userResponseModel.Id = model.Id;
            userResponseModel.Country = model.Country;
            userResponseModel.City = model.City;
            userResponseModel.Gender = model.Gender;
            userReceiveModel = model;
            UserResponseModel = userResponseModel;
        }

        private void CompressButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void FitToWidthButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsFitToWidth)
            {
                SystemCommands.MaximizeWindow(this);
                (this.FitToWidthButton.Content as Image).Source = new BitmapImage(new Uri(@"/ChatUi;component/Assets/SystemButtons/collapse32px.png", UriKind.Relative));
                IsFitToWidth = true;
            }
            else
            {
                SystemCommands.RestoreWindow(this);
                (this.FitToWidthButton.Content as Image).Source = new BitmapImage(new Uri(@"/ChatUi;component/Assets/SystemButtons/fitToWidth_32px.png", UriKind.Relative));
                IsFitToWidth = false;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
            
        }

        public void Mouse_Click(object sender, RoutedEventArgs e)
        {
            Friend.Visibility = Visibility.Collapsed;
            Settings.Visibility = Visibility.Collapsed;
            Chat.Visibility = Visibility.Visible;
            Chat.StackPanelSearch.Visibility = Visibility.Visible;
            Chat.ChatList.Visibility = Visibility.Collapsed;
            Chat.Notification.Visibility = Visibility.Collapsed;
            Chat.MyProfile.Visibility = Visibility.Visible;
        }
        
        public void Menu_ListBoxSelectedIndex(object sender, EventArgs e)
        {
            switch (Menu.SelectedIndex)
            {
                case 0:
                    //chat
                    Friend.Visibility = Visibility.Collapsed;
                    Settings.Visibility = Visibility.Collapsed;
                    Chat.Visibility = Visibility.Visible;
                    Chat.StackPanelSearch.Visibility = Visibility.Visible;
                    Chat.ChatList.Visibility = Visibility.Visible;
                    Chat.Notification.Visibility = Visibility.Collapsed;
                    Chat.MyProfile.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    //friend
                    Friend.Visibility = Visibility.Visible;
                    Settings.Visibility = Visibility.Collapsed;
                    Chat.Visibility = Visibility.Collapsed;
                    Chat.StackPanelSearch.Visibility = Visibility.Collapsed;
                    Chat.ChatList.Visibility = Visibility.Collapsed;
                    Chat.Notification.Visibility = Visibility.Collapsed;
                    Chat.MyProfile.Visibility = Visibility.Collapsed;

                    clientServerService_.SendAsync(new ClientOperationMessage()
                    {
                        Operation = ClientOperations.GetUsers,
                        JsonData = serializer.Serialize(new UserPaginationResponseModel()
                        {
                            UserId = userReceiveModel.Id
                        })
                    });

                    clientServerService_.SendAsync(new ClientOperationMessage()
                    {
                        Operation = ClientOperations.GetFriends,
                        JsonData = serializer.Serialize(new UserPaginationResponseModel()
                        {
                            UserId = userReceiveModel.Id
                        })
                    });
                    Friend.ViewFriend();


                    break;
                case 2:
                    //notification
                    Friend.Visibility = Visibility.Collapsed;
                    Settings.Visibility = Visibility.Collapsed;
                    Chat.Visibility = Visibility.Visible;
                    Chat.StackPanelSearch.Visibility = Visibility.Collapsed;
                    Chat.ChatList.Visibility = Visibility.Collapsed;
                    Chat.Notification.Visibility = Visibility.Visible;
                    Chat.MyProfile.Visibility = Visibility.Collapsed;

                    clientServerService_.SendAsync(new ClientOperationMessage()
                    {
                        Operation = ClientOperations.GetNotifications,
                        JsonData = serializer.Serialize(new UserPaginationResponseModel()
                        {
                            UserId = userReceiveModel.Id
                        })
                    });
                    break;
                case 3:
                    //settings
                    Friend.Visibility = Visibility.Collapsed;
                    Chat.Visibility = Visibility.Collapsed;
                    Chat.StackPanelSearch.Visibility = Visibility.Collapsed;
                    Chat.ChatList.Visibility = Visibility.Collapsed;
                    Chat.Notification.Visibility = Visibility.Collapsed;
                    Chat.MyProfile.Visibility = Visibility.Collapsed;

                    Settings.Visibility = Visibility.Visible;
                    if (Settings.IsChange == false)
                    {
                        Settings._userReceiveModel = userReceiveModel;
                        Settings._userResponseModel = UserResponseModel;
                        Settings.LoadedInfoProfile(userReceiveModel);
                    }
                    break;
            }
        }
    }
}
