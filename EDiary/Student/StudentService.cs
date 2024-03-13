using System;
using System.Collections.Generic;
using System.Linq;

namespace EDiary
{
    public class StudentService
    {
        public static readonly StudentJsonService StudentJsonService = new StudentJsonService();
        public void AddNewStudents(string userInput)
        {
            if (!IsInputValid(userInput))
            {
                throw new FormatException($"{Constants.WarningEmoji} Insert must be in pattern 'Name Last Name, Name Last Name, ...");
            }

            var students = StudentJsonService.GetAllStudents();

            var random = new Random();
            var names = userInput.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var fullName in names)
            {
                var parts = fullName.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine($"{Constants.WarningEmoji} Entered name '{fullName}' is not in right format");
                    continue;
                }

                var firstName = parts[0];
                var lastName = parts[1];

                if (students.Any(s => s.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                                      s.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine($"{Constants.WarningEmoji} Student '{firstName} {lastName}' is already in the system");
                    continue;
                }

                int newId;
                do
                {
                    newId = random.Next(1, 1001);
                }
                while (students.Any(s => s.Id == newId));

                students.Add(new Student { Id = newId, FirstName = firstName, LastName = lastName });
                Console.WriteLine($"{Constants.SuccessEmoji} Student added successfully.");
            }

            StudentJsonService.WriteStudentsToFile(students);
        }

        public void EnterGradeForStudent()
        {
            Console.Write("Enter student First name and Last name: ");
            var studentName = TextService.GetStringFromUser();
            var students = StudentJsonService.GetAllStudents();
            var student = students.FirstOrDefault(s => $"{s.FirstName} {s.LastName}".Equals(studentName, StringComparison.OrdinalIgnoreCase));

            if (student == null)
            {
                Console.WriteLine($"{Constants.WarningEmoji}: Student not found.");
                return;
            }

            var subjectLoader = new SubjectManualLoader();
            var subjects = subjectLoader.GetAllSubjects().ToList();
            DisplaySubjects(subjects);

            Console.Write("Enter number of subject: ");
            if (!int.TryParse(Console.ReadLine(), out var subjectIndex) || subjectIndex < 1 || subjectIndex > subjects.Count)
            {
                Console.WriteLine($"{Constants.WarningEmoji}: Wrong number of subject.");
                return;
            }

            var subject = subjects[subjectIndex - 1];

            Console.Write("Insert grade (1-5): ");
            if (!int.TryParse(Console.ReadLine(), out var grade) || grade < 1 || grade > 5)
            {
                Console.WriteLine($"{Constants.WarningEmoji} Wrong grade.");
                return;
            }

            AddGradeToStudent(student, subject.Name, grade, students);
            Console.WriteLine($"{Constants.SuccessEmoji} Grade added successfully.");
        }

        public void DisplayGradesAndAverageForStudent()
        {
            Console.Write("Enter student First name and Last name: ");
            var studentName = TextService.GetStringFromUser();
            var student = FindStudentByName(studentName);

            if (student == null)
            {
                Console.WriteLine($"{Constants.WarningEmoji} Student not found.");
                return;
            }

            if (student.Grades == null || !student.Grades.Any())
            {
                Console.WriteLine("This student has no grades yet.");
                return;
            }

            foreach (var subjectGrades in student.Grades)
            {
                var subjectName = subjectGrades.Key;
                var grades = subjectGrades.Value;
                var averageGrade = grades.Average();
                var descriptiveGrade = GetDescriptiveGrade(averageGrade);

                Console.WriteLine($"{Constants.BookEmoji} {subjectName}: ({string.Join(", ", grades)}), Average Grade: ({averageGrade:F1}) - {descriptiveGrade}");
            }
        }

        private static string GetDescriptiveGrade(double averageGrade)
        {
            if (averageGrade < 2.0) return "Insufficient";
            else if (averageGrade < 3.5) return "Sufficient";
            else if (averageGrade < 4.5) return "Very good";
            else return "Excellent";
        }

        private static Student FindStudentByName(string fullName)
        {
            var students = StudentJsonService.GetAllStudents();
            return students.FirstOrDefault(s => $"{s.FirstName} {s.LastName}".Equals(fullName, StringComparison.OrdinalIgnoreCase));
        }

        private static void AddGradeToStudent(Student student, string subjectName, int grade, List<Student> students)
        {
            if (student.Grades == null)
                student.Grades = new Dictionary<string, List<int>>();

            if (!student.Grades.ContainsKey(subjectName))
                student.Grades[subjectName] = new List<int>();

            student.Grades[subjectName].Add(grade);

           StudentJsonService.WriteStudentsToFile(students);
        }


        private static void DisplaySubjects(IReadOnlyList<Subject.Subject> subjects)
        {
            for (var i = 0; i < subjects.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {subjects[i].Name}");
            }
        }

        private static bool IsInputValid(string input)
        {
            var names = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            return names.All(name => name.Contains(" ") && !name.EndsWith(",") && name.Split(' ').Length == 2);
        }
    }
}
