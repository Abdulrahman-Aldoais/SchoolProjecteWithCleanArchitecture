namespace School.Domain.Entities
{
    public class Department : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Student> Students { get; set; }




    }
}
