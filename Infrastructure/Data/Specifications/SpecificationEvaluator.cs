using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// This performs criteria and includes operations on IQuerable of the varios BaseEntites
        /// </summary>
        /// <param name="inputQuerable">The entity Querable to perform operations on</param>
        /// <param name="specification">The Specification to apply on the querable input</param>
        /// <returns>A IQuerable of the BaseEntity after criteria and includes operation has been performed on</returns>
        public static IQueryable<TEntity> GetQuerable(IQueryable<TEntity> inputQuerable, ISpecification<TEntity> specification)
        {
            var query = inputQuerable;

            //Applying the criteria if any
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            //Apply all includes to the queryable
            query = specification.Includes.Aggregate(query, (queryableEntity, include) => queryableEntity.Include(include));

            //Return the queryable
            return query;
        }
    }
}