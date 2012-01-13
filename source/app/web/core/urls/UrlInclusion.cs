using System;
using System.Linq.Expressions;

namespace app.web.core.urls
{
  public class UrlInclusion<ItemToInclude> : ISpecifyInclusionDetails<ItemToInclude>
  {
    public ItemToInclude item;
    public IStoreTokens token_store;
    public IMapAPropertyNameFromAnExpression name_mapper;

    public UrlInclusion(ItemToInclude item, IStoreTokens token_store, IMapAPropertyNameFromAnExpression name_mapper)
    {
      this.item = item;
      this.token_store = token_store;
      this.name_mapper = name_mapper;
    }

    public void include<PropertyType>(Expression<Func<ItemToInclude, PropertyType>> accessor)
    {
      token_store.store_token(name_mapper.map_from(accessor),accessor.Compile()(item));
    }

  }
}