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
using System.Windows.Shapes;

namespace PROG3B_2023
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            // Takes the user to the first game
            Replace replace = new Replace();
            this.Close();
            replace.Show();
        }

        private void Identify_Click(object sender, RoutedEventArgs e)
        {
            //informs user
            MessageBox.Show("This game has not been implemented yet", "Coming Soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Call_Click(object sender, RoutedEventArgs e)
        {
            //informs user
            MessageBox.Show("This game has not been implemented yet", "Coming Soon", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
