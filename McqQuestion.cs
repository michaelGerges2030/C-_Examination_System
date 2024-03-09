using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02_Michael_Sameh
{
    internal class McqQuestion: Question
    {
        //The four choices 
        public string?[] choices = new string[5];
        //The Right Choice Number
        public int rightChoice {  get; set; }

    }
}
