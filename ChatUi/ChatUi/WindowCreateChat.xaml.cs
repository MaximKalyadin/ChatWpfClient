using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.ResponseModel.ChatModels;
using ClientToServerApi.Models.ResponseModels.ChatModels;
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

namespace ChatUi
{
    /// <summary>
    /// Логика взаимодействия для WindowCreateChat.xaml
    /// </summary>
    public partial class WindowCreateChat : Window
    {
        static Serializer serializer = new Serializer();
        private readonly ClientServerService clientServerService_;
        public UserReceiveModel _userReceiveModel { get; set; }
        public List<AllUsersView> friend = new List<AllUsersView>();
        public List<AllUsersView> usersInChat = new List<AllUsersView>();
        public WindowCreateChat(List<AllUsersView> friend, List<AllUsersView> usersInChat, UserReceiveModel _userReceiveModel)
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            if (friend != null)
            {
                this.friend = friend;
            }
            else
            {
                GridSearch.Visibility = Visibility.Collapsed;
                TextBlockFriends.Visibility = Visibility.Collapsed;
                FriendListAdd.Visibility = Visibility.Collapsed;
            }
            
            if (usersInChat != null)
            {
                this.usersInChat = usersInChat;
            }
            this._userReceiveModel = _userReceiveModel;
            Itemsource();
        }

        private void Itemsource()
        {
            FriendListAdd.ListBoxUsersAddInChat.ItemsSource = null;
            FriendListInChat.ListBoxDeleteUsersInChat.ItemsSource = null;
            FriendListAdd.ListBoxUsersAddInChat.ItemsSource = friend;
            FriendListInChat.ListBoxDeleteUsersInChat.ItemsSource = usersInChat;
        }

        private void ButtonCreateChat_Click(object sender, RoutedEventArgs e)
        {
            var users = new List<ChatUserResponseModel>();
            foreach(var el in usersInChat)
            {
                users.Add(new ChatUserResponseModel
                {
                    UserId = el.Id
                });
            }
            users.Add(new ChatUserResponseModel
            {
                UserId = _userReceiveModel.Id
            });
            clientServerService_.SendAsync(new ClientOperationMessage
            {
                Operation = ClientOperations.CreateChat,
                JsonData = serializer.Serialize(new ChatResponseModel
                {
                    chatName = searchQuery.Text,
                    dateOfCreation = DateTime.Now,
                    creatorId = _userReceiveModel.Id,
                    chatUsers = users
                })
            });
        }

        private void FriendListAdd_ListBoxSelectionChange(object sender, EventArgs e)
        {
            usersInChat.Add(friend[(int)FriendListAdd.SelectIndexItem]);
            Itemsource();
        }

        private void FriendListInChat_ListBoxSelectionChange(object sender, EventArgs e)
        {
            usersInChat.RemoveAt(FriendListInChat.SelectIndexItem);
            Itemsource();
        }
    }
}
