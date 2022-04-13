﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Национальная_деревня
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void excursions_page_Click(object sender, RoutedEventArgs e)
        {
            var window = new Экскурсии();
            window.Show();
            this.Close();
        }

        private void nazad_button_Click(object sender, RoutedEventArgs e)
        {
            var window = new Вход();
            window.Show();
            this.Close();
        }
    }
}
