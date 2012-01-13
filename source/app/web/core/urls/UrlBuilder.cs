using System;
using app.utility.extensions;

namespace app.web.core.urls
{
  public class UrlBuilder : IBuildUrls
  {
    public IStoreTokens token_store;
    public IFormatUrls url_formatter;
    public ICreateInclusionConfigurators inclusion_factory;

    public UrlBuilder(IStoreTokens token_store, IFormatUrls url_formatter, ICreateInclusionConfigurators inclusion_factory)
    {
      this.token_store = token_store;
      this.url_formatter = url_formatter;
      this.inclusion_factory = inclusion_factory;
    }

    public IConfigureAUrl run<RequestType>()
    {
      return or<RequestType>(true);
    }

    public IConfigureAUrl include<ItemToInclude>(ItemToInclude item, Action<ISpecifyInclusionDetails<ItemToInclude>> configuration)
    {
      configuration(inclusion_factory.create_inclusion_for(item,token_store));
      return this;
    }

    void store_request_of<RequestType>()
    {
      token_store.store_token(UrlTokens.request, typeof(RequestType));
    }
    public IConfigureAUrl or<Request>(bool condition)
    {
      if (condition) store_request_of<Request>();
      return this;
    }

    public override string ToString()
    {
      return token_store.all_tokens().get_result_of_visiting_all_items_with(url_formatter);
    }
  }
}