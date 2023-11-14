using School.Domain.Enum;

namespace School.Domain
{
    public interface IEntityBase
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime CreateTime { get; set; }
        Status Status { get; set; }
    }
}
