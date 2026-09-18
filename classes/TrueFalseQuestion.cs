using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace C48_G02_EXAM01.classes
{
    internal class TrueFalseQuestion : baseQuestion
    {
        public TrueFalseQuestion(string questionHeader, string questionBody, decimal questionMark) : base(questionHeader, questionBody, questionMark)
        {
            AnswerList = new Answer[]
        {
            new Answer(1, "True"),
            new Answer(2, "False")
        };
    }
            public override baseQuestion Clone()
        {
            TrueFalseQuestion clone = new TrueFalseQuestion(QuestionHeader, QuestionBody, QuestionMark );

            clone.QuestionHeader = QuestionHeader;
            clone.QuestionBody = QuestionBody;
            clone.QuestionMark = QuestionMark;

            return clone;
        }
    }
}
