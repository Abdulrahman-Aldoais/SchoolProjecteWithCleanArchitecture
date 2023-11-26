using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Domain.Entities
{
    public class Student : BaseModel
    {
        [StringLength(100)]
        public string NameAr { get; set; }
        [StringLength(100)]
        public string NameEn { get; set; }
        public int Age { get; set; }
        [Key]
        public Guid StudID { get; set; }
        [StringLength(300)]
        public string? Address { get; set; }
        [StringLength(100)]
        public string? Phone { get; set; }
        public Guid DID { get; set; }
        [ForeignKey("DID")]
        public virtual Department Department { get; set; }

    }
}