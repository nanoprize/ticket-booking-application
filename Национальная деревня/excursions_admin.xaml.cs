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
    /// Логика взаимодействия для excursions_admin.xaml
    /// </summary>
    public partial class excursions_admin : Window
    {
        Entities entities = new Entities();
        public excursions_admin()
        {
            InitializeComponent();
            list_raspisanie.ItemsSource = entities.Расписание.ToList();
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            var save_all = list_raspisanie.SelectedItem as Расписание;
            if (save_all == null)
            {
                save_all = new Расписание();
                entities.Расписание.Add(save_all);
            }

            save_all.день_и_время = name_data.Text;
            save_all.название_события = name_excursions.Text;

            entities.SaveChanges();
            MessageBox.Show("Запсись сохранена", "Подтверждение", MessageBoxButton.OK, MessageBoxImage
                .Information);
            list_raspisanie.ItemsSource = entities.Расписание.ToList();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            Расписание emp = list_raspisanie.SelectedItem as Расписание;
            var del_klient = list_raspisanie.SelectedItem as Расписание;
            try
            {
                var exist_ = (from pb in entities.Заказ where pb.id_excursion == del_klient.Id select pb).First();
                // Запись найдена
                MessageBox.Show("Нельзя удалить экскурсию\nНа нее оформлены билеты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

                        entities.Расписание.Remove(emp);

                        list_raspisanie.SelectedIndex =
                         list_raspisanie.SelectedIndex == 0 ? 1 : list_raspisanie.SelectedIndex - 1;

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
            name_excursions.Clear();
            name_data.Clear();

            list_raspisanie.SelectedIndex = -1;
        }

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {
            list_raspisanie.ItemsSource = entities.Расписание.ToList();
            list_raspisanie.SelectedIndex = -1;
        }

        private void list_raspisanie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var zakaz = list_raspisanie.SelectedItem as Расписание;
            if (zakaz != null)
            {
                //name_excursions.Text = zakaz.название;
                //name_bilet.Text = zakaz.цена;
                //name_klient.Text = zakaz.наличие;
                name_excursions.Text = zakaz.название_события;
                name_data.Text = zakaz.день_и_время;

            


            }
        }

        private void nazad_button_Click(object sender, RoutedEventArgs e)
        {
            var window = new adminMain();
            window.Show();
            this.Close();
        }
    }
}
