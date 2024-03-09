using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_02_Michael_Sameh
{
    internal class Subject: Exam
    {

        public int subjectId { get; set; }
        public string? subjectName  { get; set; }

        public Exam? subjectExam { get; set; }
        public PracticalExam? pExam { get; set; }

        public FinalExam? FExam { get; set; }

        public  List<Question> questionList = new List<Question>();

        public List<Answers> answerList = new List<Answers>();

        public List<McqQuestion> mcqQuestions = new List<McqQuestion>();

        public int sumOfExamGrade = 0;

        public int typeOfExamChecker {  get; set; }     
        
        public Subject(int id, string name)
        {
            subjectName = name;
            subjectId = id;
        }

        public override void createExam()
        {

            bool flag = false;
            int res;

            do
            {
                Console.Write("Please Enter The Type You Want To Create ( 1 For Practical and 2 For final ): ");
                flag = int.TryParse(Console.ReadLine(), out res);
            } while (!flag || (res !=1 && res != 2));
            typeOfExamChecker = res;

            if (res == 1)
            {
                pExam = new PracticalExam();
            }
            else if (res == 2)
            {
                FExam = new FinalExam();
            }


            do
            {
                Console.Write("Please Enter The Time Of Exam In Minutes: ");
                flag = int.TryParse(Console.ReadLine(), out res);
            } while (!flag || res <= 0 );
            timeOfExam = res;

            do
            {
                Console.Write("Please Enter The Number Of Questions You Want To Create: ");
                flag = int.TryParse(Console.ReadLine(), out res);
            } while (!flag || res <= 0);
            NumOfQuestions = res;


            Question[] questions = new Question[NumOfQuestions];
            Answers[] answers = new Answers[NumOfQuestions];
            McqQuestion[] mcqs = new McqQuestion[NumOfQuestions];
            Console.Clear();

            for (int i = 0; i < NumOfQuestions; i++)
            {
                questions[i] = new Question();
                answers[i] = new Answers();
                mcqs[i] = new McqQuestion();
                

                Console.Clear();
                do
                {
                    Console.Write($"Please Choose The Type Of Question Number ({i+1}) ( 1 For True | False and 2 For MCQ ): ");
                    flag = int.TryParse(Console.ReadLine(), out res);
                } while (!flag || (res != 1 && res != 2));
                Console.Clear();

                if (res == 1)
                {
                    TFQuestion tf = new TFQuestion();
                    Console.WriteLine("True | False Question");
                    tf.tfanswer = new bool[1];
                    questions[i].header = "True | False Question";

                    do
                    {
                        Console.WriteLine("Please Enter The Body Of The Question: ");
                        questions[i].body = Console.ReadLine();
                    } while (questions[i].body == string.Empty);


                    do
                    {
                        Console.WriteLine("Please Enter The Marks Of The Question: ");
                        flag = int.TryParse(Console.ReadLine(), out res);
                    } while (!flag || res <= 0);
                    questions[i].mark = res;
                    sumOfExamGrade += questions[i].mark;

                    do
                    {
                        Console.WriteLine("Please Enter The Right Answer Of The Question ( 1 For True And 2 For False ): ");
                        flag = int.TryParse(Console.ReadLine(), out res);
                    } while (!flag || (res != 1 && res != 2));
                    
                    if (res == 1)
                    {
                        answers[i].AnswerText = "1";
                        answers[i].AnswerId = i;

                        //tf.tfanswer[i] = true;
                    }
                    else if (res == 2)
                    {
                        answers[i].AnswerText = "2";
                        answers[i].AnswerId = i;
                    }

                    answerList.Add(answers[i]);
                    questionList.Add(questions[i]);
                    mcqQuestions.Add(mcqs[i]);
                }

                else if (res == 2)
                {

                    Console.WriteLine("Choose One Answer Question");
                    questions[i].header = "Choose One Answer Question";
                    
                    do
                    {
                        Console.WriteLine("Please Enter The Body Of The Question: ");
                        questions[i].body = Console.ReadLine();
                    } while (questions[i].body == string.Empty);

                    do
                    {
                        Console.WriteLine("Please Enter The Marks Of The Question: ");
                        flag = int.TryParse(Console.ReadLine(), out res);
                    } while (!flag || res <= 0);
                    questions[i].mark = res;
                    sumOfExamGrade += questions[i].mark;

                    Console.WriteLine("The Choices For Question: ");

                    do
                    {
                        Console.Write("Please Enter The Choice Number 1: ");
                        mcqs[i].choices[0] = Console.ReadLine();
                    } while (mcqs[i].choices[0] == string.Empty);

                    do
                    {
                        Console.Write("Please Enter The Choice Number 2: ");
                        mcqs[i].choices[1] = Console.ReadLine();
                    } while (mcqs[i].choices[1] == string.Empty);

                    do
                    {
                        Console.Write("Please Enter The Choice Number 3: ");
                        mcqs[i].choices[2] = Console.ReadLine();
                    } while (mcqs[i].choices[2] == string.Empty);

                    do
                    {
                        Console.Write("Please Enter The Choice Number 4: ");
                        mcqs[i].choices[3] = Console.ReadLine();
                    } while (mcqs[i].choices[3] == string.Empty);

                    do
                    {
                        Console.WriteLine("Please Spicify The Right Choice Of The Question: ");
                        flag = int.TryParse(Console.ReadLine(), out res);
                    } while (!flag || (res != 1 && res != 2 && res !=3 && res !=4));
                    mcqs[i].rightChoice = res;
                    answers[i].AnswerText = res.ToString();
                    answers[i].AnswerId = i;

                    answerList.Add(answers[i]);
                    questionList.Add(questions[i]);
                    mcqQuestions.Add(mcqs[i]);
                    //questions.AnswerList.Add(questions.AnswerList[i]);
                    //subjectExam.questionList.Add(questionList[i]);
                }
            }

        }

        public override void showExam()
        {
            Console.Clear();
            int[] studentAnswer = new int[questionList.Count];
            int studentGrade = 0;

            for (int i = 0; i < questionList.Count; i++) 
            {

                Console.WriteLine($"{questionList[i].header}\t( {questionList[i].mark} )");
                Console.WriteLine(questionList[i].body);
                bool flag = false;

                if (questionList[i].header == "True | False Question")
                {
                    Console.WriteLine("1. True\t\t\t2. False");
                    do
                    {
                        flag = int.TryParse(Console.ReadLine(), out studentAnswer[i]);
                    } while (!flag || (studentAnswer[i]!= 1 && studentAnswer[i]!= 2 ));
                    
                    if (studentAnswer[i].ToString() == answerList[i].AnswerText)
                    {
                        studentGrade += questionList[i].mark;
                    }
                    //Console.WriteLine($"The Right Answer For Question {answerList[i].AnswerId + 1}: {answerList[i].AnswerText}");      
                }

                else if (questionList[i].header == "Choose One Answer Question")
                {
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"{j + 1}. {mcqQuestions[i].choices[j]}\t\t");
                        }

                    Console.WriteLine();
                    
                    do
                    {
                        flag = int.TryParse(Console.ReadLine(), out studentAnswer[i]);
                    } while (!flag || (studentAnswer [i] != 1 && studentAnswer[i] != 2 && studentAnswer[i] !=3 && studentAnswer[i] !=4));
                    
                    if (studentAnswer[i].ToString() == answerList[i].AnswerText)
                    {
                        studentGrade += questionList[i].mark;
                    }
                    //Console.WriteLine($"The Right Answer For Question {answerList[i].AnswerId + 1}: {answerList[i].AnswerText}");
                }

            }

            Console.Clear() ;
            Console.WriteLine("Your Answers: ");
            for (int i = 0; i < questionList.Count; i++)
            {
                Console.WriteLine($"Q{i+1}) {questionList[i].body}: {studentAnswer[i]}");
            }
            Console.WriteLine($"Your Exam Grade Is {studentGrade} out of {sumOfExamGrade}");

        }
    }
}
