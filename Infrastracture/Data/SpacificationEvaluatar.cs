using Back.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back.Infrastracture.Data
{
    public class SpacificationEvaluatar<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpacification<T> spacification)
        {
            var query = inputQuery;
            if (spacification.Criteria != null)
            {
                query = query.Where(spacification.Criteria);
            }
            query = spacification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}