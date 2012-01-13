using app.utility.containers.core;

namespace app.web.core.urls
{
  public class Url
  {
    public static IBuildUrls to
    {
      get
      {
        {
          return Container.fetch.an<IBuildUrls>();
        }
      }
    }
  }
}