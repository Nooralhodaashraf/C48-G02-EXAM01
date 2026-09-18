using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G02_EXAM01.classes
{
    //4. We need to define a class for the answers(AnswerId, AnswerText). 

    internal class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
    }
}
