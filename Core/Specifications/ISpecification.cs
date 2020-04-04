using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {

        Expression<Func<T, bool>> Criteria { get; } //This returns an Expression that takes in a delegates of parameter T and return type of bool
        List<Expression<Func<T, object>>> Includes { get; } //A list of expression with delegates that return an object
    }
}