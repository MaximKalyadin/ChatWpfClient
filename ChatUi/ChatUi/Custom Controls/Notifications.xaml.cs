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
        public Notifications()
        {
            InitializeComponent();
            ListBoxNotification.SelectionChanged += (sender, e) => { _eventListBox?.Invoke(sender, e); };
        }

        public event EventHandler _eventListBox;

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
    }
}
