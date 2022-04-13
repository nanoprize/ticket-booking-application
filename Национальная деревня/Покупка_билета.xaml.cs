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
    /// Логика взаимодействия для Покупка_билета.xaml
    /// </summary>
    public partial class Покупка_билета : Window
    {
        Entities entities = new Entities();
        private Заказ parent = new Заказ();
        public Покупка_билета()
        {
            InitializeComponent();
            print_button.Visibility = Visibility.Hidden;
            foreach (var bilet in entities.Билеты)
                spisok_biletov.Items.Add(bilet);
            foreach (var klient in entities.Посетители)
                spisok_fio.Items.Add(klient);
            
            foreach (var raspisanie in entities.Расписание)
                spisok_excursiy.Items.Add(raspisanie);
           
        }

        private void buy_bilet_Click(object sender, RoutedEventArgs e)
        {


            var zakaz = spisok_biletov.SelectedItem as Заказ;


            if (spisok_biletov.SelectedIndex == -1 || count_biletov.Text == "" || spisok_fio.SelectedIndex == -1)
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (zakaz == null)
                {
                    zakaz = new Заказ();
                    entities.Заказ.Add(zakaz);


                }
                zakaz.Id_посетителя = (spisok_fio.SelectedItem as Посетители).Id;
                zakaz.id_билета = (spisok_biletov.SelectedItem as Билеты).Id;
                zakaz.id_excursion = (spisok_excursiy.SelectedItem as Расписание).Id;


                zakaz.количество_билетов = Convert.ToInt32(count_biletov.Text);
                zakaz.итоговая_стоимость = Convert.ToInt32(itogo_price.Text);


                entities.SaveChanges();
                MessageBox.Show("Билет куплен", "Подтверждение", MessageBoxButton.OK, MessageBoxImage.Information);
                print_button.Visibility = Visibility.Visible;
               
            }
        }

        private void spisok_biletov_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected_bilet = spisok_biletov.SelectedItem as Билеты;
            if (selected_bilet != null)
            {
                price.Text = Convert.ToString(selected_bilet.цена);

            }
            else
            {
                price.Text = "";
            }
        }

       

        private void count_biletov_TextChanged(object sender, TextChangedEventArgs e)
        {
            var a = Convert.ToInt32(price.Text);
            var b = Convert.ToInt32(count_biletov.Text);
            var c = a * b;
            itogo_price.Text = Convert.ToString(c);
        }

        private void nazad_button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Экскурсии();
            window.Show();
            this.Close();
        }

        private void print_button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Title = "Сохранение файла";
            saveFileDialog1.Filter = "txt base files (*.txtbase)|*.txtbase|All files| *.*";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile());

                sw.WriteLine("Экскурсионный билет");
                sw.WriteLine("ФИО посетителя: "+ spisok_fio.Text);
                sw.WriteLine(spisok_biletov.Text);
                sw.WriteLine("Количество билетов: " + count_biletov.Text+ " штук");
                sw.WriteLine("Цена: " + itogo_price.Text + " рублей");
                sw.WriteLine("Приятного посещения!");


                sw.Close();
            }
        }
    }
}


