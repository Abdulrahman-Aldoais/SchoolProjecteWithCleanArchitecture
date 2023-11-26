namespace School.Application.Features.Students.Dtos.GetList
{
    public class GetStudentListOutput
    {
        public Guid StudID { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public Guid DID { get; set; }
        public string? CreatedBy { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? DepartmentName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
