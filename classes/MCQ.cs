using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace C48_G02_EXAM01.classes
{
    internal class MCQ : baseQuestion
    {
        public MCQ( string questionHeader,string questionBody,decimal questionMark,Answer[] answerList) : base(questionHeader, questionBody, questionMark)
        {
            AnswerList = answerList;
        }

        public override baseQuestion Clone()
        {
            MCQ clone = new MCQ(
                questionHeader: QuestionHeader,
                questionBody: QuestionBody,
                questionMark: QuestionMark,
                answerList: null
            );

            clone.QuestionHeader = QuestionHeader;
            clone.QuestionBody = QuestionBody;
            clone.QuestionMark = QuestionMark;

            if (AnswerList  != null)
            {
                clone.AnswerList = new Answer[AnswerList.Length];

                for (int i = 0; i < AnswerList.Length; i++)
                {
                    clone.AnswerList[i] = new Answer(
                        AnswerList[i].AnswerId,
                        AnswerList[i].AnswerText
                    );
                }
            }

            return clone;
        }
    }
}
