using MovieStudyCase.Services.Dto.Movie;

namespace MovieStudyCase.Services.Abstract;

public interface IMovieService
{
    MovieDto GetById(int id);
    List<MovieDto> GetAll();
    MovieDto Create(CreateMovieDto createMovieDto);
    void Update(int id, UpdateMovieDto updateMovieDto);
    void Delete(int id);

}