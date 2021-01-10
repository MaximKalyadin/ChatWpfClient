using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.ResponseModels.FriendModels;
using ClientToServerApi.Models.TransmissionModels;
using ClientToServerApi.Models.ViewModels;
using ClientToServerApi.Serializer;
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

namespace ChatUi.Custom_Controls
{
    /// <summary>
    /// Логика взаимодействия для DeleteFriend.xaml
    /// </summary>
    public partial class DeleteFriend : UserControl
    {
        public List<AllUsersView> _friends = new List<AllUsersView>();
        public UserReceiveModel _userReceiveModel { get; set; }
        private readonly ClientServerService clientServerService_;
        static JsonStringSerializer serializer = new JsonStringSerializer();
        public DeleteFriend()
        {
            InitializeComponent();
            ListBoxFriend.SelectionChanged += (sender, e) => { _eventListBox?.Invoke(sender, e); };
            clientServerService_ = ClientServerService.GetInstanse();
        }

        int? index = null;
        public event EventHandler _eventListBox;
        public int SelectedIndex
        {
            get
            {
                return ListBoxFriend.SelectedIndex;
            }
            set
            {
                ListBoxFriend.SelectedIndex = value;
            }
        }
        public int? SelectedIndexItem
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        public event EventHandler ListBoxSelectionChange
        {
            add
            {
                _eventListBox += value;
            }
            remove
            {
                _eventListBox -= value;
            }
        }

        private void ButtonMore_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            index = ListBoxFriend.Items.IndexOf(button.DataContext);
            var ind = ListBoxFriend.Items.IndexOf(button.DataContext);
            FriendResponseModel friend = new FriendResponseModel();
            friend.UserId = _userReceiveModel.Id;
            friend.FriendId = _friends[ind].Id;
            Debug.WriteLine(_userReceiveModel.Id);
            
            Debug.WriteLine(friend.FriendId + " " + friend.UserId);

            foreach(var el in _friends)
            {
                if (el.Id == friend.FriendId)
                {
                    _friends.Remove(el);
                    break;
                }
            }
            ListBoxFriend.SelectedIndex = ind;
            clientServerService_.SendAsync(new ClientOperationMessage()
            {
                Operation = ClientOperations.DeleteFriend,
                JsonData = serializer.Serialize(friend)
            });
            
        }
    }
}
