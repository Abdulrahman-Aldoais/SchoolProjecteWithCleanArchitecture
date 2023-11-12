using School.Domain.Enum;
using System.Globalization;

namespace School.Domain.Entities
{
    public class BaseModel
    {
        public BaseModel()
        {
            string formattedDate = "2023-11-09 15:30"; // Replace with your desired formatted date and time
            this.CreateTime = DateTime.ParseExact(formattedDate, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        private Status _status = Status.Modified;
        public Status Status
        {
            get => _status;
            set => _status = value;
        }
    }
}
