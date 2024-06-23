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
        List<string> questions = new List<string>();
        List<string> answers = new List<string>();
        int count = 0;
        int progcount;
        string question, answer;

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

        /* This method controls whether the application generates classes
           or descriptions in the left column.*/
        void CanQuestionsGenerate()
        {
            count++;
            if (Question.Items.Count < 1)
            {
                progcount = 0;
                Progress.Value = 0;
                if (count == 1)
                {
                    GenerateClasses();
                }
                else
                {
                    count = 0;
                    GenerateDescriptions();
                }
            }
            else
            {
                MessageBox.Show("Please complete the current questions before loading more", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /* Generates 5 class numbers with matching descriptions,
           3 excess descriptions and assigns them to the listviews*/
        public void GenerateClasses()
        {
            Question.Items.Clear();
            Answer.Items.Clear();
            questions.Clear();
            answers.Clear();

            Dictionary dict = new Dictionary();
            dict.GenerateDictionary();
            int potentialAnswers = 9;
            int randomQuestion = 5;
            int randomAnswer = 8;
            Random rand = new Random();

            questionHeading.Content = "Class Number";
            answerHeading.Content = "Description";

            // Generates the five pairs of descriptions and matching callnumbers
            for (int i = 0; i < 5; i++)
            {
                int randomNumber = rand.Next(potentialAnswers);

                answers.Add(dict.Identifies.ElementAt(randomNumber).Value);
                questions.Add(dict.Identifies.ElementAt(randomNumber).Key);

                dict.Identifies.Remove(dict.Identifies.ElementAt(randomNumber).Key);
                dict.Identifies.Remove(dict.Identifies.ElementAt(randomNumber).Value);

                potentialAnswers--;
            }

            //Generates the excess descriptions
            for (int i = 0; i < 3; i++)
            {
                int randomNumber = rand.Next(potentialAnswers);

                answers.Add(dict.Identifies.ElementAt(randomNumber).Value);

                dict.Identifies.Remove(dict.Identifies.ElementAt(randomNumber).Key);
                dict.Identifies.Remove(dict.Identifies.ElementAt(randomNumber).Value);

                potentialAnswers--;
            }

            //Assigns the descriptions in a random order
            for (int i = 0; i < 7; i++)
            {
                int randomNumber = rand.Next(randomAnswer);

                Answer.Items.Add(answers[randomNumber]);
                answers.RemoveAt(randomNumber);

                randomAnswer--;
            }
            Answer.Items.Add(answers[0]);

            //Assigns the callnumber in a random order
            for (int i = 0; i < 4; i++)
            {
                int randomNumber = rand.Next(randomQuestion);

                Question.Items.Add(questions[randomNumber]);
                questions.RemoveAt(randomNumber);

                randomQuestion--;
            }
            Question.Items.Add(questions[0]);
        }

        /* Generates 5 descriptions with matching class numbers,
           3 excess class numbers and assigns them to the listviews*/
        public void GenerateDescriptions()
        {

            Question.Items.Clear();
            Answer.Items.Clear();
            questions.Clear();
            answers.Clear();

            Dictionary dict = new Dictionary();
            int potentialAnswer = 9;
            int randomQuestion = 5;
            int randomAnswer = 8;
            dict.GenerateDictionary();
            Random rand = new Random();

            questionHeading.Content = "Description";
            answerHeading.Content = "Class Number";

            // Generates the five pairs of descriptions and matching callnumbers
            for (int i = 0; i < 5; i++)
            {
                int randomNumber = rand.Next(potentialAnswer);

                answers.Add(dict.Identifies.ElementAt(randomNumber).Key);
                questions.Add(dict.Identifies.ElementAt(randomNumber).Value);

                dict.Identifies.Remove(dict.Identifies.ElementAt(randomNumber).Key);
                dict.Identifies.Remove(dict.Identifies.ElementAt(randomNumber).Value);
                potentialAnswer--;
            }

            //Generates the excess callnumbers
            for (int i = 0; i < 3; i++)
            {
                int randomNumber = rand.Next(potentialAnswer);
                answers.Add(dict.Identifies.ElementAt(randomNumber).Key);

                dict.Identifies.Remove(dict.Identifies.ElementAt(randomNumber).Key);
                dict.Identifies.Remove(dict.Identifies.ElementAt(randomNumber).Value);
                potentialAnswer--;
            }

            //Assigns the descriptions in a random order
            for (int i = 0;i < 4; i++)
            {
                int randomNumber = rand.Next(randomQuestion);

                Question.Items.Add(questions[randomNumber]);
                questions.RemoveAt(randomNumber);

                randomQuestion--;
            }
            Question.Items.Add(questions[0]);

            //Assigns the callnumbers in a random order
            for (int i = 0; i < 7; i++)
            {
                int randomNumber = rand.Next(randomAnswer);

                Answer.Items.Add(answers[randomNumber]);
                answers.RemoveAt(randomNumber);

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
                var selectedQuestion = Question.SelectedItems[0];
                question = selectedQuestion.ToString();
            }
            if(Answer.SelectedItems.Count > 0)
            {
                //gets the value from the listview and stores it in a variable
                var selectedAnswer = Answer.SelectedItems[0];
                answer = selectedAnswer.ToString();
            }
        }
        
        //Checks to see that items from both columns have been selected
        void CanMark()
        {
            GetSelectedValues();
            if (question != null && answer != null)
            {
                Mark();
            }
            else
            {
                MessageBox.Show("Please select matching terms from both columns", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /* Checks to see if the selected values match and display the result
         * to the user*/
        public void Mark()
        {
            Dictionary dict = new Dictionary();
            dict.GenerateDictionary();
            string value;
            if (count == 1) {

                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(question, answer);
                //Gets the correct value from the dictionary
                dict.Identifies.TryGetValue(kvp.Key, out value);

                //compares the dictionary value to the selected value
                if (answer == value.ToString())
                {

                    MessageBox.Show("Correct", "Correct", MessageBoxButton.OK);
                    progcount++;

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
            else
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(answer, question);
                dict.Identifies.TryGetValue(kvp.Key, out value);
        
                // compares the selected value and the value from the dictionary
                if (question == value.ToString())
                {
                    MessageBox.Show("Correct");
                    progcount++;
                    Progress.Value = progcount * 20;

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

        //Displays instructions to the user
        void ShowInstructions()
        {
            MessageBox.Show("Click start for the game to begin, then select a pair of matching values and click match",
                "Instructions", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //takes the user back to the main menu
        void MainMenu()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

    }
}
