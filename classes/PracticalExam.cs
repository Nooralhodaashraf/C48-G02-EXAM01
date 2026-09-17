using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G02_EXAM01.classes
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int timeOfExam, int numberOfQuestions, subject subject , baseQuestion[] questions) : base(timeOfExam, numberOfQuestions, subject, questions)
        {
        }

        public override void ShowExam()
        {
            throw new NotImplementedException();
        }
    }
}
