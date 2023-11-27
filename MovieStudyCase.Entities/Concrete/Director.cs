namespace MovieStudyCase.Entities.Concrete;

public class Director : BaseEntity
{
    public Director()
    {
        Movies = new HashSet<Movie>();

    }

    public int DirectorId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Movie> Movies { get; set; }
}