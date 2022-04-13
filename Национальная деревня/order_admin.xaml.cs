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
    /// Логика взаимодействия для order_admin.xaml
    /// </summary>
    public partial class order_admin : Window
    {
        Entities entities = new Entities();
        public order_admin()
        {
            InitializeComponent();
            list_zakazov.ItemsSource = entities.Заказ.ToList();
            foreach (var bilet in entities.Билеты)
                spisok_biletov.Items.Add(bilet);
            foreach (var klient in entities.Посетители)
                spisok_klientov.Items.Add(klient);

            foreach (var raspisanie in entities.Расписание)
                spisok_excursions.Items.Add(raspisanie);
        }

        private void list_zakazov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var zakaz = list_zakazov.SelectedItem as Заказ;
            if (zakaz != null)
            {
                //name_excursions.Text = zakaz.название;
                //name_bilet.Text = zakaz.цена;
                //name_klient.Text = zakaz.наличие;
                count_bilet.Text = Convert.ToString(zakaz.количество_билетов);
                name_itogo.Text = Convert.ToString(zakaz.итоговая_стоимость);
                spisok_biletov.SelectedItem = (from vid in entities.Билеты where vid.Id == zakaz.id_билета select vid).Single<Билеты>();
                    spisok_klientov.SelectedItem = (from vid in entities.Посетители where vid.Id == zakaz.Id_посетителя select vid).Single<Посетители>();
                spisok_excursions.SelectedItem = (from vid in entities.Расписание where vid.Id == zakaz.id_excursion select vid).Single<Расписание>();
            }
        }

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {
            list_zakazov.ItemsSource = entities.Заказ.ToList();
            list_zakazov.SelectedIndex = -1;
        }

        private void save_button_Click(object sender, RoutedEventArgs e)
        {
            var save_all = list_zakazov.SelectedItem as Заказ;
            if (spisok_excursions.SelectedIndex == -1 || spisok_biletov.SelectedIndex == -1 || spisok_klientov.SelectedIndex == -1 || count_bilet.Text == "" || name_itogo.Text == "")
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            if (save_all == null)
            {
                save_all = new Заказ();
                entities.Заказ.Add(save_all);
            }
            save_all.Id_посетителя = (spisok_klientov.SelectedItem as Посетители).Id; 
            save_all.id_билета = (spisok_biletov.SelectedItem as Билеты).Id;
            save_all.id_excursion = (spisok_excursions.SelectedItem as Расписание).Id; 


            save_all.итоговая_стоимость = Convert.ToInt32(name_itogo.Text);
            save_all.количество_билетов = Convert.ToInt32(count_bilet.Text);
            
            entities.SaveChanges();
            MessageBox.Show("Заказ добавлен", "Подтверждение", MessageBoxButton.OK, MessageBoxImage.Information);
            list_zakazov.ItemsSource = entities.Заказ.ToList();
        }

        private void delete_button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить данную запись?", "Предупреждение",
               MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                entities.Заказ.Remove(list_zakazov.SelectedItem as Заказ);
                try
                {
                    entities.SaveChanges();
                    MessageBox.Show("Запись успешно удалена", "Успех!");
                    list_zakazov.ItemsSource = entities.Расписание.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

        }

        private void clear_button_Click(object sender, RoutedEventArgs e)
        {
            spisok_excursions.SelectedIndex = -1;
            spisok_biletov.SelectedIndex = -1;
            spisok_klientov.SelectedIndex = -1;
            count_bilet.Clear();
            name_itogo.Clear();
            list_zakazov.SelectedIndex = -1;
          
        }

        private void nazad_button_Click(object sender, RoutedEventArgs e)
        {
            var window = new adminMain();
            window.Show();
            this.Close();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var zakaz = entities.Заказ;
        //    var query_zakaz = from Ведение_заказов in zakaz
        //                      orderby Ведение_заказов.название_доставки
        //                      select Ведение_заказов;
        //    foreach (Ведение_заказов pr in query_zakaz)
        //    {
        //        ListZakaz.Add(pr);
        //    }
        //    list_zakazov.ItemsSource = ListZakaz;
        //}
    }
}
