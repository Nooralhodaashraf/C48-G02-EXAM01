using C48_G02_EXAM01.classes;

namespace C48_G02_EXAM01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Choose Subject
            subject mySubject = ChooseSubject();

            // 2. Choose Exam Type
            bool isFinal = ChooseExamType();

            // 3. Create Questions based on Exam Type
            baseQuestion[] questions = CreateQuestions(isFinal);

            // 4. Create Exam
            mySubject.CreateExam(isFinal,30,questions.Length,questions);

            // 5. Show Exam
            mySubject.ExamOfTheSubject.ShowExam();
        }


        // Implementing methods that gonna be used in the Main
        // to choose the subject
        static subject ChooseSubject()
        {
            // Showing options to choose the subject
            Console.WriteLine("Choose Subject:");
            Console.WriteLine("1. Programming");
            Console.WriteLine("2. Database");
            Console.WriteLine("3. Networking");

            while (true)
            {
                Console.Write("Enter the number of your choice: ");

                // Validating the choice input to int
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return new subject(1, "Programming");

                        case 2:
                            return new subject(2, "Database");

                        case 3:
                            return new subject(3, "Networking");

                        default:
                            Console.WriteLine(
                                "Please choose a number from 1 to 3."
                            );
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }


        // The exam type
        static bool ChooseExamType()
        {
            Console.WriteLine("\nChoose Exam Type:");
            Console.WriteLine("1. Final Exam");
            Console.WriteLine("2. Practical Exam");
            //choice options 
            
            while (true)
            {
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                        return true;
                    //will be true if its final 
                    if (choice == 2)
                        return false;
                    //will be false if its practical
                    Console.WriteLine("Please choose 1 or 2."); //defult case if
                    //the validation is correct but the user enterd unavailable option
                }
                else
                {
                    Console.WriteLine("Please enter a valid number."); //unvalid input
                }
            }
        }


        // Creating the questions array
        static baseQuestion[] CreateQuestions(bool isFinal)
        {
            int numberOfQuestions; //array length

            while (true)
            {
                Console.Write("Enter number of questions: ");

                if (int.TryParse(Console.ReadLine(),out numberOfQuestions)&& numberOfQuestions > 0) //check the input type & its not null =0
                {
                    break; // will initiate the array length in numberOfQuestions and break the loop if the input is valid
                }

                Console.WriteLine("Please enter a valid positive number.");
            }

            baseQuestion[] questions = new baseQuestion[numberOfQuestions]; //initiating the array with the length of numberOfQuestions

            for (int i = 0; i < numberOfQuestions; i++) //loop the Questions and create each question based on the type of the exam
            {
                Console.WriteLine($"\n--- Question {i + 1} ---");

                questions[i] = CreateQuestion(isFinal);
            }

            return questions;
        }



        // Creating one question
        static baseQuestion CreateQuestion(bool isFinal)
        {
            int questionType; // 1 for MCQ, 2 for True / False

            while (true)
            {
                Console.WriteLine("Choose Question Type:");
                Console.WriteLine("1. MCQ");

                if (isFinal) //لو فاينال ف هو هيعرضلي كمان اني احط سؤال تؤو وفولس لانه الامتحان دا بيسمح بالنوعين ف الاسئلة 
                {
                    Console.WriteLine("2. True / False");
                }

                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out questionType))// الفاليديشن عشان نحولها لرقم وبعدين نخش نتشيك ع الرقم دا عشان نحددنوع السؤال اللي هيتكتب
                {
                    // MCQ is allowed in both Final and Practical exams
                    if (questionType == 1)
                    {
                        break;
                    }

                    // True / False is allowed only in Final Exam
                    if (isFinal && questionType == 2)
                    {
                        break;
                    }
                }

                Console.WriteLine("Please choose a valid question type."); //if else option would happen as long as thers no break; got us out of the while scop
            }


            // Question Header
            string header;

            while (true)
            {
                Console.Write("Enter question header: ");

                header = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(header)) // its a string anyway so we check if its not null or empty 
                {
                    break;
                }

                Console.WriteLine("Header cannot be empty.");
            }


            // Question Body
            string body;

            while (true)
            {
                Console.Write("Enter question body: ");

                body = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(body)) //also string
                {
                    break;
                }

                Console.WriteLine("Question body cannot be empty.");
            }


            // Question Mark
            decimal mark;

            while (true)
            {
                Console.Write("Enter question mark: ");

                if (decimal.TryParse(Console.ReadLine(), out mark) && mark > 0)// validation for the input to handle it to become a decimal type
                {
                    break;
                }

                Console.WriteLine("Please enter a valid positive mark.");
            }


            // MCQ
            if (questionType == 1)
            {
                //creating an mcq question
             MCQ MCQquestion =  CreateMCQQuestion(header, body, mark);
                return MCQquestion;
            }
            TrueFalseQuestion trueFalseQuestion = CreateTrueFalseQuestion(header, body, mark);

            // True / False
            return trueFalseQuestion; //else
        }


        // Creating an MCQ question

        static MCQ CreateMCQQuestion( string header,string body,decimal mark)
        {
            int numberOfChoices;

            while (true)
            {
                Console.Write("Enter number of choices: ");

                if (int.TryParse( Console.ReadLine(),out numberOfChoices)&& numberOfChoices >= 2)
                {
                    break; //it its valid and more than 2 choices we break the loop and continue to create the answers list
                }

                Console.WriteLine("MCQ must have at least 2 choices.");
            }


            Answer[] choices =new Answer[numberOfChoices]; //answers list


            // Creating the answers
            for (int i = 0; i < numberOfChoices; i++)
            {
                string answerText;

                while (true)
                {
                    Console.Write(
                        $"Enter choice {i + 1}: "
                    );

                    answerText = Console.ReadLine(); //answer text input for the answer list 

                    if (!string.IsNullOrWhiteSpace(answerText))
                        break;

                    Console.WriteLine(
                        "Answer cannot be empty."
                    );
                }

                choices[i] = new Answer(i + 1,answerText);//loop 
            }


            // Choosing the correct answer
            int correctAnswerId;

            while (true)
            {
                Console.Write(
                    "Enter the correct answer number: "
                );

                if (int.TryParse(Console.ReadLine(), out correctAnswerId) && correctAnswerId >= 1 && correctAnswerId <= numberOfChoices)
                {
                    break;
                }

                Console.WriteLine(
                    "Please enter a valid answer number."
                );
            }


            // Creating the MCQ object
            MCQ question =new MCQ(header,body,mark , choices);
            question.Clone();


            // Setting the correct answer
            question.RightAnswer =choices[correctAnswerId - 1];


            return question;
        }


        // Creating a True / False question
        static TrueFalseQuestion CreateTrueFalseQuestion(string header,string body,decimal mark)
        {
            TrueFalseQuestion question = new TrueFalseQuestion(header,body,mark);
            int correctAnswerId;
            while (true)
            {
                Console.WriteLine("1. True");

                Console.WriteLine("2. False");

                Console.Write("Enter the correct answer number: " );

                if (int.TryParse(Console.ReadLine(),out correctAnswerId)&& (correctAnswerId == 1|| correctAnswerId == 2))
                {
                    break;
                }

                Console.WriteLine("Please choose 1 or 2.");
            }
            // Setting the correct answer
            question.RightAnswer =question.AnswerList[correctAnswerId - 1];
            return question;
        }
    }
}