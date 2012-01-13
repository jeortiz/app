namespace app.web.core.urls
{
  public interface IBuildUrls : IConfigureAUrl
  {
    IConfigureAUrl run<RequestType>(); 
  }
}