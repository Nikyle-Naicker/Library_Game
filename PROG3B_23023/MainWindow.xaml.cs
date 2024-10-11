using PROG3B_23023;
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
            Main.Content = new SortingGame();
        }

        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SortingGame();
        }

        private void Identify_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new MatchTheColumn();
        }

        private void Call_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Game currently in development check back later", "", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

    }
}
