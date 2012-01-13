using System;

namespace app.web.core.urls
{
  public interface IConfigureAUrl
  {
    IConfigureAUrl or<Request>(bool condition);

    IConfigureAUrl include<ItemToInclude>(ItemToInclude item,
                                          Action<ISpecifyInclusionDetails<ItemToInclude>> configuration);
  }
}