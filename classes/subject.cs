using System;
using System.Collections.Generic;
using System.Text;

namespace C48_G02_EXAM01.classes
{
    internal class subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam ExamOfTheSubject { get; set; }


        public subject(int subjectId, string subjectName, Exam examOfTheSubject)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            ExamOfTheSubject = examOfTheSubject;
        }

        public void CreateExam()
        {

        }
    }
}
