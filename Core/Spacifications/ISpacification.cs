using System.Linq.Expressions;

namespace Back.Core.Entities
{
  public interface ISpacification<T>
  {
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T,object>>OrderBy{get;}
    Expression<Func<T,object>>OrderByDesc{get;}
   int Take{get;}
   int Skip { get; }
   bool IsPageEnable{get;}
   
    
  }
}