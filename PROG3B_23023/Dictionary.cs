using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG3B_2023
{
    public class Dictionary

    {
        // Declaration of dictionary
        public Dictionary<string, string> Identifies = new Dictionary<string, string>();

        public void GenerateDictionary()
        {
            //Empties the dictionary
            Identifies.Clear();
            //Adds entries to the dictionary
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
        }
        }
    }
