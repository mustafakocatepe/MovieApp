using Microsoft.AspNetCore.Mvc;
using MovieStudyCase.Services.Abstract;
using MovieStudyCase.Services.Dto.Common;
using MovieStudyCase.Services.Dto.Movie;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;

namespace MovieStudyCase.Api.Controllers.v1;


[ApiController]
[Route("api/movies")]
public class MovieController : BaseController
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseState<MovieDto>), 200)]
    [ProducesResponseType(typeof(ResponseState), 404)]
    [ProducesResponseType(500)]
    public IActionResult Get(int id)
    {
        var response = _movieService.GetById(id);
        return CreateActionResult(ResponseState<MovieDto>.Handle(200, "", response));
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseState<List<MovieDto>>), 200)]
    [ProducesResponseType(typeof(ResponseState), 404)]
    [ProducesResponseType(500)]
    public IActionResult GetAll()
    {
        var response = _movieService.GetAll();
        return CreateActionResult(ResponseState<List<MovieDto>>.Handle(200, "", response));
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public IActionResult Create([FromBody] CreateMovieDto createMovieDto)
    {
        if (createMovieDto == null)
            return CreateActionResult(ResponseState<MovieDto>.Handle(400, "Geçersiz bir istek", null));

        MovieDto movieDto = _movieService.Create(createMovieDto);
        return CreateActionResult(ResponseState<MovieDto>.Handle(201, "Film baþarýlý bir þekilde eklendi", movieDto));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseState), 204)]
    [ProducesResponseType(typeof(ResponseState), 404)]
    [ProducesResponseType(500)]
    public IActionResult Update(int id, [FromBody] UpdateMovieDto updateMovieDto)
    {
         _movieService.Update(id, updateMovieDto);
        return CreateActionResult(ResponseState<MovieDto>.Handle(201, "Film Baþarýlý bir þekilde güncellendi", null));

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ResponseState), 204)]
    [ProducesResponseType(typeof(ResponseState), 404)]
    [ProducesResponseType(500)]
    public IActionResult DeleteAsync(int id)
    {
        _movieService.Delete(id);
        return CreateActionResult(ResponseState<MovieDto>.Handle(204, "Film baþarýlý bir þekilde silindi", null));
    }


}