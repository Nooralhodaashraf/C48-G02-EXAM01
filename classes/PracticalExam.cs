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

        public override void ShowExam(decimal totalGrade = 0)
        {
            Console.WriteLine($"Subject: {Subject.SubjectName}");
            foreach (baseQuestion question in Questions)
            {
                Console.WriteLine(question.QuestionHeader);
                Console.WriteLine(question.QuestionBody);

                foreach (Answer answer in question.AnswerList)
                {
                    Console.WriteLine($"{answer.AnswerId}. {answer.AnswerText}");
                }

                Console.Write("Enter your answer: ");
                int answerId;

                while (true)
                {
                    Console.Write("Enter your answer: ");

                    if (int.TryParse(Console.ReadLine(), out answerId) &&
                        answerId >= 1 &&
                        answerId <= question.AnswerList.Length)
                    {
                        break;
                    }

                    Console.WriteLine($"Please enter a number from 1 to {question.AnswerList.Length}.");
                }
                foreach (Answer answer in question.AnswerList)
                {
                    if (answer.AnswerId == answerId)
                    {
                        question.StudentAnswer = answer;
                        break;
                    }
                }
            }
            //8 - Practical Exam Shows the right answer after finishing the Exam. خرجنا الاجابات برااللوب عشان متظهرش كل اجابة مع كل سءال لا هتتعرض الاجابات برا كلها لما الامتحان كله يخلص 

        Console.WriteLine("\nCorrect Answers:");
            foreach (baseQuestion question in Questions)
            {
                Console.WriteLine( $"{question.QuestionHeader}: {question.RightAnswer.AnswerText}");
            }

        }
    }
}
