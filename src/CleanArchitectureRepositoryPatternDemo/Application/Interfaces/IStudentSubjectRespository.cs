using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStudentSubjectRespository
    {
        Task<StudentSubject> CreateSubjectAsync(StudentSubject studentSubject, CancellationToken cancellation);
    }
}
