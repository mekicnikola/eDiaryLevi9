
using System.Collections.Generic;

namespace EDiary.Subject
{
    public interface ISubjectLoader
    {
        IEnumerable<Subject> GetAllSubjects();
    }
}
