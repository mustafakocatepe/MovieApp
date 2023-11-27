using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MovieStudyCase.Services.Abstract;
using MovieStudyCase.Services.Concrete;

namespace MovieStudyCase.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
            
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IDirectorService, DirectorService>();
        services.TryAddSingleton<IRedisCacheService, RedisCacheService>();

        return services;
    }
}