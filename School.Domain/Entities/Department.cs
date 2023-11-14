namespace School.Domain.Entities
{
    public class Department : BaseModel
    {

        public string Description { get; set; }
        public List<Student> Students { get; set; }




    }
}
