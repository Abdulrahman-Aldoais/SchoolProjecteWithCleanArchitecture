namespace School.Application.Features.Students.Dtos.GetList
{
    public class GetStudentListOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
    }
}
