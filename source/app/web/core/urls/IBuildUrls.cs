namespace app.web.core.urls
{
  public interface IBuildUrls
  {
    IConfigureAUrl to_run<RequestType>(); 
  }
}