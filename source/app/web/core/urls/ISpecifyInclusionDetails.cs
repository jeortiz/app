using System;
using System.Linq.Expressions;

namespace app.web.core.urls
{
  public interface ISpecifyInclusionDetails<Item>
  {
    void include<PropertyType>(Expression<Func<Item, PropertyType>>  accessor);
  }
}