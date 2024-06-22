using PROG3B_23023;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        public string question, answer;
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
            CanMark();
        }


        void CanQuestionsGenerate()
        {
            count++;
            //Controls whether the callnumbers or description have extra options
            if (Question.Items.Count < 1)
            {
                progcount = 0;
                Progress.Value = 0;
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
            int randomQuestion = 5;
            int randomAnswer = 8;
            dict.GenerateDictionary();
            Random rand = new Random();

            questionHeading.Content = "Class Number";
            answerHeading.Content = "Description";

            // Generates the five pairs of descriptions and matching callnumbers
            for (int i = 0; i < 5; i++)
            {
                int x = rand.Next(potentialAnswers);
                //Adds the descriptions and callnumbers to the lists
                answers.Add(dict.Identifies.ElementAt(x).Value);
                questions.Add(dict.Identifies.ElementAt(x).Key);
                //removes the entry from the dictionary to prevent it from being used again
                dict.Identifies.Remove(dict.Identifies.ElementAt(x).Key);
                dict.Identifies.Remove(dict.Identifies.ElementAt(x).Value);
                potentialAnswers--;
            }

            //Generates the excess descriptions
            for (int i = 0; i < 3; i++)
            {
                int a = rand.Next(potentialAnswers);
                answers.Add(dict.Identifies.ElementAt(a).Value);
                dict.Identifies.Remove(dict.Identifies.ElementAt(a).Key);
                dict.Identifies.Remove(dict.Identifies.ElementAt(a).Value);
                potentialAnswers--;
            }

            for (int i = 0; i < 7; i++)
            {
                int y = rand.Next(randomAnswer);
                Answer.Items.Add(answers[y]);
                answers.RemoveAt(y);
                randomAnswer--;
            }
            Answer.Items.Add(answers[0]);

            for (int i = 0; i < 4; i++)
            {
                int y = rand.Next(randomQuestion);
                Question.Items.Add(questions[y]);
                questions.RemoveAt(y);
                randomQuestion--;
            }
            Question.Items.Add(questions[0]);
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
            int randomQuestion = 5;
            int randomAnswer = 8;
            dict.GenerateDictionary();
            Random rand = new Random();

            questionHeading.Content = "Description";
            answerHeading.Content = "Class Number";

            // Generates the five pairs of descriptions and matching callnumbers
            for (int i = 0; i < 5; i++)
            {
                int x = rand.Next(z);
                //Adds the descriptions and callnumbers to the lists
                answers.Add(dict.Identifies.ElementAt(x).Key);
                questions.Add(dict.Identifies.ElementAt(x).Value);
                //removes the entry from the dictionary to prevent it from being used again
                dict.Identifies.Remove(dict.Identifies.ElementAt(x).Key);
                dict.Identifies.Remove(dict.Identifies.ElementAt(x).Value);
                z--;
            }

            //Generates the excess callnumbers
            for (int i = 0; i < 3; i++)
            {
                int a = rand.Next(z);
                answers.Add(dict.Identifies.ElementAt(a).Key);
                //removes the entry from the dictionary to prevent it from being used again
                dict.Identifies.Remove(dict.Identifies.ElementAt(a).Key);
                dict.Identifies.Remove(dict.Identifies.ElementAt(a).Value);
                z--;
            }

            for(int i = 0;i < 4; i++)
            {
                int y = rand.Next(randomQuestion);
                Question.Items.Add(questions[y]);
                questions.RemoveAt(y);
                randomQuestion--;
            }
            Question.Items.Add(questions[0]); 

            for (int i = 0; i < 7; i++)
            {
                int y = rand.Next(randomAnswer);
                Answer.Items.Add(answers[y]);
                answers.RemoveAt(y);
                randomAnswer--;
            }
            Answer.Items.Add(answers[0]);
        }


        public void GetSelectedValues()
        {
            //checks if the are selected items
            if (Question.SelectedItems.Count > 0)
            {
                //gets the value from the listview and stores it in a variable
                var q = Question.SelectedItems[0];
                question = q.ToString();
            }
            if(Answer.SelectedItems.Count > 0)
            {
                //gets the value from the listview and stores it in a variable
                var a = Answer.SelectedItems[0];
                answer = a.ToString();
            }
        }


        

        void CanMark()
        {
            GetSelectedValues();
            // check that the user has selected values from both listviews
            if (question != null && answer != null)
            {
                Mark();
            }
            else
            {
                MessageBox.Show("Please select matching terms from both columns", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void Mark()
        {
            Dictionary dict = new Dictionary();
            dict.GenerateDictionary();
            string value;
            if (count == 1) {

                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(question, answer);
                //Gets the correct value from the dictionary
                if (dict.Identifies.TryGetValue(kvp.Key, out value))
                {

                    //compares the dictionary value to the selected value
                    if (answer == value.ToString())
                    {

                       MessageBox.Show("Correct", "Correct", MessageBoxButton.OK);
                       progcount++;
                       //Removes the items from the listviews
                       Question.Items.Remove(kvp.Key);
                       Answer.Items.Remove(kvp.Value);
                       Progress.Value = progcount * 20;
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
                       MessageBox.Show("Incorrect, Please try again", "Incorrect", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(answer, question);
                if (dict.Identifies.TryGetValue(kvp.Key, out value))
                {
                    // compares the selected value and the value from the dictionary
                    if (question == value.ToString())
                    {
                        MessageBox.Show("Correct");
                        progcount++;
                        Progress.Value = progcount * 20;
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
                        MessageBox.Show("Incorrect, Please try again", "Incorrect", MessageBoxButton.OK, MessageBoxImage.Error);
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
