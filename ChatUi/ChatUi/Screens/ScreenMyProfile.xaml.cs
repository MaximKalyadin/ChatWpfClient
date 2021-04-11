using ClientToServerApi;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using NLog;
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
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        static Converter converter = new Converter();
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
                if (model.File.BinaryForm != null)
                {
                    MyProfileImageScreen.ProfileImageSource = converter.ConvertByteToImage(model.File.BinaryForm);
                }
            }
            else
            {
                logger.Warn("не удалось загрузить данные для просмотра своего профиля");
                System.Windows.MessageBox.Show("Не удалось Загрузить данные!");
            }
        }

        private void ButtonCloseMyProfile_Click(object sender, RoutedEventArgs e)
        {
            GridMyProfile.Visibility = Visibility.Collapsed;
        }
    }
}
