using System;
using System.Collections;
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
    /// Interaction logic for Replace.xaml
    /// </summary>
    public partial class Replace : Window
    {
        public Replace()
        {
            InitializeComponent();
        }

        //Declarations for lists
        public List<CallNumber> mark = new List<CallNumber>();
        public List<CallNumber> numberkeep = new List<CallNumber>();

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Mark_Click(object sender, RoutedEventArgs e)
        {
            if(Check() == true)
            {
                Mark();
            }
        }
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            // Takes the user to the main menu
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
            
        }
        private void Unsorted_MouseMove(object sender, MouseEventArgs e)
        {
            // Handles logic for when user clicks and drags item
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Prevents app from crashing when dragging nothing
                if (Unsorted.SelectedItem != null)
                {
                    DragDrop.DoDragDrop(this, Unsorted.SelectedItem.ToString(), DragDropEffects.Move);
                }
            }
            Progress.Visibility = Visibility.Visible;
            Progress.Value = Sorted.Items.Count * 10;
        }

        private void Sorted_Drop(object sender, DragEventArgs e)
        {
            // Handles the logic for when user drop item in the listview
            var myObj = e.Data.GetData(DataFormats.Text);
            Unsorted.Items.Remove(Unsorted.SelectedItem);
            Sorted.Items.Add(myObj);

            if (Sorted.Items.Contains(Sorted.SelectedItem))
            {
                Sorted.Items.Remove(Unsorted.SelectedItem);
                Sorted.Items.Remove(Sorted.SelectedItem);
            }

            if (Sorted.Items.Count > 0)
            {
                btnMark.IsEnabled = true;
            }
        }

        private void Sorted_MouseMove(object sender, MouseEventArgs e)
        {
            // Handles logic for when user clicks and drags item
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //Prevents app from crashing when dragging nothing
                if (Sorted.SelectedItem != null)
                {
                    DragDrop.DoDragDrop(this, Sorted.SelectedItem.ToString(), DragDropEffects.Move);

                }
            }
        }

        private void Unsorted_Drop(object sender, DragEventArgs e)
        {
            // Handles the logic for when user drop item in the listview
            var myObj = e.Data.GetData(DataFormats.Text);
            Sorted.Items.Remove(Sorted.SelectedItem);
            Unsorted.Items.Add(myObj);

            if (Unsorted.Items.Contains(Unsorted.SelectedItem))
            {

                Unsorted.Items.Remove(Sorted.SelectedItem);
                Unsorted.Items.Remove(Unsorted.SelectedItem);
            }
            if (Sorted.Items.Count < 1)
            {
                btnMark.IsEnabled = false;
            }

        }

        void Load()
        {
            //Clears the listviews
            Unsorted.Items.Clear();
            Sorted.Items.Clear();
            Numbers numbers = new Numbers();
            // calls the generate code method
            numbers.RandomNumber();
            // calls the sort method
            numbers.bubbleSort(numbers.checks);
            mark = numbers.checks.ToList();
            // Adds the list objects to the unsorted listview
            foreach (CallNumber x in numbers.nums)
            {
                Unsorted.Items.Add(string.Join(" ", x.callNumber, x.Author));
            }
        }

        bool Check()
        {
            Numbers numbers = new Numbers();
            if(Unsorted.Items.Count == 0 && Sorted.Items.Count == 0)
            {
                MessageBox.Show("Please click the Start button to begin the game", "Invalid", MessageBoxButton.OK);
                return false;
            }
            else if(Sorted.Items.Count < 9)
            {
                MessageBox.Show("Please sort the numbers before clicking mark", "Incomplete", MessageBoxButton.OK);
                return false;
            }
            return true;
        }
        void Mark() 
        {
            for (int i = 0; i < Sorted.Items.Count; i++)
            {
                string item = Sorted.Items[i].ToString();
                int spaceIndex = item.IndexOf(" ");
                int callnumber = Convert.ToInt32(item.Substring(0, spaceIndex));
                string author = item.Substring(spaceIndex + 1);
                // Adds the user sorted list to new list
                numberkeep.Add(new CallNumber(callnumber, author));
            }
            int count = 0;
            if (numberkeep.Count == mark.Count)
            {
                for (int i = 0; i < mark.Count; i++)
                {
                    if (mark[i].callNumber.Equals(numberkeep[i].callNumber) &&
                        numberkeep[i].Author.CompareTo(mark[i].Author) == 0)
                    {
                        count++;
                    }
                }
            }
            // Displays a correct notification 
            if (numberkeep.Count == mark.Count)
            {
                MessageBox.Show("CORRECT", "Correct", MessageBoxButton.OK);
                numberkeep.Clear();
                Load();
            }
            else // Displays an incorrect notification 
            {
                MessageBox.Show("INCORRECT", "Incorrect",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                numberkeep.Clear();
            }
        }
    }
}
