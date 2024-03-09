using System.Diagnostics;

namespace Exam_02_Michael_Sameh
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Subject sub = new Subject(1,"C#");
            sub.createExam();
            Console.Clear();
            Console.WriteLine("Do You Want To Start The Exam ( y | n ): ");


            if (char.Parse(Console.ReadLine()) == 'y' || char.Parse(Console.ReadLine()) == 'Y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sub?.showExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
        }
    }
}
