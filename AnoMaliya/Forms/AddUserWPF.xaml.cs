using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
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

namespace AnoMaliya.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddUserWPF.xaml
    /// </summary>
    public partial class AddUserWPF : Window
    {
        private List<string> genderContentComboboxGender = new List<string>() { "мужской", "женский", "другой"}; //данные комбобокса

        public AddUserWPF()
        {
            InitializeComponent();
            this.Loaded += AddUserWPF_Loaded;
            this.Closing += AddUserWPF_Closing;
        }

        private void AddUserWPF_Closing(object? sender, CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void AddUserWPF_Loaded(object sender, RoutedEventArgs e)
        {
            cbGender.ItemsSource = genderContentComboboxGender;
            cbGender.SelectedIndex = 0;
        }

        private void btAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("имя свое написал быстро");
                return;
            }
            int age = 0;
            double number = 0;

            try
            {
                age = Convert.ToInt32(tbAge.Text);
                if (age < 0)
                {
                    MessageBox.Show("возраст не так пишется, чел...");
                    return;
                }
            }

            catch
            {
                MessageBox.Show("не число вписал, подумой", "Ну чееел", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                number = Convert.ToDouble(tbNumber.Text);
                if (number < 0)
                {
                    MessageBox.Show("НУ АЛЕЕЕ НОМЕРОК");
                    return;
                }
            }

            catch
            {
                MessageBox.Show("не число вписал, подумой", "Ну чееел", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }





            DB.User newUser = new DB.User
            {
                UserName = tbName.Text,
                UserAge = age,
                UserNumber = number,
                Gender = cbGender.SelectedItem.ToString()
            };

            DB.MyContext myContext = new DB.MyContext();
            try
            {
                myContext.Users.Add(newUser);
                myContext.SaveChanges();
                MessageBox.Show($"Поздравляю тебя {newUser.UserName} ты в аду");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Чета не могу нового усера добавить" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btDown_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
