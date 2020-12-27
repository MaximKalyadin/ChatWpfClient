using ClientToServerApi;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.NotificationModels;
using ClientToServerApi.Models.TransmissionModels;
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
        static Serializer serializer = new Serializer();
        private readonly ClientServerService clientServerService_;
        List<NotificationReceiveModel> notifications = new List<NotificationReceiveModel>();
        public ScreenNotification()
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            clientServerService_.AddListener(ListenerType.NotificationListListener, Notification);
        }

        public void Notification(OperationResultInfo operationResultInfo)
        {
            if(operationResultInfo.JsonData != null)
            {
                notifications = serializer.Deserialize<List<NotificationReceiveModel>>(operationResultInfo.JsonData as string);
                NotficationListbox.ListBoxNotification.ItemsSource = notifications;
            }
            else if (string.IsNullOrEmpty(operationResultInfo.ErrorInfo))
            {
                MessageBox.Show("уведомлений нет");
            }
            else
            {
                MessageBox.Show(operationResultInfo.ErrorInfo);
            }
        }
    }
}
