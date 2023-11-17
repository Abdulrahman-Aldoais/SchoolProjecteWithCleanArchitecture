namespace School.Domain.Entities
{
    public class Student : BaseModel
    {
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}