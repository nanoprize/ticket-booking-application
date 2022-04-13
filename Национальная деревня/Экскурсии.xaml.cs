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
    /// Логика взаимодействия для Экскурсии.xaml
    /// </summary>
    public partial class Экскурсии : Window
    {
        Entities entities = new Entities();
        public Экскурсии()
        {
            InitializeComponent();
            list_raspisaniy.ItemsSource = Entities.GetContext().Расписание.ToList();
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new Покупка_билета();
            window.Show();
            this.Close();
        }

        private void nazad_button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

       

        private void list_raspisaniy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ivent = list_raspisaniy.SelectedItem as Расписание;
        }

       

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var raspisanie = entities.Расписание.ToList();
            raspisanie = raspisanie.Where(p => p.день_и_время.ToLower().Contains(search.Text.ToLower())).ToList();

            list_raspisaniy.ItemsSource = raspisanie;
        }
    }
}
