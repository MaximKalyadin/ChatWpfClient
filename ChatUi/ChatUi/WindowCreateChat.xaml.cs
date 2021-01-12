using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.ResponseModel.ChatModels;
using ClientToServerApi.Models.ResponseModels.ChatModels;
using ClientToServerApi.Models.TransmissionModels;
using ClientToServerApi.Models.ViewModels;
using ClientToServerApi.Serializer;
using NLog;
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
        static JsonStringSerializer serializer = new JsonStringSerializer();
        private readonly ClientServerService clientServerService_;
        public UserReceiveModel _userReceiveModel { get; set; }
        public List<AllUsersView> friend = new List<AllUsersView>();
        public List<AllUsersView> usersInChat = new List<AllUsersView>();
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        public int? CreatorId { get; set; }
        public int ChatId { get; set; }
        public bool IsCreateChat = false;
        public bool IsDeleteChat = false;
        public bool IsAddFriend = false;
        public WindowCreateChat(List<AllUsersView> friend, List<AllUsersView> usersInChat, UserReceiveModel _userReceiveModel, int? CreatorId, int? ChatId)
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
            if (CreatorId != null)
            {
                this.ChatId = (int)ChatId;
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
                    UserId = _userReceiveModel.UserId
                });
                clientServerService_.SendAsync(new ClientOperationMessage
                {
                    Operation = ClientOperations.CreateChat,
                    JsonData = serializer.Serialize(new ChatResponseModel
                    {
                        ChatName = searchQuery.Text,
                        DateOfCreation = DateTime.Now,
                        CreatorId = _userReceiveModel.UserId,
                        ChatUsers = users
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
                    UserId = _userReceiveModel.UserId,
                    ChatId = ChatId
                });
                clientServerService_.SendAsync(new ClientOperationMessage
                {
                    Operation = ClientOperations.UpdateChat,
                    JsonData = serializer.Serialize(new ChatResponseModel
                    {
                        Id = ChatId,
                        ChatName = searchQuery.Text,
                        CreatorId = _userReceiveModel.UserId,
                        ChatUsers = users,
                        DateOfCreation = DateTime.Now
                    })
                });
            }
            this.Close();
        }

        private void FriendListAdd_ListBoxSelectionChange(object sender, EventArgs e)
        {
            AllUsersView user = null;
            if (FriendListAdd.SelectIndexItem != null)
            {
                user = usersInChat.FirstOrDefault(c => c.Id == friend[(int)FriendListAdd.SelectIndexItem].Id);
            }
            if (user == null && IsCreateChat && FriendListAdd.SelectIndexItem != null)
            {
                usersInChat.Add(friend[(int)FriendListAdd.SelectIndexItem]);
                FriendListAdd.SelectIndexItem = null;
            } else if (user == null && IsAddFriend && CreatorId == _userReceiveModel.UserId && FriendListAdd.SelectIndexItem != null)
            {
                usersInChat.Add(friend[(int)FriendListAdd.SelectIndexItem]);
                FriendListAdd.SelectIndexItem = null;
            }
            else if (FriendListAdd.SelectIndexItem != null)
            {
                logger.Warn("Вы не являетесь создателем чата и не можете добавить в него людей!");
                MessageBox.Show("Вы не являетесь создателем чата и не можете добавить в него людей!");
                FriendListAdd.SelectIndexItem = null;
            }
            Itemsource();
        }

        private void FriendListInChat_ListBoxSelectionChange(object sender, EventArgs e)
        {
            if (IsDeleteChat && CreatorId == _userReceiveModel.UserId && FriendListInChat.SelectIndexItem != null)
            {
                if (usersInChat.Count == 1)
                {
                    logger.Warn("Недьзя удалить всех участников из беседы!");
                    MessageBox.Show("Недьзя удалить всех участников из беседы!");
                    return;
                }
                var users = new List<ChatUserResponseModel>();
                foreach(var el in usersInChat)
                {
                    if (el.Id != usersInChat[(int)FriendListInChat.SelectIndexItem].Id) {
                        users.Add(new ChatUserResponseModel
                        {
                            ChatId = ChatId,
                            UserId = el.Id
                        });
                    }
                }
                users.Add(new ChatUserResponseModel
                {
                    ChatId = ChatId,
                    UserId = _userReceiveModel.UserId
                });
                clientServerService_.SendAsync(new ClientOperationMessage
                {
                    Operation = ClientOperations.UpdateChat,
                    JsonData = serializer.Serialize(new ChatResponseModel
                    {
                        Id = ChatId,
                        ChatUsers = users
                    })
                });
                usersInChat.RemoveAt((int)FriendListInChat.SelectIndexItem);
                FriendListInChat.SelectIndexItem = null;
            }
            else if(CreatorId != _userReceiveModel.UserId && FriendListInChat.SelectIndexItem != null)
            {
                logger.Warn("Вы не являетесь создателем чата и не можете удалить пользователя из него!");
                MessageBox.Show("Вы не являетесь создателем чата и не можете удалить пользователя из него!");
                FriendListInChat.SelectIndexItem = null;
            } 
            Itemsource();
        }
    }
}
