using MovieStudyCase.Entities.Enums;

namespace MovieStudyCase.Entities.Concrete;

public class Movie : BaseEntity
{
    public int MovieId { get; set; }
    public string Name { get; set; }
    public DateTime Premier { get; set; }
    public Genre Genre { get; set; }
    public string Description { get; set; }
    public int DirectorId { get; set; }
    public Director Director { get; set; }    
    
}