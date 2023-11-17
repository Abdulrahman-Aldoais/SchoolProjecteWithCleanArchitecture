namespace School.Application.Features.Departments.Dtos.GetList
{
    public class GetDepartmentListOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
    }
}
