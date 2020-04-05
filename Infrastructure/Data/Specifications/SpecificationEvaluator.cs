using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// This performs criteria and includes operations on IQueryable of the various BaseEntities
        /// </summary>
        /// <param name="inputQueryable">The entity Queryable to perform operations on</param>
        /// <param name="specification">The Specification to apply on the queryable input</param>
        /// <returns>A IQueryable of the BaseEntity after criteria and includes operation has been performed on</returns>
        public static IQueryable<TEntity> GetQueryable(IQueryable<TEntity> inputQueryable, ISpecification<TEntity> specification)
        {
            var query = inputQueryable;

            //Applying the criteria if any
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            //Adding pagination and this should be the last thing to do after filtering and ordering
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }
            
            //Apply all includes to the queryable
            query = specification.Includes.Aggregate(query, (queryableEntity, include) => queryableEntity.Include(include));

            //Return the queryable
            return query;
        }
    }


}