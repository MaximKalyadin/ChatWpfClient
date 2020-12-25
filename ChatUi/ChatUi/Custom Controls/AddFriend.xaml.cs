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
    /// Логика взаимодействия для AddFriend.xaml
    /// </summary>
    public partial class AddFriend : UserControl
    {
        public AddFriend()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            ListBoxFriend.SelectionChanged += (sender, e) => { _eventListBox?.Invoke(sender, e); };
        }

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
