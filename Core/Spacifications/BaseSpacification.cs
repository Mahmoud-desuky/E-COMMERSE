using System.Linq.Expressions;

namespace Back.Core.Entities
{
  public class BaseSpacification<T> : ISpacification<T>
  {

        public BaseSpacification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
      
        public Expression<Func<T, bool>> Criteria { get ; }

        public List<Expression<Func<T, object>>> Includes { get ; }=new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy {get;private set;}

        public Expression<Func<T, object>> OrderByDesc {get;private set;}

        public int Take {get; private set;}

        public int Skip {get; private set;}

        public bool IsPageEnable {get; private set;}

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        protected void AddOrderBy(Expression<Func<T,object>> orderByExperssion)
        {
            OrderBy=orderByExperssion;
        } 
      protected void AddOrderByDesc(Expression<Func<T,object>> orderByDescExperssion)
        {
            OrderByDesc=orderByDescExperssion;
        } 
     protected void ApplyPaging(int skip,int take)
     {
        Skip=skip;
        Take=take;
        IsPageEnable=true;
     }
     
        
    }
}