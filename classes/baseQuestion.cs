using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace C48_G02_EXAM01.classes
{
    //Design a Class to represent the Question Object, Question is  consisting of: 
    internal abstract class baseQuestion : ICloneable, IComparable
    {
        #region properties
        //. Header of the question
        public string QuestionHeader { get; set; }
        //b.Body of the question

        public string QuestionBody { get; set; }
        //c.Mark

        public decimal QuestionMark { get; set; }

        //5. Question is associated with an Array of answers and its right answer(Answers[] AnswerList) . 

        public Answer[] AnswerList { get; set; } = new Answer[0];

        public Answer RightAnswer { get; set; }
        public Answer StudentAnswer { get; set; }
        #endregion
        #region constructors & methods
        public baseQuestion(string questionHeader, string questionBody, decimal questionMark)
        {
            QuestionHeader = questionHeader;
            QuestionBody = questionBody;
            QuestionMark = questionMark;
        }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        public abstract object Clone();

        public int CompareTo(object? obj)
        {
            if (obj == null)
                return 1;

            if (obj is not baseQuestion otherQuestion)
                throw new ArgumentException("Object is not a Question");

            if (QuestionHeader == otherQuestion.QuestionHeader &&
                QuestionBody == otherQuestion.QuestionBody)
            {
                return 0; //the two questions are tipical 
            }

            return string.Compare(
                QuestionBody,
                otherQuestion.QuestionBody,
                StringComparison.OrdinalIgnoreCase
            );
        }
        public override string ToString()
        {
            return $"{QuestionHeader}: {QuestionBody} - Mark: {QuestionMark}";
        } //so it returns the object instade of the class location stored 

        public baseQuestion CloneQuestion() => (baseQuestion)((ICloneable)this).Clone();
        #endregion

    }
}
