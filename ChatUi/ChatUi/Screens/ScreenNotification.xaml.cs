using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.NotificationModels;
using ClientToServerApi.Models.ReceivedModels.UserModel;
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

namespace ChatUi.Screens
{
    /// <summary>
    /// Логика взаимодействия для ScreenNotification.xaml
    /// </summary>
    public partial class ScreenNotification : UserControl
    {
        static JsonStringSerializer serializer = new JsonStringSerializer();
        private readonly ClientServerService clientServerService_;
        List<NotificationReceiveModel> notifications = new List<NotificationReceiveModel>();
        public UserReceiveModel _userReceiveModel { get; set; }
        public bool IsChange = false;
        public ScreenNotification()
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            clientServerService_.AddListener(ListenerType.NotificationListListener, Notification);
        }

        public void ViewNotifications()
        {
            NotficationListbox.ListBoxNotification.ItemsSource = null;
            NotficationListbox.ListBoxNotification.ItemsSource = notifications;
            NotficationListbox._userReceiveModel = _userReceiveModel;
        }

        public void Notification(OperationResultInfo operationResultInfo)
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                try
                {
                    if (operationResultInfo.JsonData != null)
                    {
                        var notifi = serializer.Deserialize<NotificationReceiveModel>(operationResultInfo.JsonData.ToString());
                        notifications.Add(notifi);
                    }
                }
                catch
                {
                    if (operationResultInfo.JsonData != null)
                    {
                        notifications = serializer.Deserialize<List<NotificationReceiveModel>>(operationResultInfo.JsonData.ToString());
                        NotficationListbox.notifications = notifications;
                        IsChange = true;
                    }
                    else if (string.IsNullOrEmpty(operationResultInfo.ErrorInfo))
                    {
                        MessageBox.Show("Уведомлений нет");
                    }
                    else
                    {
                        MessageBox.Show(operationResultInfo.ErrorInfo);
                    }
                }
                NotficationListbox.ListBoxNotification.ItemsSource = null;
                NotficationListbox.ListBoxNotification.ItemsSource = notifications;
            });
            
        }

        private void NotficationListbox_ListBoxSelectionChange(object sender, EventArgs e)
        {
            notifications = NotficationListbox.notifications;
            NotficationListbox.ListBoxNotification.ItemsSource = null;
            NotficationListbox.ListBoxNotification.ItemsSource = notifications;
        }
    }
}
