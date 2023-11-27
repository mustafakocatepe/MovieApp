using System.Linq.Expressions;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MovieStudyCase.DataAccess.Context;
using MovieStudyCase.DataAccess.Extensions;
using MovieStudyCase.DataAccess.Repositories.Abstract;
using MovieStudyCase.Entities.Concrete;

namespace MovieStudyCase.DataAccess.Repositories.Concrete;


public class MovieRepository : EfRepository<Movie>, IMovieRepository
{
    private readonly MovieAppContext _context;

    public MovieRepository(MovieAppContext context) : base(context)
    {
        _context = context;
    }

    public override Movie FirstOrDefault(Expression<Func<Movie, bool>> predicate)
    {
        return _context.Set<Movie>()
            .Include(x => x.Director)
            .AsNoTracking()
            .AsQueryable()
            .FirstOrDefault(predicate);
    }
    public override List<Movie> GetList(Expression<Func<Movie, bool>> criteria)
    {
        var entities = _context.Set<Movie>()
                       .Include(x => x.Director)
                        .AsNoTracking()
                        .AsQueryable()
                        .CriteriaOrDefault(criteria);


        return entities.ToList();
    }   
}
