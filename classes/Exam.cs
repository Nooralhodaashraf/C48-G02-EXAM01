using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G02_EXAM01.classes
{
    //Design a Base class Exam describe the common attributes
    //3. We want the application to accept different Question Types: make the baseand inhert from it
    internal abstract class Exam
    {
        //a.Time of exam
        public  int TimeOfExam { get; set; }
        //b.Number of Questions
        public  int NumberOfQuestions { get; set; }
        //7. Every Exam object is Associated to a Subject.
        public subject Subject { get; set; }

//8- Practical Exam Shows the right answer after finishing the Exam.
//9- Final Exam Shows the Questions, Answers and Grade.
//بناءا ع البندين دول ف انا لازم زي م عندي ليسته الاجابات يكون معايا ليستة الاسئلة 
        public baseQuestion[] Questions { get; set; }


        protected Exam(int timeOfExam, int numberOfQuestions , subject subject , baseQuestion[] questions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
            Questions = questions;
        }


        //c.Show Exam Functionality that its implementations will be different for each exam based on its type.
        public abstract void ShowExam(decimal totalGrade);

    }
}
