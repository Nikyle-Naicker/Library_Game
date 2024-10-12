using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace PROG3B_2023
{

    // Generates the random callnumbers that are returned in a List

    class Numbers
    {
        
        public List<CallNumber> nums = new List<CallNumber>();
        int y;
        public List<CallNumber> RandomNumberEasy()
        {
            // declarations
            StringBuilder builder = new StringBuilder();
            StringBuilder strbuilder = new StringBuilder();
            Random random = new Random();
            char letter;
            // Generates the random call numbers
            for (int i = 0; i <= 9; i++)
            {
                builder.Clear();
                strbuilder.Clear();
                for (int x = 0; x <= 5; x++)
                {
                    var call1 = random.Next(0, 10);
                    builder.Append(call1);
                }
                for (int z = 0; z <= 2; z++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    strbuilder.Append(letter);
                }

                y = Convert.ToInt32(builder.ToString());
                // adds the values to the lists
                nums.Add(new CallNumber(y, strbuilder.ToString()));
            }
            return nums;
        }

        public List<CallNumber> RandomNumberModerate()
        {
            // declarations
            StringBuilder builder = new StringBuilder();
            StringBuilder strbuilder = new StringBuilder();
            Random random = new Random();
            char letter;
            // Generates the random call numbers
            for (int i = 0; i <= 8; i++)
            {
                builder.Clear();
                strbuilder.Clear();
                random.Next(0, 10);
                for (int x = 0; x <= 5; x++)
                {
                    var call1 = random.Next(0, 10);
                    builder.Append(call1);
                }
                for (int z = 0; z <= 2; z++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    strbuilder.Append(letter);
                }

                y = Convert.ToInt32(builder.ToString());
                // adds the values to the lists
                nums.Add(new CallNumber(y, strbuilder.ToString()));
            }
            return nums;
        }
    }
}
