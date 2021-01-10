using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.NotificationModels;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.ResponseModels.NotificationsModels;
using ClientToServerApi.Models.TransmissionModels;
using ClientToServerApi.Serializer;
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

namespace ChatUi.Custom_Controls
{
    /// <summary>
    /// Логика взаимодействия для Notifications.xaml
    /// </summary>
    public partial class Notifications : UserControl
    {
        static JsonStringSerializer serializer = new JsonStringSerializer();
        private readonly ClientServerService clientServerService_;
        public UserReceiveModel _userReceiveModel { get; set; }
        public List<NotificationReceiveModel> notifications = new List<NotificationReceiveModel>();
        public Notifications()
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            ListBoxNotification.SelectionChanged += (sender, e) => { _eventListBox?.Invoke(sender, e); };
        }

        public event EventHandler _eventListBox;
        int? index = null;
        public int SelectedIndex
        {
            get
            {
                return ListBoxNotification.SelectedIndex;
            }
            set
            {
                ListBoxNotification.SelectedIndex = value;
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

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            index = ListBoxNotification.Items.IndexOf(button.DataContext);
            var ind = ListBoxNotification.Items.IndexOf(button.DataContext);
            NotificationResponseModel model = new NotificationResponseModel();
            model.Id = notifications[ind].Id;
            model.IsAccepted = true;
            model.ToUserId = _userReceiveModel.Id;
            model.FromUserId = notifications[ind].FromUserId;


            foreach(var el in notifications)
            {
                if (el.Id == model.Id)
                {
                    notifications.Remove(el);
                    break;
                }
            }
            clientServerService_.SendAsync(new ClientOperationMessage()
            {
                Operation = ClientOperations.UpdateNotification,
                JsonData = serializer.Serialize(model)
            });
            ListBoxNotification.SelectedIndex = ind;
        }

        private void ButtonNot_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            index = ListBoxNotification.Items.IndexOf(button.DataContext);
            var ind = ListBoxNotification.Items.IndexOf(button.DataContext);
            NotificationResponseModel model = new NotificationResponseModel();
            model.Id = notifications[ind].Id;
            model.IsAccepted = false;
            model.ToUserId = _userReceiveModel.Id;
            model.FromUserId = notifications[ind].FromUserId;
            foreach (var el in notifications)
            {
                if (el.Id == model.Id)
                {
                    notifications.Remove(el);
                    break;
                }
            }
            clientServerService_.SendAsync(new ClientOperationMessage()
            {
                Operation = ClientOperations.UpdateNotification,
                JsonData = serializer.Serialize(model)
            });
            ListBoxNotification.SelectedIndex = ind;
        }
    }
}
