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
    /// Interaction logic for Identify.xaml
    /// </summary>
    public partial class Identify : Window
    {
        public Identify()
        {
            InitializeComponent();
        }
        public List<string> questions = new List<string>();
        public List<string> answers = new List<string>();

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Dictionary dict = new Dictionary();
            dict.GenerateDictionary();
            dict.GenerateQuestions();
            foreach(string x in questions) 
            { 
            Question.Items.Add(x);
            }
            Answer.Items.Add(answers);
        }
        private void Mark_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
