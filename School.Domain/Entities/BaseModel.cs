using System.Globalization;

namespace School.Domain.Entities
{
    public class BaseModel
    {
        public BaseModel()
        {
            string formattedDate = "2023-11-09 15:30"; // Replace with your desired formatted date and time
            this.DateCreated = DateTime.ParseExact(formattedDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            this.Id = new Guid();
        }

        public BaseModel(Guid id) : this()
        {
            Id = id;
        }

        public Guid Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
