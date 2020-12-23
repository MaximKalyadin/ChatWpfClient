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
    /// Логика взаимодействия для MenuListControl.xaml
    /// </summary>
    public partial class MenuListControl : UserControl
    {
        public MenuListControl()
        {
            InitializeComponent();
            DataContext = new ViewModel();
            ListBoxMenu.SelectionChanged += (sender, e) => { _eventListBox?.Invoke(sender, e); };
        }

        public event EventHandler _eventListBox;

        public int SelectedIndex
        {
            get
            {
                return ListBoxMenu.SelectedIndex;
            }
            set
            {
                ListBoxMenu.SelectedIndex = value;
            }
        }


        public event EventHandler ListBoxSelectedIndex
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
