using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// <summary>
        /// An expression criteria to include in the Queryable object
        /// </summary>
        public Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// Contains a list of include expressions
        /// </summary>
        /// <returns>A list of include expressions</returns>
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();


        /// <summary>
        /// This adds an include expression to the list of includes
        /// </summary>
        /// <param name="includeExpression">The include expression to add</param>
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}