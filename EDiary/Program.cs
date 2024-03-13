using System;
using System.Collections.Generic;
using System.Linq;

namespace EDiary
{
    internal class Program
    {
        public static readonly StudentJsonService StudentJsonService = new StudentJsonService();
        public static readonly SubjectManualLoader SubjectLoader = new SubjectManualLoader();

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine(Constants.ApplicationLogo);
            ShowMenu();
        }

        private static void ShowMenu()
        {
            var studentService = new StudentService();
            while (true)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine($"1. Display all subjects {Constants.BookEmoji}");
                Console.WriteLine($"2. Display all students {Constants.StudentEmoji}");
                Console.WriteLine($"3. Insert new students {Constants.PlusEmoji}{Constants.StudentEmoji}");
                Console.WriteLine("4. Enter grade for desired student and subject");
                Console.WriteLine("5. Display subjects and grades for desired student");
                Console.WriteLine($"6. EXIT {Constants.CloseEmoji}");
                Console.WriteLine("-------------------------------------------------");

                Console.Write("Choose an option: ");
                var choice =TextService.GetIntegerFromUser();
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        var loadSubjects = SubjectLoader.GetAllSubjects().ToList();
                        DisplaySubjects(loadSubjects);
                        break;
                    case 2:
                        var loadStudents = StudentJsonService.GetAllStudents();
                        DisplayStudents(loadStudents);
                        break;
                    case 3:
                        var stringInput = TextService.GetStringFromUser();
                        studentService.AddNewStudents(stringInput);
                        break;
                    case 4:
                        studentService.EnterGradeForStudent();
                        break;
                    case 5:
                        studentService.DisplayGradesAndAverageForStudent();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine($"{Constants.WarningEmoji} Unknown option, try again.");
                        break;
                }
            }
        

        }

        private static void DisplayStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        private static void DisplaySubjects(List<Subject.Subject> subjects)
        {
            foreach (var subject in subjects)
            {
                Console.WriteLine($"{Constants.BookEmoji} {subject.Name} - Professors: {string.Join(", ", subject.Professors)}");
            }
        }

      
}
}
