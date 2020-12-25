using ClientToServerApi;
using ClientToServerApi.Models.Enums;
using ClientToServerApi.Models.Enums.Transmissions;
using ClientToServerApi.Models.ReceivedModels.UserModel;
using ClientToServerApi.Models.ResponseModels.UserModel;
using ClientToServerApi.Models.TransmissionModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для ScreenSettings.xaml
    /// </summary>
    public partial class ScreenSettings : UserControl
    {
        private readonly ClientServerService clientServerService_;
        static Serializer serializer = new Serializer();
        public UserReceiveModel _userReceiveModel { get; set; }
        public UserResponseModel _userResponseModel { get; set; }
        public bool IsChange = false;
        public ScreenSettings()
        {
            InitializeComponent();
            clientServerService_ = ClientServerService.GetInstanse();
            clientServerService_.AddListener(ListenerType.UserInfoListener, UpdateProfile);
        }

        private void UpdateProfile(OperationResultInfo data)
        {
            this.Dispatcher.InvokeAsync(() =>
            {
                if (data.OperationsResult == OperationsResults.Unsuccessfully)
                {
                    MessageBox.Show("Данные не обновились!");
                }
                else if (data.OperationsResult == OperationsResults.Successfully)
                {
                    LoadedInfoProfile(_userReceiveModel);
                    IsChange = true;
                }
            });
        }

        public void LoadedInfoProfile(UserReceiveModel model)
        {
            if (model != null)
            {
                if (model.Name != null)
                {
                    Name.Text = model.Name.ToString();
                }
                if (model.SecondName != null)
                {
                    SecondName.Text = model.SecondName.ToString();
                }
                if (model.PhoneNumber != null)
                {
                    Phone.Text = model.PhoneNumber.ToString();
                }
                if (model.Gender != null)
                {
                    Gender.Text = model.Gender.ToString();
                }
                if (model.Country != null)
                {
                    Country.Text = model.Country.ToString();
                }
                if (model.City != null)
                {
                    City.Text = model.City.ToString();
                }
                if (model.UserName != null)
                {
                    Nick.Text = model.UserName.ToString();
                }
            }
            else
            {
                MessageBox.Show("Не удалось Загрузить данные!");
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("<><><><><><><><> " + _userReceiveModel + " " + _userResponseModel);
            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                _userReceiveModel.Name = NameTextBox.Text;
                _userResponseModel.Name = NameTextBox.Text;
            }
            if (!string.IsNullOrEmpty(NickTextBox.Text))
            {
                _userReceiveModel.UserName = NickTextBox.Text;
                _userResponseModel.UserName = NickTextBox.Text;
            }
            if (!string.IsNullOrEmpty(ComboBoxGender.Text))
            {
                _userReceiveModel.Gender = (Gender)Enum.Parse(typeof(Gender), ComboBoxGender.Text);
                _userResponseModel.Gender = (Gender)Enum.Parse(typeof(Gender), ComboBoxGender.Text);
            }
            if (!string.IsNullOrEmpty(CuntryTextBox.Text))
            {
                _userReceiveModel.Country = (Country)Enum.Parse(typeof(Country), CuntryTextBox.Text);
                _userResponseModel.Country = (Country)Enum.Parse(typeof(Country), CuntryTextBox.Text);
            }
            if (!string.IsNullOrEmpty(TownTextBox.Text))
            {
                _userReceiveModel.City = (City)Enum.Parse(typeof(City), TownTextBox.Text);
                _userResponseModel.City = (City)Enum.Parse(typeof(City), TownTextBox.Text);
            }
            if (NewPasswordTextBox.Password.Equals(RepeatPasswordTextBox.Password) && !string.IsNullOrEmpty(OldPasswordTextBox.Password))
            {
                _userResponseModel.Password = RepeatPasswordTextBox.Password;
            }
            if (!string.IsNullOrEmpty(PhoneTextBlock.Text))
            {
                _userReceiveModel.PhoneNumber = PhoneTextBlock.Text;
                _userResponseModel.PhoneNumber = PhoneTextBlock.Text;
            }
            clientServerService_.SendAsync(new ClientOperationMessage()
            {
                Operation = ClientOperations.UpdateProfile,
                JsonData = serializer.Serialize(_userResponseModel)
            });
        }
    }
}
