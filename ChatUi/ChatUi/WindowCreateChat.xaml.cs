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
        public int? CreatorId { get; set; }
        public int ChatId { get; set; }
        public bool IsCreateChat = false;
        public bool IsDeleteChat = false;
        public bool IsAddFriend = false;
        public WindowCreateChat(List<AllUsersView> friend, List<AllUsersView> usersInChat, UserReceiveModel _userReceiveModel, int? CreatorId, int ChatId)
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
                IsDeleteChat = true;
            }
            if (usersInChat != null)
            {
                this.usersInChat = usersInChat;
            } 
            else
            {
                IsCreateChat = true;
            }
            if (friend != null && usersInChat != null)
            {
                IsAddFriend = true;
            }
            this.CreatorId = CreatorId;
            this.ChatId = ChatId;
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
            if (string.IsNullOrEmpty(searchQuery.Text))
            {
                searchQuery.Text = "Ведите название чата!";
                searchQuery.Foreground = new SolidColorBrush(Color.FromRgb(255,0,0));
                return;
            }
            if (IsCreateChat)
            {
                var users = new List<ChatUserResponseModel>();
                foreach (var el in usersInChat)
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
            } else if (IsAddFriend)
            {
                var users = new List<ChatUserResponseModel>();
                foreach(var user in usersInChat)
                {
                    users.Add(new ChatUserResponseModel
                    {
                        UserId = user.Id,
                        ChatId = ChatId
                    });
                }
                users.Add(new ChatUserResponseModel
                {
                    UserId = _userReceiveModel.Id,
                    ChatId = ChatId
                });
                clientServerService_.SendAsync(new ClientOperationMessage
                {
                    Operation = ClientOperations.UpdateChat,
                    JsonData = serializer.Serialize(new ChatResponseModel
                    {
                        chatName = searchQuery.Text,
                        creatorId = _userReceiveModel.Id,
                        chatUsers = users,
                        dateOfCreation = DateTime.Now
                    })
                });
            }
            this.Close();
        }

        private void FriendListAdd_ListBoxSelectionChange(object sender, EventArgs e)
        {
            var user = usersInChat.FirstOrDefault(c => c.Id == friend[(int)FriendListAdd.SelectIndexItem].Id);
            if (user == null && IsCreateChat)
            {
                usersInChat.Add(friend[(int)FriendListAdd.SelectIndexItem]);
            } else if (user == null && IsAddFriend && CreatorId == _userReceiveModel.Id)
            {
                usersInChat.Add(friend[(int)FriendListAdd.SelectIndexItem]);
            }
            else
            {
                MessageBox.Show("Вы не являетесь создателем чата и не можете добавить в него людей!");
            }
            Itemsource();
        }

        private void FriendListInChat_ListBoxSelectionChange(object sender, EventArgs e)
        {
            if (IsDeleteChat && CreatorId == _userReceiveModel.Id && FriendListInChat.SelectIndexItem != null)
            {
                var users = new List<ChatUserResponseModel>();
                users.Add(new ChatUserResponseModel
                {
                    ChatId = ChatId,
                    UserId = usersInChat[(int)FriendListInChat.SelectIndexItem].Id
                });
                clientServerService_.SendAsync(new ClientOperationMessage
                {
                    Operation = ClientOperations.UpdateChat,
                    JsonData = serializer.Serialize(new ChatResponseModel
                    {
                        id = ChatId,
                        chatUsers = users
                    })
                });
                usersInChat.RemoveAt((int)FriendListInChat.SelectIndexItem);
                FriendListInChat.SelectIndexItem = null;
            }
            else if(CreatorId != _userReceiveModel.Id && FriendListInChat.SelectIndexItem != null)
            {
                MessageBox.Show("Вы не являетесь создателем чата и не можете удалить пользователя из него!");
                FriendListInChat.SelectIndexItem = null;
            } 
            Itemsource();
        }
    }
}
