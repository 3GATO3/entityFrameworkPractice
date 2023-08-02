//using System.Linq.Expressions;
//using Ardalis.Specification;
//using Microsoft.EntityFrameworkCore.Query;

//namespace entityFrameworkPractice.src.Persistence.Specifications
//{
//    public abstract class Specification<TEntity>
//        where TEntity : Entity
//    {
//        public Expression<Func<TEntity,bool>>? Criteria { get; }
//        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = new();

//        public Expression<Func<TEntity,object>>? OrderByExpression { get; private set; }
//        public Expression<Func<TEntity,object>>? OrderByDescendingEXpression { get; private set; }

//        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
//            IncludeExpression.Add(includeExpression);


//        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) =>
//            OrderByExpression = orderByExpression;
//        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression) =>
//            OrderByDescendingExpression = orderByDescendingExpression;
//    }
//}
