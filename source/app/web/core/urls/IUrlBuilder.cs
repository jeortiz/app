namespace app.web.core.urls
{
  public interface IUrlBuilder
  {
    IConfigureAUrl to_run<RequestType>(); 
  }
}