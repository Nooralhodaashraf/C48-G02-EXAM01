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
            decimal grade = 0; // Initialize the grade to 0 to calculate it

            // 9 - Final Exam Shows the Questions, Answers and Grade.
            foreach (baseQuestion question in Questions)
            {
                // Show question
                Console.WriteLine(question.QuestionHeader);
                Console.WriteLine(question.QuestionBody);

                // Show answers (of the 1 Q)
                foreach (Answer answer in question.AnswerList)
                {
                    Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
                }

                // Get student's answer (to store it)
                Console.Write("Enter your answer: ");
                
              int.TryParse(Console.ReadLine(), out int answerId) ; // كنت ناسية الفالديشن هنا ابقي اكدي عليه قبل التسليم !!!!!!!!!

                // Store the student's selected answer
                foreach (Answer answer in question.AnswerList)
                {
                    if (answer.AnswerId == answerId)
                    {
                        question.StudentAnswer = answer;
                        break;
                    }
                }
                // Calculate grade
                if (question.StudentAnswer != null && //make sure its not null 
                    question.StudentAnswer.AnswerId == question.RightAnswer.AnswerId)//make sure that the answer is right (correct)
                {
                    grade += question.QuestionMark; //if stdanswer was right the grade increase if not it doesnt change
                }
            }

            // Show final grade of the total exam
            Console.WriteLine($"Grade: {grade}");
        }
    }
}
