using Application.Common.Student;
using Application.Interfaces;
using Domain.Entities;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public sealed class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentSubjectRespository _studentSubjectRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StudentService> _logger;
        private readonly IMapper _mapper;
        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork, ILogger<StudentService> logger, IStudentSubjectRespository studentSubjectRepo, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _studentSubjectRepo = studentSubjectRepo;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ListStudentResponse>> GetStudentsAsync(CancellationToken cancellationToken)
        {
            try
            {
                var results = await _studentRepository.GetAllStudentAsync(cancellationToken);
                return _mapper.Map<IReadOnlyList<ListStudentResponse>>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error GetAllStudents");
                return Array.Empty<ListStudentResponse>();
            }
        }

        public async Task<Student?> CreateStudentAsync(CreateStudentRequest createStudentRequest, CancellationToken cancellationToken)
        {
            try
            {
                var student = new Student
                {
                    Name = createStudentRequest.Name,
                    StudentNo = createStudentRequest.StudentNo,
                };

                await _studentRepository.CreateAsync(student, cancellationToken);

                var studentSubject = new StudentSubject
                {
                    Name = createStudentRequest.Subject.name,
                    Student = student
                };
                await _studentSubjectRepo.CreateSubjectAsync(studentSubject, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
                //.. we also can have domain event if u prefer the CQRS pattern
                return student;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Student");
                return null; //there is a better way to return this by using Result<T>. for this demo just return null
            }
        }

        public async Task<Student?> FindByStudentNo(string studentNo, CancellationToken cancellation)
        {
            return await _studentRepository.FindStudentByNo(studentNo, cancellation);
        }
    }
}
