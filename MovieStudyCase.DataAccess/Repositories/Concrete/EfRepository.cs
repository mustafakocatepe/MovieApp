using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieStudyCase.DataAccess.Context;
using MovieStudyCase.DataAccess.Repositories.Abstract;

namespace MovieStudyCase.DataAccess.Repositories.Concrete;

public abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly MovieAppContext _context;
    private DbSet<TEntity> _entities;

    public EfRepository(MovieAppContext context)
    {
        _context = context;
        _entities = Entities;
    }

    /// <summary>
    /// Gets a table
    /// </summary>
    public virtual IQueryable<TEntity> TableWithDeleted => Entities;

    /// <summary>
    /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
    /// </summary>
    public virtual IQueryable<TEntity> TableNoTrackingWithDeleted => Entities.AsNoTracking();


    /// <summary>
    /// Entities
    /// </summary>
    protected virtual DbSet<TEntity> Entities => _entities ??= _context.Set<TEntity>();

    public virtual TEntity Find(Expression<Func<TEntity, bool>> criteria)
    {
        return Entities.SingleOrDefault(criteria);
    }

    public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> criteria)
    {
        return criteria == null
            ? Entities.ToList()
            : Entities.Where(criteria).ToList();
    }

    public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> criteria, int startIndex, int pageSize, string orderBy, string sortDirection)
    {
        var query = Entities.AsQueryable();
        if (criteria != null)
            query = query.Where(criteria);
        query = query.OrderBy(x => orderBy + " " + sortDirection);

        return query
            .Skip(startIndex)
            .Take(pageSize)
            .ToList();
    }

    public virtual TEntity Add(TEntity entity)
    {
        var addedEntity = Entities.Add(entity);
        _context.SaveChanges();
        return addedEntity.Entity;
    }

    public virtual List<TEntity> AddRange(List<TEntity> entities)
    {
        var addedEntities = _context.Entry(entities);
        addedEntities.State = EntityState.Added;
        _context.SaveChanges();
        return addedEntities.Entity;
    }

    public virtual TEntity Edit(TEntity entity)
    {
        var updatedEntity = _context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        _context.SaveChanges();
        return updatedEntity.Entity;
    }

    public virtual void Delete(TEntity entity)
    {
        Entities.Remove(entity);
        _context.SaveChanges();
    }
    public virtual bool DeleteReturnBool(TEntity entity)
    {
        Entities.Remove(entity); try
        {
            _context.SaveChanges();
            return true;
        }
        catch //(Exception ex)
        {
            return false;
        }
    }

    public virtual void Delete(Expression<Func<TEntity, bool>> criteria)
    {
        var records = Entities.Where(criteria);
        Entities.RemoveRange(records);
        _context.SaveChanges();
    }

    public virtual void DeleteRange(List<TEntity> entities)
    {
        Entities.RemoveRange(entities);
        _context.SaveChanges();
    }

    public virtual void DeleteRange(Expression<Func<TEntity, bool>> criteria)
    {
        var list = criteria == null
                ? Entities.ToList()
                : Entities.Where(criteria).ToList();

        Entities.RemoveRange(list);
        _context.SaveChanges();
    }

    public virtual bool DeleteRangeReturn(List<TEntity> entities)
    {
        Entities.RemoveRange(entities);

        try
        {
            _context.SaveChanges();
            return true;
        }
        catch //(Exception ex)
        {
            return false;
        }
    }

    public virtual bool DeleteRangeReturn(Expression<Func<TEntity, bool>> criteria)
    {
        var list = criteria == null
                ? Entities.ToList()
                : Entities.Where(criteria).ToList();

        Entities.RemoveRange(list);
        try
        {
            _context.SaveChanges();
            return true;
        }
        catch //(Exception ex)
        {
            return false;
        }
    }

    public virtual TEntity Single(Expression<Func<TEntity, bool>> criteria)
    {
        return Entities.Single(criteria);
    }

    public virtual TEntity First(Expression<Func<TEntity, bool>> criteria)
    {
        return Entities.First(criteria);
    }

    public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> criteria)
    {
        return Entities.FirstOrDefault(criteria);
    }

    public virtual TEntity LastOrDefault(Expression<Func<TEntity, bool>> criteria)
    {
        return Entities.Where(criteria).ToList().LastOrDefault();
    }

    public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> criteria)
    {
        return Entities.SingleOrDefault(criteria);
    }

    public virtual bool Any(Expression<Func<TEntity, bool>> criteria)
    {
        return Entities.Any(criteria);
    }

    public virtual int Count()
    {
        return Entities.Count();
    }

    public virtual int Count(Expression<Func<TEntity, bool>> criteria)
    {
        return criteria != null
                ? Entities.Count(criteria)
                : Entities.Count();
    }



    public virtual bool EditReturnBool(TEntity entity)
    {
        var updatedEntity = _context.Entry(entity);
        updatedEntity.State = EntityState.Modified;

        try
        {
            _context.SaveChanges();
            return true;
        }
        catch //(Exception ex)
        {
            return false;
        }
    }
    //public virtual bool EditBatch(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TEntity>> updateExpression)
    //{
    //    try
    //    {
    //        var count = _context.Set<TEntity>().Where(expression).Update(updateExpression);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        return false;
    //    }
    //}

    //public virtual bool EditBatch(Expression<Func<TEntity, bool>> predicate, TEntity entity)
    //{
    //    try
    //    {
    //        var entities = _context.Set<TEntity>().Where(predicate);
    //        _context.Set<TEntity>().UpdateFromQuery(entities, x => entity);
    //        //    var parameter = Expression.Parameter(type, "x");
    //        //    var lambda = Expression.Lambda<Func<TEntity, TEntity>>(ex, parameter);
    //        //    UnitOfWork.Query<TEntity>(e => e.Id == id)
    //        //        .Update(lambda);
    //        //    //Expression<Func<TEntity, TEntity>> expression = (x) => new Activitiy() { ColumnInt = 2 };
    //        //    //var users = context.Users.Where(u => u.FirstName == "firstname");
    //        //    //context.Users.Update(users, u => new User { FirstName = "newfirstname" });
    //        //    Expression<Func<TEntity, TEntity>> updateFactory = x => entity;
    //        int count = _context.Set<TEntity>()
    //            .Where(x => predicate)
    //            .UpdateFromQuery(x => entity);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        return false;
    //    }
    //}
}