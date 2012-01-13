using System.Collections.Generic;

namespace app.web.core.urls
{
  public interface IStoreTokens
  {
    void store_token(object key, object value);
    IEnumerable<IRepresentAToken> all_tokens();
  }
}