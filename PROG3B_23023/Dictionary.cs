using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;

namespace PROG3B_2023
{
    public class Dictionary

    {
        // Declaration of dictionary
        public Dictionary<string, string> Identifies = new Dictionary<string, string>();

        public void GenerateDictionaryEasy()
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

        public void GenerateDictionaryModerate()
        {
            //Empties the dictionary
            Identifies.Clear();
            //Adds entries to the dictionary
            Identifies.Add("Class 010", "Bibliographies");
            Identifies.Add("Class 020", "Library and information sciences");
            Identifies.Add("Class 030", "Encyclopedias and books of facts");
            Identifies.Add("Class 050", "Magazines, journals and serials");
            Identifies.Add("Class 060", "Associations, organizations and museums");
            Identifies.Add("Class 070", "News media, journalism, and publishing");
            Identifies.Add("Class 080", "Quotations");
            Identifies.Add("Class 090", "Manuscripts and rare books");
            Identifies.Add("Class 110", "Metaphysics");
            Identifies.Add("Class 120", "Epistemology");
            Identifies.Add("Class 130", "Parapsychology and occultism");
            Identifies.Add("Class 140", "Philosophical schools of thought");
            Identifies.Add("Class 150", "Psychology");
            Identifies.Add("Class 160", "Philosophical logic");
            Identifies.Add("Class 170", "Ethics");
            Identifies.Add("Class 180", "Ancient, medieval, and Eastern philosophy");
            Identifies.Add("Class 190", "Modern Western philosophy (19th-century, 20th-century) ");
            Identifies.Add("Class 210", "Philosophy and theory of religion");
            Identifies.Add("Class 220", "The Bible");
            Identifies.Add("Class 230", "Christianity");
            Identifies.Add("Class 240", "Christian practice and observance");
            Identifies.Add("Class 250", "Christian orders and local church");
            Identifies.Add("Class 260", "Social and ecclesiastical theology");
            Identifies.Add("Class 270", "History of Christianity");
            Identifies.Add("Class 280", "Christian denominations");
            Identifies.Add("Class 290", "Other religions");
            Identifies.Add("Class 310", "Statistics");
            Identifies.Add("Class 320", "Political science");
            Identifies.Add("Class 330", "Economics");
            Identifies.Add("Class 340", "Law");
            Identifies.Add("Class 350", "Public administration and military science");
            Identifies.Add("Class 360", "Social problems and social services");
            Identifies.Add("Class 370", "Education");
            Identifies.Add("Class 380", "Commerce, communications and transportation");
            Identifies.Add("Class 390", "Customs, etiquette and folklore");
            Identifies.Add("Class 410", "Linguistics");
            Identifies.Add("Class 420", "English and Old English languages");
            Identifies.Add("Class 430", "German and related languages");
            Identifies.Add("Class 440", "French and related languages");
            Identifies.Add("Class 450", "Italian, Romanian and related languages");
            Identifies.Add("Class 460", "Spanish, Portuguese, Galician");
            Identifies.Add("Class 470", "Latin and Italic languages");
            Identifies.Add("Class 480", "Classical and modern Greek languages");
            Identifies.Add("Class 490", "Other languages");
            Identifies.Add("Class 510", "Mathematics");
            Identifies.Add("Class 520", "Astronomy");
            Identifies.Add("Class 530", "Physics");
            Identifies.Add("Class 540", "Chemistry");
            Identifies.Add("Class 550", "Earth sciences and geology");
            Identifies.Add("Class 560", "Fossils and prehistoric life");
            Identifies.Add("Class 570", "Biology");
            Identifies.Add("Class 580", "Plants");
            Identifies.Add("Class 590", "Animals (Zoology)");
            Identifies.Add("Class 610", "Medicine and health");
            Identifies.Add("Class 620", "Engineering");
            Identifies.Add("Class 630", "Agriculture");
            Identifies.Add("Class 640", "Home and family management");
            Identifies.Add("Class 650", "Management and public relations");
            Identifies.Add("Class 660", "Chemical engineering");
            Identifies.Add("Class 670", "Manufacturing");
            Identifies.Add("Class 680", "Manufacture for specific uses");
            Identifies.Add("Class 690", "Construction of buildings");
            Identifies.Add("Class 710", "Area planning and landscape architecture");
            Identifies.Add("Class 720", "Architecture");
            Identifies.Add("Class 730", "Sculpture, ceramics and metalwork");
            Identifies.Add("Class 740", "Graphic arts and decorative arts");
            Identifies.Add("Class 750", "Painting");
            Identifies.Add("Class 760", "Printmaking and prints");
            Identifies.Add("Class 770", "Photography, computer art, film, video");
            Identifies.Add("Class 780", "Music");
            Identifies.Add("Class 790", "Sports, games and entertainment");
            Identifies.Add("Class 810", "American literature in English");
            Identifies.Add("Class 820", "English and Old English literatures");
            Identifies.Add("Class 830", "German and related literatures");
            Identifies.Add("Class 840", "French and related literatures");
            Identifies.Add("Class 850", "Italian, Romanian and related literatures");
            Identifies.Add("Class 860", "Spanish, Portuguese, Galician literatures");
            Identifies.Add("Class 870", "Latin and Italic literatures");
            Identifies.Add("Class 880", "Classical and modern Greek literatures");
            Identifies.Add("Class 890", "Other literatures");
            Identifies.Add("Class 910", "Geography and travel");
            Identifies.Add("Class 920", "Biography and genealogy");
            Identifies.Add("Class 930", "History of ancient world (to c. 499)");
            Identifies.Add("Class 940", "History of Europe");
            Identifies.Add("Class 950", "History of Asia");
            Identifies.Add("Class 960", "History of Africa");
            Identifies.Add("Class 970", "History of North America");
            Identifies.Add("Class 980", "History of South America");
            Identifies.Add("Class 990", "History of other areas");
        }

        //Gets the data from the text file DeweyClasses.txt adds it to the dictionary
        public void GenerateDictionaryExpert()
        {
            //Empties the dictionary
            Identifies.Clear();
            var array = File.ReadAllLines("C:\\Users\\NIKYLE\\source\\repos\\PROG3B_23023\\PROG3B_23023\\DeweyClasses.txt");
            for (var i = 0; i < array.Length; i += 2)
            {
                string temp = array[i].Trim();
                string temp2 = array[i + 1].Trim();
                if (temp.Length != 0 && temp2.Length != 0)
                {
                    Identifies.Add(array[i], array[i + 1]);
                }
                
            }
        }

    }
}
