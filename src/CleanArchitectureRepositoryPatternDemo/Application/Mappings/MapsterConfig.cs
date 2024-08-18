using Application.Common.Student;
using Domain.Entities;
using Mapster;

namespace Application.Mappings
{
    public static class MapsterConfig
    {
        public static void ConfigureMapster()
        {
            TypeAdapterConfig<Student, ListStudentResponse>
                .NewConfig()
                .Map(dst => dst.StudentSubjectResponse, src => src.StudentSubjects);
        }
    }
}
