using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EDiary

{
    public class StudentJsonService: IStudentLoader
    {
        public const string JsonFilePath = "../../Student/students.json";

        public List<Student> GetAllStudents()
        {
            var jsonString = File.ReadAllText(JsonFilePath);

            return JsonSerializer.Deserialize<List<Student>>(jsonString) ?? new List<Student>();
        }

        public void WriteStudentsToFile(List<Student> students)
        {
            var jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilePath, jsonString);
        }
    }
}
