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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatUi.Custom_Controls
{
    /// <summary>
    /// Логика взаимодействия для AddFriend.xaml
    /// </summary>
    public partial class AddFriend : UserControl
    {
        public List<AllUsersView> _users = new List<AllUsersView>();
        public UserReceiveModel _userReceiveModel { get; set; }
        private readonly ClientServerService clientServerService_;
        static JsonStringSerializer serializer = new JsonStringSerializer();

        public AddFriend()
        {
            InitializeComponent();
            ListBoxUsers.SelectionChanged += (sender, e) => { _eventListBox?.Invoke(sender, e); };
            clientServerService_ = ClientServerService.GetInstanse();
        }

        int index = 0;
        public event EventHandler _eventListBox;

        public int SelectedIndex
        {
            get
            {
                return ListBoxUsers.SelectedIndex;
            }
            set
            {
                ListBoxUsers.SelectedIndex = value;
            }
        }

        public int SelectedIndexItem
        {
            get
            {
                return index;
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
            index = ListBoxUsers.Items.IndexOf(button.DataContext);
            FriendResponseModel friend = new FriendResponseModel();
            friend.UserId = _userReceiveModel.Id;
            friend.FriendId = _users[index].Id;
            Debug.WriteLine(_userReceiveModel.Id);
            Debug.WriteLine(friend.FriendId + " " + friend.UserId);
            clientServerService_.SendAsync(new ClientOperationMessage()
            {
                Operation = ClientOperations.AddFriend,
                JsonData = serializer.Serialize(friend)
            });
        }

        private void ButtonMore_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
