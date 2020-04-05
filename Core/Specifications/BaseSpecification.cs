using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public abstract class BaseSpecification<T> : ISpecification<T>
    {
        protected BaseSpecification()
        {
        
        }

        protected BaseSpecification(Expression<Func<T, bool>> criteria)
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

        public Expression<Func<T, object>> OrderBy { get; private set; }
        
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        
        public int Skip { get; private set; }
        
        public int Take { get; private set; }
        
        public bool IsPagingEnabled { get; private set; }


        /// <summary>
        /// This adds an include expression to the list of includes
        /// </summary>
        /// <param name="includeExpression">The include expression to add</param>
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        /// <summary>
        /// Sets an orderBy expression
        /// </summary>
        /// <param name="orderByExpression">An Expression of OrderBy</param>
        protected void AddOderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        
        /// <summary>
        /// Sets and OrderByDescending Expression
        /// </summary>
        /// <param name="orderByDescExpression">An Expression od OrderByDescending</param>
        protected void AddOderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void AddPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}