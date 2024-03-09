using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02_Michael_Sameh
{
    abstract internal class Exam
    {

        public int timeOfExam { get; set; }

        

        private int numOfQuestions = 0;

        public int NumOfQuestions 
        {
            get {  return numOfQuestions; }
            set {  numOfQuestions = value; }
        }


        abstract public void createExam();
        abstract public void showExam();

    }
}
