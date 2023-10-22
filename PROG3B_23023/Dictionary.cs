using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG3B_2023
{
    public class Dictionary

    {
        // Declaration and intialization of dictionary
        public Dictionary<string, string> Identifies = new Dictionary<string, string>();
         
        public void GenerateDictionary()
        {
            Identifies.Add("Class 000", "General Works");
            Identifies.Add("Class 100", "Philosophy");
            Identifies.Add("Class 200", "Religion");
            Identifies.Add("Class 300", "Social Science");
            Identifies.Add("Class 400", "Language");
            Identifies.Add("Class 500", "Pure Science");
            Identifies.Add("Class 600", "Technology");
            Identifies.Add("Class 700", "Arts");
            Identifies.Add("Class 800", "Literature");
            Identifies.Add("Class 900", "History and Geography");
            //{"General Works", "Class 000"},
            //{"Philosophy", "Class 100"},
            //{"Religion", "Class 200"},
            //{"Social Science", "Class 300"},
            //{"Language", "Class 400"},
            //{"Pure Science", "Class 500"},
            //{"Technology", "Class 600"},
            //{"Arts", "Class 700"},
            //{"Literature", "Class 800"},
            //{"History and Geography", "Class 900"},
                                            }
        public void GenerateQuestions()
        {

            Identify identify = new Identify();
            for (int i = 0; i <= 5; i++) {
                int z = 9;
                Random rand = new Random();
                int x = rand.Next(z);
                string y = Identifies.ElementAt(x).Value;
                string z2 = Identifies.ElementAt(x).Key;
                Identifies.Remove(z2);
                z--;
                identify.answers.Add(y);
                identify.questions.Add(z2);
                
                //identify.
                //string y = Identify.ElementAt(rand.Next(0, Identify.Count)).Value;
            }
        }
    }
}
