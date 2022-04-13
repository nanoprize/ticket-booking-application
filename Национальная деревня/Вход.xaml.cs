using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Вход.xaml
    /// </summary>
    public partial class Вход : Window
    {
        Entities entities = new Entities();
        public Вход()
        {
            InitializeComponent();
        }
        byte[] data;
        private void reg_button_Click(object sender, RoutedEventArgs e)
        {
            if (parolReg.Password == "")
                MessageBox.Show("Вы не указали пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            if (loginReg.Text == "")
                MessageBox.Show("Вы не указали логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            if (fio_box.Text == "")
                MessageBox.Show("Вы не указали ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            if (nomer_box.Text == "")
                MessageBox.Show("Вы не указали номер", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            if (email_box.Text == "")
                MessageBox.Show("Вы не указали почту", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            bool flag_login;
            bool flag_pass;
            if (loginReg.Text != "" && parolReg.Password != "" && fio_box.Text != "" && nomer_box.Text != "" && email_box.Text != "")
            {
                if (parolReg.Password != "")
                {

                    flag_pass = true;
                }
                else
                {
                    MessageBox.Show("Вы не указали логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    flag_pass = false;
                }

                if (loginReg.Text.Length >= 3)
                {
                    flag_login = true;
                }
                else
                {
                    MessageBox.Show("Придумайте логин длиннее", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    flag_login = false;
                }
                if (flag_login && flag_pass)
                {
                    Посетители user = new Посетители();
                    user.login = loginReg.Text;
                    user.password = parolReg.Password.Trim();

                    user.ФИО = fio_box.Text;
                    user.номер = nomer_box.Text;
                    user.почта = email_box.Text;
                    user.фото = photo.Text;

                    entities.Посетители.Add(user);
                    entities.SaveChanges();
                    MessageBox.Show("Пользователь добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.None);

                    loginReg.Text = "";
                    parolReg.Password = "";
                    fio_box.Text = "";
                    nomer_box.Text = "";
                    email_box.Text = "";
                    photo.Text = "";
                }
            }
            else
            {
                loginReg.Text = "";
                parolReg.Password = "";
                fio_box.Text = "";
                nomer_box.Text = "";
                email_box.Text = "";

            }
        }

        private void vhod_button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void load_photo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true && !string.IsNullOrWhiteSpace(dlg.FileName))
                photo.Text = dlg.FileName.ToString();
            photo.Focus();

        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            var window = new Vhod();
            window.Show();
            this.Close();
        }
    }
    }



