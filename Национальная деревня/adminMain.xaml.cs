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
    /// Логика взаимодействия для adminMain.xaml
    /// </summary>
    public partial class adminMain : Window
    {
        public adminMain()
        {
            InitializeComponent();
        }

        private void posetiteli_page_Click(object sender, RoutedEventArgs e)
        {
            var window = new posetiteli_admin();
            window.Show();
            this.Close();
        }

        private void event_page_Click(object sender, RoutedEventArgs e)
        {
            var window = new excursions_admin();
            window.Show();
            this.Close();
        }

        private void order_page_Click(object sender, RoutedEventArgs e)
        {
            var window = new order_admin();
            window.Show();
            this.Close();
        }
    }
}
