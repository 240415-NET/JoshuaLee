using System;

namespace MultipleChoiceQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] questions = new string[]
            {
                "What is ASP.NET?",
                "Structure of a URL",
                "What does ASP.NET give us?",
                // Add more questions here...
            };

            string[] answers = new string[]
            {
                "B", // Correct answer for the first question
                "A", // Correct answer for the second question
                "B", // Correct answer for the third question
                // Add more correct answers here...
            };

            int score = 0;

            // Display each question and get user input
            for (int i = 0; i < questions.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {questions[i]}");
                Console.Write("Enter your answer (A/B/C/D): ");
                string userAnswer = Console.ReadLine().ToUpper();

                if (userAnswer == answers[i])
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }

            Console.WriteLine($"Your score: {score}/{questions.Length}");
        }
    }
}
