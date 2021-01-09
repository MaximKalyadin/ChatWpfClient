using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.ChatModels;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.ResponseModel.ChatModels;
using ClientToServerApi.Models.ResponseModels.ChatModels;
using ClientToServerApi.Models.ResponseModels.UserModel;
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
    /// Логика взаимодействия для ScreenChat.xaml
    /// </summary>
    public partial class ScreenChat : UserControl
    {
        private readonly ClientServerService clientServerService_;
        static Serializer serializer = new Serializer();
        List<ChatReceiveModel> chats = new List<ChatReceiveModel>();
        List<ChatListViewModel> chatView = new List<ChatListViewModel>();
        public FriendProfileView FriendProfileView { get; set; }
        public UserReceiveModel _userReceiveModel { get; set; }
        public List<AllUsersView> friend = new List<AllUsersView>();
        public int ChatId { get; set; }
        public bool IsChange = false;
        public ScreenChat()
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            clientServerService_.AddListener(ListenerType.ChatListListener,ChatListListener);
            clientServerService_.AddListener(ListenerType.ChatListDeleteListener, DeleteChatList);
            clientServerService_.AddListener(ListenerType.UserInfoListener, UserInfo);
            clientServerService_.AddListener(ListenerType.ChatsMessagesListener, ChatMessage);
            clientServerService_.AddListener(ListenerType.ChatsMessagesDeleteListener, UserMessageDelete);
        }

        public void ChatMessage(OperationResultInfo operationResultInfo)
        {
            Dispatcher.InvokeAsync(() =>
            {
                if (operationResultInfo.JsonData != null)
                {

                }
            });
        }

        public void UserMessageDelete(OperationResultInfo operationResultInfo)
        {
            Dispatcher.InvokeAsync(() =>
            {
                if (operationResultInfo.JsonData != null)
                {

                }
            });
        }

        public void UserInfo(OperationResultInfo operationResultInfo)
        {
            Dispatcher.InvokeAsync(() =>
            {
                if (operationResultInfo.JsonData != null)
                {
                    var data = serializer.Deserialize<UserReceiveModel>(operationResultInfo.JsonData as string);
                    FriendProfile.Visibility = Visibility.Visible;
                    FriendProfile.ProfileFriend.Visibility = Visibility.Visible;
                    FriendProfile.Stackpanelfriend.Visibility = Visibility.Visible;
                    FriendProfile.ViewFriend(data);
                }
                else
                {
                    MessageBox.Show("User info is null or empty");
                }
            });
        }

        private void ViewChat()
        {
            chatView.Clear();
            foreach(var el in chats)
            {
                ChatListViewModel chatListView = new ChatListViewModel();
                chatListView.CreatorId = el.CreatorId;
                if (el.CountUsers > 2)
                {
                    chatListView.Id = el.Id;
                    chatListView.Name = el.ChatName;
                    chatListView.CountUsers = el.ChatUsers.Count;
                    chatView.Add(chatListView);
                }
                else
                {
                    var data = el.ChatUsers.FirstOrDefault(c => c.Id != _userReceiveModel.Id);
                    if (data != null)
                    {
                        chatListView.Id = data.Id;
                        chatListView.Name = data.UserName;
                        if (data.IsOnline)
                        {
                            chatListView.IsOnline = true;
                            chatListView.Online = "Online";
                        }
                        else
                        {
                            chatListView.IsOnline = false;
                            chatListView.Online = "Offline";
                        }
                        chatListView.CountUsers = 2;
                        chatView.Add(chatListView);
                    }
                }
            }
        }

        private void Itemsource()
        {
            ChatList.ListChat.ItemsSource = null;
            ChatList.ListChat.ItemsSource = chatView;
        }

        public void ChatListListener(OperationResultInfo operationResultInfo)
        {
            this.Dispatcher.InvokeAsync(() =>
            {

                if (operationResultInfo.JsonData != null)
                {
                    var data = serializer.Deserialize<List<ChatReceiveModel>>(operationResultInfo.JsonData as string);
                    foreach(var el in data)
                    {
                        var chat = chats.FirstOrDefault(c => c.Id == el.Id);
                        if (chat == null)
                        {
                            chats.Add(el);
                        } else
                        {
                            for (int i = 0; i < chats.Count; i++)
                            {
                                if (el.Id == chats[i].Id)
                                {
                                    chats[i] = el;
                                }
                            }
                        }
                    }
                }
                IsChange = true;
                ViewChat();
                Itemsource();
            });
        }

        public void DeleteChatList(OperationResultInfo operationResultInfo)
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                if (operationResultInfo.JsonData != null)
                {
                    var data = serializer.Deserialize<ChatReceiveModel>(operationResultInfo.JsonData as string);
                    var delete = chats.FirstOrDefault(c => c.Id == data.Id);
                    if (delete != null)
                    {
                        chats.Remove(delete);
                    } 
                }
                else
                {
                    MessageBox.Show("Data is null or empty");
                }
                ViewChat();
                Itemsource();
            });
        }


        public void ListBoxChat_ListBoxSelectionChange(object sender, EventArgs e)
        {
            if (ChatList.SelectedIndex >= 0)
            {
                ChatId = ChatList.SelectedIndex;
                BorderSendMassege.Visibility = Visibility.Visible;
                ImageChat.IsOnline = chatView[ChatList.SelectedIndex].IsOnline;
                UserNameSurnameChatRun.Text = chatView[ChatList.SelectedIndex].Name;
                OnlineRun.Text = chatView[ChatList.SelectedIndex].Online;
                FriendProfileView = new FriendProfileView
                {
                    Id = chatView[ChatList.SelectedIndex].Id,
                    UserName = chatView[ChatList.SelectedIndex].Name,
                    IsOnline = chatView[ChatList.SelectedIndex].IsOnline,
                    Online = chatView[ChatList.SelectedIndex].Online,
                    Count = chatView[ChatList.SelectedIndex].CountUsers,
                    CreatorId = chatView[ChatList.SelectedIndex].CreatorId
                };
            }
        }

        private void ButtonMore_MouseEnter(object sender, MouseEventArgs e)
        {
            this.PopupMore.IsOpen = true;
            if (FriendProfileView.Count > 2)
            {
                OpenFriendProfileButton.Visibility = Visibility.Collapsed;
                OpenUsersProfileButton.Visibility = Visibility.Visible;
                if (FriendProfileView.CreatorId == _userReceiveModel.Id)
                {
                    LeaveChatButton.Visibility = Visibility.Collapsed;
                    DeleteChatButton.Visibility = Visibility.Visible;
                }
                else
                {
                    LeaveChatButton.Visibility = Visibility.Visible;
                    DeleteChatButton.Visibility = Visibility.Collapsed; ;
                }
            } else
            {
                OpenFriendProfileButton.Visibility = Visibility.Visible;
                OpenUsersProfileButton.Visibility = Visibility.Collapsed;
                LeaveChatButton.Visibility = Visibility.Collapsed;
                DeleteChatButton.Visibility = Visibility.Visible;
            }
        }

        private void PopupBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            this.PopupMore.IsOpen = false;
        }

        private void OpenProfileFriend_Click(object sender, RoutedEventArgs e)
        {
            if (FriendProfileView != null)
            {
                clientServerService_.SendAsync(new ClientOperationMessage
                {
                    Operation = ClientOperations.GetUser,
                    JsonData = serializer.Serialize(new UserResponseModel
                    {
                        Id = FriendProfileView.Id
                    })
                });
            }
        }

        private void CloseChat_Click(object sender, RoutedEventArgs e)
        {
            BorderSendMassege.Visibility = Visibility.Collapsed;
            foreach(var el in chatView)
            {
                el.IsRead = false;
            }
            Itemsource();
        }

        private void ClearChatButton_Click(object sender, RoutedEventArgs e)
        {
            //in developing
        }

        private void DeleteChatButton_Click(object sender, RoutedEventArgs e)
        {
            var currentChat = chats[ChatId];
            clientServerService_.SendAsync(new ClientOperationMessage
            {
                Operation = ClientOperations.CreateChat,
                JsonData = serializer.Serialize(new ChatResponseModel
                {
                    id = ChatId,
                    chatUsers = currentChat.ChatUsers.Select(cu => new ChatUserResponseModel
                    {
                        ChatId = currentChat.Id,
                        UserId = cu.Id
                    }).ToList()
                })
            });
            chatView.RemoveAt(ChatId);
            Itemsource();
        }

        private void LeaveChatButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new List<ChatUserResponseModel>();
            user.Add(new ChatUserResponseModel
            {
                UserId = _userReceiveModel.Id,
                ChatId = ChatId
            });
            clientServerService_.SendAsync(new ClientOperationMessage
            {
                Operation = ClientOperations.UpdateChat,
                JsonData = serializer.Serialize(new ChatResponseModel
                {
                    chatUsers = user,
                    id = ChatId
                })
            });
            chatView.RemoveAt(ChatId);
            Itemsource();
        }

        private void OpenUsersProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var users = new List<AllUsersView>();
            foreach (var el in chats[ChatId].ChatUsers)
            {
                users.Add(new AllUsersView
                {
                    Id = el.Id,
                    UserName = el.UserName,
                    IsOnline = (el.IsOnline) ? "Online" : "Offline",
                    Online = el.IsOnline,
                    Picture = el.Picture
                });
            }
            WindowCreateChat createChat = new WindowCreateChat(null, users, _userReceiveModel, FriendProfileView.CreatorId, ChatId);
            createChat.Show();
        }

        private void ButtonAddChat_Click(object sender, RoutedEventArgs e)
        {
            WindowCreateChat createChat = new WindowCreateChat(friend,null,_userReceiveModel,FriendProfileView.CreatorId,ChatId);
            createChat.Show();
        }
    }
}
