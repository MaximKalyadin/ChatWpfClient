using ClientToServerApi.Models.ReceivedModels.UserModel;
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
    /// Логика взаимодействия для ScreenMyProfile.xaml
    /// </summary>
    public partial class ScreenMyProfile : UserControl
    {
        public ScreenMyProfile()
        {
            InitializeComponent();
        }

        public void MyProfile(UserReceiveModel model)
        {
            if (model != null)
            {
                if (model.Name != null && model.SecondName != null)
                {
                    NameSurnameTextBlock.Text = model.Name.ToString() + " " + model.SecondName.ToString();
                }
                if (model.PhoneNumber != null)
                {
                    PhoneRun.Text = model.PhoneNumber.ToString();
                }
                if (model.Country != null && model.City != null)
                {
                    CountryCityTextBlock.Text = model.Country.ToString() + " " + model.City.ToString();
                }
                if (model.UserName != null)
                {
                    NickNameTextBlock.Text = model.UserName.ToString();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Не удалось Загрузить данные!");
            }
        }

        private void ButtonCloseMyProfile_Click(object sender, RoutedEventArgs e)
        {
            GridMyProfile.Visibility = Visibility.Collapsed;
        }
    }
}
