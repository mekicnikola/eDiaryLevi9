

using System;
using System.Collections.Generic;

namespace EDiary
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StartingYear => DateTime.Now.Year;

        public Dictionary<string, List<int>> Grades { get; set; }

        

        public override string ToString()
        {
            var yearLastTwoDigits = StartingYear.ToString().Substring(StartingYear.ToString().Length - 2);
            return $"{Constants.StudentEmoji} {Id}/{yearLastTwoDigits} - {FirstName} {LastName}";
        }


    }
}
