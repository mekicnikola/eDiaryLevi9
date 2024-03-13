using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDiary.Subject;

namespace EDiary
{
    class SubjectManualLoader: ISubjectLoader
    {

        public IEnumerable<Subject.Subject> GetAllSubjects()
        {
            var subjects = new List<Subject.Subject>
            {
                new Subject.Subject
                {
                    Name = "Mathematics",
                    Professors = new List<string> { "Ivan Ivanović", "Jelena Jelenić" }
                },
                new Subject.Subject
                {
                    Name = "Phisics",
                    Professors = new List<string> { "Marko Marković", "Ana Anić" }
                },
                new Subject.Subject
                {
                    Name = "Chemistry",
                    Professors = new List<string> { "Nikola Nikolić", "Sara Sarić" }
                },
                new Subject.Subject
                {
                    Name = "IT",
                    Professors = new List<string> { "Petar Petrović", "Mila Milic" }
                },
                new Subject.Subject
                {
                    Name = "History",
                    Professors = new List<string> { "Đorđe Đorđević", "Ljubica Ljubić" }
                }
            };

            return subjects;
        }
    }
}
