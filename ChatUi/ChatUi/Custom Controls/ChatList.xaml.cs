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
    /// Логика взаимодействия для ChatList.xaml
    /// </summary>
    public partial class ChatList : UserControl
    {
        public ChatList()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            ListChat.SelectionChanged += (sender, e) => { _eventListBox?.Invoke(sender, e); };
        }

        public event EventHandler _eventListBox;

        public int SelectedIndex
        {
            get
            {
                return ListChat.SelectedIndex;
            }
            set
            {
                ListChat.SelectedIndex = value;
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
