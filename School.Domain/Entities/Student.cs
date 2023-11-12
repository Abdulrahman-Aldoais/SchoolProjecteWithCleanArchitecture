namespace School.Domain.Entities
{
    public class Student : BaseModel
    {
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}