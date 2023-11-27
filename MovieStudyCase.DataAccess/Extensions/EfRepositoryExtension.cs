using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStudyCase.DataAccess.Extensions
{
    public static class EfRepositoryExtension
    {
        public static IQueryable<TEntity> CriteriaOrDefault<TEntity>(this IQueryable<TEntity> queries, Expression<Func<TEntity, bool>> criteria)
        {
            if (criteria != null)
                queries = queries.Where(criteria);

            return queries;
        }
    }
}
