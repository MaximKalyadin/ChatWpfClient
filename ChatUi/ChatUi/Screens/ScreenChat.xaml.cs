using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.ChatModels;
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
        public int ChatId { get; set; }
        public bool IsChange = false;
        public ScreenChat()
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            clientServerService_.AddListener(ListenerType.ChatListListener,ChatListListener);
            clientServerService_.AddListener(ListenerType.ChatListDeleteListener, DeleteChatList);
        }

        private void ViewChat()
        {
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
                    if (data == null) break;
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

        private void Itemsource()
        {
            ChatList.ListChat.ItemsSource = null;
            ChatList.ListChat.ItemsSource = chatView;
        }

        public void ChatListListener(OperationResultInfo operationResultInfo)
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                try
                {
                    if (operationResultInfo.JsonData != null)
                    {
                        var data = serializer.Deserialize<ChatReceiveModel>(operationResultInfo.JsonData as string);
                        var chat = chats.FirstOrDefault(c => c.Id == data.Id || c.ChatName == data.ChatName && c.CreatorId == data.CreatorId && c.CountUsers == c.CountUsers);
                        if (chat == null)
                        {
                            chats.Add(data);
                        }
                        else
                        {
                            chat = data;
                        }
                        for (int i = 0; i < chats.Count; i++)
                        {
                            if (chat.Id == chats[i].Id)
                            {
                                chats[i] = chat;
                            }
                        }
                    } else
                    {
                        MessageBox.Show("Data is null or empty");
                    }
                }
                catch
                {
                    if (operationResultInfo.JsonData != null)
                    {
                        var data = serializer.Deserialize<List<ChatReceiveModel>>(operationResultInfo.JsonData as string);
                        chats = data;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка чатов!");
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
                if (chatView[ChatList.SelectedIndex].CountUsers == 2)
                {
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
        }

        private void ButtonMore_MouseEnter(object sender, MouseEventArgs e)
        {
            this.PopupMore.IsOpen = true;
            if (FriendProfileView.Count > 2)
            {
                OpenFriendProfileButton.Visibility = Visibility.Collapsed;
                if (FriendProfileView.CreatorId == _userReceiveModel.Id)
                {
                    RemoveFriendFromChatButton.Visibility = Visibility.Visible;
                }
                else
                {
                    RemoveFriendFromChatButton.Visibility = Visibility.Collapsed;
                }
            } else
            {
                OpenFriendProfileButton.Visibility = Visibility.Visible;
                RemoveFriendFromChatButton.Visibility = Visibility.Collapsed;
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
                FriendProfile.Visibility = Visibility.Visible;
                FriendProfile.ProfileFriend.Visibility = Visibility.Visible;
                FriendProfile.ViewFriend(FriendProfileView);
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

        private void AddFriendToChatButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveFriendFromChatButton_Click(object sender, RoutedEventArgs e)
        {
            if (FriendProfileView.CreatorId == _userReceiveModel.Id)
            {

            }
        }

        private void ClearChatButton_Click(object sender, RoutedEventArgs e)
        {
            //in developing
        }

        private void DeleteChatButton_Click(object sender, RoutedEventArgs e)
        {
            var currentChat = chats.FirstOrDefault(c => c.Id == ChatId);
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
        }
    }
}
