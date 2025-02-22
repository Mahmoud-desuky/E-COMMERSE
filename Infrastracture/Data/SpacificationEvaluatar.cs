using System.Linq;
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
           
            if(spacification.OrderBy!=null)
            {
                query=query.OrderBy(spacification.OrderBy);

            }
            if(spacification.OrderByDesc!=null)
            {
                query=query.OrderByDescending(spacification.OrderByDesc);
            }
            query = spacification.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}