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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatUi.Custom_Controls
{
    /// <summary>
    /// Логика взаимодействия для DeleteUsersinChat.xaml
    /// </summary>
    public partial class DeleteUsersinChat : UserControl
    {
        public DeleteUsersinChat()
        {
            InitializeComponent();
            ListBoxDeleteUsersInChat.SelectionChanged += (sender, e) => { _eventListBox?.Invoke(sender, e); };
        }

        int? index = 0;
        public event EventHandler _eventListBox;

        public int? SelectIndexItem
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
            index = ListBoxDeleteUsersInChat.Items.IndexOf(button.DataContext);
            ListBoxDeleteUsersInChat.SelectedIndex = (int)index;
        }
    }
}
