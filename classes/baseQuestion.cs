using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G02_EXAM01.classes
{
    internal class baseQuestion
    {
        #region properties
        public string QuestionHeader { get; set; }
        public string QuestionBody { get; set; }
        public decimal QuestionMark { get; set; }
        public Answer[] AnswerList { get; set; } = new Answer[0];

        public Answer RightAnswer { get; set; }
        #endregion
        #region constructors
        public baseQuestion(string questionHeader, string questionBody, decimal questionMark)
        {
            QuestionHeader = questionHeader;
            QuestionBody = questionBody;
            QuestionMark = questionMark;
        }
        #endregion

    }
}
