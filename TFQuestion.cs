using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02_Michael_Sameh
{
    internal class TFQuestion: Question
    {
        //The True of False Choices
        public bool tf { get; set; }
        //To save the right answer (True or False)
        public bool[] tfanswer { get; set; }

    }
}
