using Domain.Common;

namespace Domain.Entities
{
    public class Student : BaseAuditableEntity
    {
        public Student()
        {
            StudentSubjects = new List<StudentSubject>();
        }
        public string Name { get; set; }
        public string StudentNo { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}