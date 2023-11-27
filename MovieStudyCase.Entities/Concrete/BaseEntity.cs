namespace MovieStudyCase.Entities.Concrete;

public class BaseEntity
{
    public string CreateUser { get; set; }
    public DateTime CreateDate { get; set; }
    public string? UpdateUser { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
}