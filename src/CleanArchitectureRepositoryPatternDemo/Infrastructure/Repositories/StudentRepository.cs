using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    internal sealed class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly DemoContext _appContext;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(DemoContext appContext, ILogger<StudentRepository> logger) : base(appContext)
        {
            _appContext = appContext;
            _logger = logger;
        }

        public async Task CreateAsync(Student student, CancellationToken cancellation)
        {
            try
            {
                await AddAsync(student, cancellation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create Student Error");
                throw;
            }
        }

        public async Task<Student?> FindStudentByNo(string studentNo, CancellationToken cancellation)
        {
            return await GetAll().AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.StudentNo == studentNo, cancellation);
        }

        public async Task<IReadOnlyList<Student>> GetAllStudentAsync(CancellationToken cancellation)
        {
            return await GetAll().Include(x => x.StudentSubjects).AsNoTracking().ToListAsync(cancellation);
        }

        public async Task RemoveAsync(int Id, CancellationToken cancellation)
        {
            try
            {
                var student = await GetIdAsync(Id, cancellation);
                if (student is null)
                {
                    throw new Exception("Record Not Exists");
                }

                await RemoveAsync(student, cancellation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Remove");
                throw;
            }
        }

        public async Task UpdateStudentAsync(Student student, CancellationToken cancellation)
        {
            try
            {
                await UpdateAsync(student, cancellation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Upadate");
                throw;
            }
        }
    }
}