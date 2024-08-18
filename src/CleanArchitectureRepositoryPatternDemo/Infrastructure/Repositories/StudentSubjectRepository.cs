using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    internal sealed class StudentSubjectRepository : GenericRepository<StudentSubject>, IStudentSubjectRespository
    {
        private readonly DemoContext _appContext;
        private readonly ILogger<StudentSubjectRepository> _logger;

        public StudentSubjectRepository(DemoContext appContext, ILogger<StudentSubjectRepository> logger) : base(appContext)
        {
            _appContext = appContext;
            _logger = logger;
        }

        public async Task<StudentSubject> CreateSubjectAsync(StudentSubject studentSubject, CancellationToken cancellation)
        {
            try
            {
                return await AddAsync(studentSubject, cancellation);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Subject");
                throw;
            }
        }
    }
}