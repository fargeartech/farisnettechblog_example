namespace Application.Common.Student
{
    public record ListStudentResponse
    {
        public ListStudentResponse()
        {
            StudentSubjectResponse = Array.Empty<StudentSubjectResponse>();
        }

        public string Name { get; set; }
        public string StudentNo { get; set; }
        public IList<StudentSubjectResponse> StudentSubjectResponse { get; set; }
    }

    public record StudentSubjectResponse(int Id, string Name);
}
