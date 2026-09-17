using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G02_EXAM01.classes
{

    //لازم اراجع دي كويس 
    internal class FinalExam:Exam
    {
        public FinalExam(int timeOfExam, int numberOfQuestions, subject subject , baseQuestion[] questions) : base(timeOfExam, numberOfQuestions, subject, questions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Subject = subject;
        }

   

        public override void ShowExam()
        {
            throw new NotImplementedException();
        }
    }
}
