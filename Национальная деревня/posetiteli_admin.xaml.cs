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
    /// Логика взаимодействия для posetiteli_admin.xaml
    /// </summary>
    public partial class posetiteli_admin : Window
    {
        Entities entities = new Entities();
        public posetiteli_admin()
        {
            InitializeComponent();
            list_gostey.ItemsSource = entities.Посетители.ToList();
        }
        byte[] data;
        private void nazad_button_Click(object sender, RoutedEventArgs e)
        {
            var window = new adminMain();
            window.Show();
            this.Close();
        }

        private void list_gostey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var klient = list_gostey.SelectedItem as Посетители;
            if (klient != null)
            {
                //name_excursions.Text = zakaz.название;
                //name_bilet.Text = zakaz.цена;
                //name_klient.Text = zakaz.наличие;
                fio.Text = klient.ФИО;
                number.Text = klient.номер;
                email.Text = klient.почта;
                login.Text = klient.login;
                password.Text = klient.password;

            }
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var klient = entities.Посетители.ToList();
            klient = klient.Where(p => p.ФИО.ToLower().Contains(search.Text.ToLower())).ToList();

            list_gostey.ItemsSource = klient;
        }

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {
            list_gostey.ItemsSource = entities.Посетители.ToList();
            list_gostey.SelectedIndex = -1;
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            var save_all = list_gostey.SelectedItem as Посетители;
            if (fio.Text == "" || number.Text == "" || email.Text == "" || email.Text == "" || login.Text == "" || password.Text == "")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (save_all == null)
            {
                save_all = new Посетители();
                entities.Посетители.Add(save_all);
            }
            
            save_all.ФИО = fio.Text;
            save_all.номер = number.Text;
            save_all.почта = email.Text;
            save_all.login = login.Text;
            save_all.password = password.Text;

            entities.SaveChanges();
            MessageBox.Show("Пользователь добавлен", "Подтверждение", MessageBoxButton.OK, MessageBoxImage.Information);
            list_gostey.ItemsSource = entities.Посетители.ToList();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            Посетители emp = list_gostey.SelectedItem as Посетители;
            var del_klient = list_gostey.SelectedItem as Посетители;
            try
            {
                var exist_ = (from pb in entities.Заказ where pb.Id_посетителя == del_klient.Id select pb).First();
                // Запись найдена
                MessageBox.Show("Нельзя удалить этого клиента\nОн заказал билет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                var rezult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezult == MessageBoxResult.No)
                {
                    return;
                }
                if (emp != null)
                {
                    MessageBoxResult result = MessageBox.Show("Удалить запись?",
            "Предупреждение", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        
                        entities.Посетители.Remove(emp);

                        list_gostey.SelectedIndex =
                         list_gostey.SelectedIndex == 0 ? 1 : list_gostey.SelectedIndex - 1;
                        
                        entities.SaveChanges();
                        MessageBox.Show("Запись удалена", "Подтверждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Нет удаляемых объектов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void clear_button_Click(object sender, RoutedEventArgs e)
        {

            fio.Clear();
            number.Clear();
            email.Clear();
            login.Clear();
            password.Clear();
            list_gostey.SelectedIndex = -1;
        }
    }
}
