using MovieStudyCase.DataAccess.Repositories.Abstract;
using MovieStudyCase.Entities.Concrete;
using MovieStudyCase.Services.Abstract;
using MovieStudyCase.Services.Dto.Common;
using MovieStudyCase.Services.Dto.Movie;
using MovieStudyCase.Services.Exceptions;

namespace MovieStudyCase.Services.Concrete;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IDirectorService _creatorService;
    private readonly IRedisCacheService _redisCacheService;
    public const string MovieById = "MovieById:{0}";



    public MovieService(IMovieRepository movieRepository, IDirectorService creatorService, IRedisCacheService redisCacheService)
    {
        _movieRepository = movieRepository;
        _creatorService = creatorService;
        _redisCacheService = redisCacheService;
    }

    public Movie GetMovieEntityById(int id)
    {
        Movie movie = _movieRepository.FirstOrDefault(x => x.MovieId == id && !x.IsDeleted);

        if (movie == null)
            throw new StateException("Film bulunamadý");

       return movie;
    }

    public MovieDto GetById(int id)
    {
        string cacheKey = string.Format(MovieById, id);
        MovieDto movieDto = _redisCacheService.Get<MovieDto>(cacheKey);

        if (movieDto != null)
            return movieDto;

        Movie movie = GetMovieEntityById(id);

        movieDto =  new MovieDto
        {
            Id = movie.MovieId,
            Name = movie.Name,
            Description = movie.Description,
            DirectorName = movie.Director.Name,
            Premier = movie.Premier
        };

        _redisCacheService.Set(cacheKey, movieDto);
        
        return movieDto;

    }

    public List<MovieDto> GetAll()
    {
        List<MovieDto> movies = _movieRepository.GetList(x => !x.IsDeleted)
            .Select(x => new MovieDto { Id = x.MovieId, Name = x.Name, Description = x.Description, Premier = x.Premier, DirectorName = x.Director.Name })
            .ToList();

        if (!movies.Any())
            throw new StateException("Kayýtlý hiçbir film yoktur.");

        return movies;
    }

    public MovieDto Create(CreateMovieDto createMovieDto)
    {
        _creatorService.CheckDirectorById(createMovieDto.DirectorId);

        Movie movie = new Movie() { Name= createMovieDto.Name, Premier = createMovieDto.Premier, Genre = createMovieDto.Genre, Description = createMovieDto.Description, DirectorId = createMovieDto.DirectorId  };
        
        Movie movieEntity = _movieRepository.Add(movie);

        movieEntity = GetMovieEntityById(movieEntity.MovieId);

        return new MovieDto
        {
            Id = movieEntity.MovieId,
            Name = movieEntity.Name,
            Description = movieEntity.Description,
            DirectorName = movieEntity.Director.Name,
            Premier = movieEntity.Premier
        };
    }

    public void Update(int id, UpdateMovieDto updateMovieDto)
    {
        Movie movie = GetMovieEntityById(id);

        if (!string.IsNullOrWhiteSpace(updateMovieDto.Name))
            movie.Name = updateMovieDto.Name;
        if (!string.IsNullOrWhiteSpace(updateMovieDto.Description))
            movie.Description = updateMovieDto.Description;


        _movieRepository.Edit(movie);

        string cacheKey = string.Format(MovieById, id);
        _redisCacheService.Remove(cacheKey);

    }

    public void Delete(int id)
    {
        Movie movie = GetMovieEntityById(id);

        movie.IsDeleted = true; 

        _movieRepository.Edit(movie);

        string cacheKey = string.Format(MovieById, id);
        _redisCacheService.Remove(cacheKey);
    }

}