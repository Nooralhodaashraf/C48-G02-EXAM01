using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace C48_G02_EXAM01.classes
{
    //he Subject is a class that contains the following members: 
    internal class subject
    {
        //a.Subject Id.
        public int SubjectId { get; set; }
        //b.Subject Name.
        public string SubjectName { get; set; }
        //c.Exam of the subject.
        public Exam ExamOfTheSubject { get; set; }


        public subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        //d.We need to implement functionality to create the exam of the subject.

        public override string ToString()
        {
            return $" {SubjectId}- {SubjectName}";
        }

        public void CreateExam( bool isFinal, int timeOfExam, int numberOfQuestions, baseQuestion[] questions)
        {
            //isFinal to check the exam type 

            
            if (isFinal)
            {
                ExamOfTheSubject = new FinalExam( timeOfExam, numberOfQuestions,this, //current subject
                    questions);
            }
            else
            {
                ExamOfTheSubject = new PracticalExam(
                    timeOfExam,
                    numberOfQuestions,
                    this, //current subject
                    questions);
            }
        }
    }
}
