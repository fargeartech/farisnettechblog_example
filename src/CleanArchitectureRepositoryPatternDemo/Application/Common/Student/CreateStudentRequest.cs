namespace Application.Common.Student
{
    public record CreateStudentRequest
    {
        public string Name { get; set; }
        public string StudentNo { get; set; }
        public CreateSubjectRequest Subject { get; set; }
    }

    public record CreateSubjectRequest(string name);
}
