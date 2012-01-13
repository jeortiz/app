using System;
using System.Linq.Expressions;

namespace app.web.core.urls
{
  public interface IMapAPropertyNameFromAnExpression
  {
    string map_from<Target,PropertyType>(Expression<Func<Target,PropertyType>> expression);
  }
}