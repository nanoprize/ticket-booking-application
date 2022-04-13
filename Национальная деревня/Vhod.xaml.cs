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

namespace Национальная_деревня
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        Entities entities = new Entities();
        public Vhod()
        {
            InitializeComponent();
        }

        private void vhod_button_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            foreach (var user in entities.Посетители)
            {
                if (login_box.Text == "" || password_box.Password == "")
                {
                    MessageBox.Show("Заполните поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    b = true;
                }

                else if (login_box.Text == "admin" && password_box.Password == "zzzz")
                {
                    b = true;
                    MessageBox.Show("Вход администратора выполнен", "Подтверждение", MessageBoxButton.OK, MessageBoxImage.Information);

                    var window = new adminMain();
                    window.Show();
                    this.Close();
                }
               
                else
                {
                    

                    MessageBox.Show("Вход выполнен", "Подтверждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    var window = new MainWindow();
                    window.Show();
                    this.Close();
                    b = true;


                }
                

                break;
            }
            if (b != true)
            {
                MessageBox.Show("Проверьте правильность введенных данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void registrtion_Click(object sender, RoutedEventArgs e)
        {
            var window = new Вход();
            window.Show();
            this.Close();
        }
    }
}
