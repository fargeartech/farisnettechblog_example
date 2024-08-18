using Domain.Entities;

namespace Application.Interfaces
{
    public interface IStudentRepository
    {
        // .. simple implementation, you can add yours! 😊
        Task<IReadOnlyList<Student>> GetAllStudentAsync(CancellationToken cancellation);
        Task<Student> FindStudentByNo(string studentNo, CancellationToken cancellation);
        Task CreateAsync(Student student, CancellationToken cancellation);
        Task UpdateStudentAsync(Student student, CancellationToken cancellation);
        Task RemoveAsync(int Id, CancellationToken cancellation);
    }
}