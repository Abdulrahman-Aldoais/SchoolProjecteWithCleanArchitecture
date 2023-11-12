namespace School.Application.Features.Students.Dtos.GetList
{
    public class GetStudentListOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
    }
}
