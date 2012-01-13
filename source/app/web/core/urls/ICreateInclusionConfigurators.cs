namespace app.web.core.urls
{
  public interface ICreateInclusionConfigurators
  {
    ISpecifyInclusionDetails<ItemToInclude> create_inclusion_for<ItemToInclude>(ItemToInclude item,IStoreTokens tokens);
  }
}