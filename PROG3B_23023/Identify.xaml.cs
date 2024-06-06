using PROG3B_23023;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
        //Declarations
        public List<string> questions = new List<string>();
        public List<string> answers = new List<string>();
        public int count = 0;
        public int progcount;
        public string itemq, itema;
        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu();
            
        }


        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            ShowInstructions();
        }


        private void Load_Click(object sender, RoutedEventArgs e)
        {
            CanQuestionsGenerate();
        }


        private void Mark_Click(object sender, RoutedEventArgs e)
        {
            GetSelectedValues();
            // check that the user has selected values from both listviews
            if(itemq != null && itema != null)
            {
                Mark1();
            }
            else
            {
                MessageBox.Show("Please select matching terms from both columns", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        void CanQuestionsGenerate()
        {
            count++;
            //Controls whether the callnumbers or description have extra options
            if (Question.Items.Count < 1)
            {
                progcount = 0;
                Progess.Value = 0;
                if (count == 1)
                {
                    //Generates callnumbers and excess descriptions
                    GenerateQuestions();
                }
                else
                {
                    //Generates descriptions and excess callnumbers
                    count = 0;
                    GenerateAnswers();
                }
            }
            else
            {
                MessageBox.Show("Please complete the current questions before loading more", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void GenerateQuestions()
        {
            //Clears the listviews and lists
            Question.Items.Clear();
            Answer.Items.Clear();
            questions.Clear();
            answers.Clear();
            Dictionary dict = new Dictionary();
            int potentialAnswers = 9;
            dict.GenerateDictionary();
            Random rand = new Random();
            // Generates the five pairs of descriptions and matching callnumbers
            for (int i = 0; i < 5; i++)
            {
                int x = rand.Next(potentialAnswers);
                //removes the entry from the dictionary to prevent it from being used again
                dict.Identifies.Remove(dict.Identifies.ElementAt(x).Key);
                potentialAnswers--;
                //Adds the descriptions and callnumbers to the lists
                answers.Add(dict.Identifies.ElementAt(x).Value);
                questions.Add(dict.Identifies.ElementAt(x).Key);
            }
            //Generates the excess descriptions
            for (int i = 0; i < 3; i++)
            {
                int a = rand.Next(potentialAnswers);
                dict.Identifies.Remove(dict.Identifies.ElementAt(a).Key);
                answers.Add(dict.Identifies.ElementAt(a).Value);
                potentialAnswers--;
            }
                foreach (string a in questions)
            {
                Question.Items.Add(a);
            }
            foreach (string num2 in answers)
            {
                Answer.Items.Add(num2);
            }
        }


        public void GenerateAnswers()
        {
            //Clears the listviews and lists
            Question.Items.Clear();
            Answer.Items.Clear();
            questions.Clear();
            answers.Clear();
            Dictionary dict = new Dictionary();
            int z = 9;
            dict.GenerateDictionary();
            Random rand = new Random();
            // Generates the five pairs of descriptions and matching callnumbers
            for (int i = 0; i < 5; i++)
            {
                int x = rand.Next(z);
                string y = dict.Identifies.ElementAt(x).Value;
                string z2 = dict.Identifies.ElementAt(x).Key;
                //removes the entry from the dictionary to prevent it from being used again
                dict.Identifies.Remove(z2);
                z--;
                //Adds the descriptions and callnumbers to the lists
                answers.Add(z2);
                questions.Add(y);
            }
            //Generates the excess callnumbers
            for (int i = 0; i < 3; i++)
            {
                int a = rand.Next(z);
                string c = dict.Identifies.ElementAt(a).Key;
                string b = dict.Identifies.ElementAt(a).Value;
                answers.Add(c);
                //removes the entry from the dictionary to prevent it from being used again
                dict.Identifies.Remove(c);
                z--;
            }
            foreach (string a in questions)
            {
                //adds each description to the first listview
                Question.Items.Add(a);
            }
            foreach (string num2 in answers)
            {
                //adds each call number to the second listview
                Answer.Items.Add(num2);
            }
        }


        public void GetSelectedValues()
        {
            //checks if the are selected items
            if (Question.SelectedItems.Count > 0)
            {
                //gets the value from the listview and stores it in a variable
                var q = Question.SelectedItems[0];
                itemq = q.ToString();
            }
            if(Answer.SelectedItems.Count > 0)
            {
                //gets the value from the listview and stores it in a variable
                var a = Answer.SelectedItems[0];
                itema = a.ToString();
            }
        }


        public string value;


        public void Mark1()
        {
            Dictionary dict = new Dictionary();
            dict.GenerateDictionary();
            if (count == 1) {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(itemq, itema);
                //Gets the correct value from the dictionary
                if (dict.Identifies.TryGetValue(kvp.Key, out value))
                {
                    //compares the dictionary value to the selected value
                    if (itema == value.ToString())
                    {
                       MessageBox.Show("Correct");
                       progcount++;
                       //Removes the items from the listviews
                       Question.Items.Remove(kvp.Key);
                       Answer.Items.Remove(kvp.Value);
                       Progess.Value = progcount * 20;
                       if (Question.Items.Count == 0)
                       {
                           MessageBoxResult dialogResult = MessageBox.Show("Would you like to play again", "Play again?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                           if (dialogResult == MessageBoxResult.Yes)
                           {
                               CanQuestionsGenerate();
                           }
                       }
                    }
                    else
                    {
                       MessageBox.Show("Incorrect, Please try again");
                    }
                }
            }
            else
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(itema, itemq);
                if (dict.Identifies.TryGetValue(kvp.Key, out value))
                {
                    // compares the selected value and the value from the dictionary
                    if (itemq == value.ToString())
                    {
                        MessageBox.Show("Correct");
                        //Removes the values from the listviews
                        Question.Items.Remove(kvp.Value);
                        Answer.Items.Remove(kvp.Key);
                        if(Question.Items.Count == 0)
                        {
                            MessageBoxResult dialogResult = MessageBox.Show("Would you like to play again", "Play again?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                            if (dialogResult == MessageBoxResult.Yes)
                            {
                                CanQuestionsGenerate();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect, Please try again");
                    }
                }
            }
        }

        void ShowInstructions()
        {
            MessageBox.Show("Click start for the game to begin, then select a pair of matching values and click match",
                "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        void MainMenu()
        {
            //takes the user back to the main menu
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

    }
}
