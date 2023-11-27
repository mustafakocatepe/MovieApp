using MovieStudyCase.Entities.Enums;

namespace MovieStudyCase.Services.Dto.Movie;

public class MovieDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Premier { get; set; }
    public string DirectorName { get; set; }
    public string Description { get; set; }
}