using PROG3B_2023;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG3B_23023
{
    /// <summary>
    /// Interaction logic for SortingGame.xaml
    /// </summary>
    public partial class SortingGame : Page
    {
        public SortingGame()
        {
            InitializeComponent();
        }

        //Declarations
        public List<CallNumber> numberkeep = new List<CallNumber>();
        public List<CallNumber> number = new List<CallNumber>();
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Mark_Click(object sender, RoutedEventArgs e)
        {
            if (Check() == true)
            {
                Mark();
            }
        }

        private void Instructions_Click(object sender, RoutedEventArgs e)
        {
            ShowInstructions();
        }
        private void Unsorted_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
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
            var myObj = e.Data.GetData(DataFormats.Text);
            Unsorted.Items.Remove(Unsorted.SelectedItem);
            Sorted.Items.Add(myObj);

            if (Sorted.Items.Contains(Sorted.SelectedItem))
            {
                Sorted.Items.Remove(Unsorted.SelectedItem);
                Sorted.Items.Remove(Sorted.SelectedItem);
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

        }
        // Receives the random callnumbers and adds them to the listview randomly

        void Load()
        {
            Unsorted.Items.Clear();
            Sorted.Items.Clear();
            Numbers numbers = new Numbers();
            numberkeep = numbers.RandomNumber();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(0, numberkeep.Count - 1);
                Unsorted.Items.Add(string.Join(" ", numberkeep[x].callNumber, numberkeep[x].Author));
                numberkeep.RemoveAt(x);
            }
        }

        //Checks to see if the user has completed the task correctly
        bool Check()
        {
            Numbers numbers = new Numbers();
            if (Unsorted.Items.Count == 0 && Sorted.Items.Count == 0)
            {
                MessageBox.Show("Please click the Start button to begin the game", "Invalid", MessageBoxButton.OK);
                return false;
            }
            else if (Sorted.Items.Count < 10)
            {
                MessageBox.Show("Please sort the numbers before clicking mark", "Incomplete", MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /* This method adds the callnumbers back into a list, sorts the callnumbers,
         then it compares two lists to see if they have the same order and displays the result to the user*/
        void Mark()
        {
            number.Clear();
            numberkeep.Clear();

            for (int i = 0; i < Sorted.Items.Count; i++)
            {
                string item = Sorted.Items[i].ToString();
                int spaceIndex = item.IndexOf(" ");
                int callnumber = Convert.ToInt32(item.Substring(0, spaceIndex));
                string author = item.Substring(spaceIndex + 1);
                number.Add(new CallNumber(callnumber, author));
                numberkeep.Add(new CallNumber(callnumber, author));

            }
            bubbleSort(number);
            int count = 0;
            for (int i = 0; i < Sorted.Items.Count; i++)
            {
                if (numberkeep[i].callNumber == number[i].callNumber)
                {
                    count++;
                }
            }
            if (count == 10)
            {
                MessageBox.Show("CORRECT", "Correct", MessageBoxButton.OK);
                Sorted.Items.Clear();
            }
            else
            {
                MessageBox.Show("INCORRECT", "Incorrect, please try again",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                Sorted.Items.Clear();
                Load();
            }
        }

        void ShowInstructions()
        {
            MessageBox.Show("Click start for the game to begin, sort the call numbers into Ascending order, by dragging them into the box call sorted",
                "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        List<CallNumber> bubbleSort(List<CallNumber> number)
        {
            for (int i = 0; i < number.Count - 1; i++)
            {
                for (int k = (i + 1); k < number.Count; k++)
                {
                    if (number[i].callNumber > number[k].callNumber)
                    {
                        CallNumber temp = number[i];
                        number[i] = number[k];
                        number[k] = temp;
                    }
                }
            }
            return number;
        }
    }
}

