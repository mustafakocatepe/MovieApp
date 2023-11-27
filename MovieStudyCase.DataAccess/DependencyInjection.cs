using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieStudyCase.DataAccess.Context;
using MovieStudyCase.DataAccess.Repositories.Abstract;
using MovieStudyCase.DataAccess.Repositories.Concrete;

namespace MovieStudyCase.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<MovieAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        //services.AddDbContext<MovieAppContext>(options => options.UseSqlServer("Server=.;Database=MovieApp;Trusted_Connection=True;"));

        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        return services;
    }
}