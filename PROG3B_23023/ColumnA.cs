using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG3B_2023
{
    public class ColumnA
    {
        public string question  // property
        { get; set; }
        public ColumnA(string theQuestion)
        {
            this.question = theQuestion;
        }
    }
}
