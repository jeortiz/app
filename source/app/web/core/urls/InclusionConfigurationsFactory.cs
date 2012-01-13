namespace app.web.core.urls
{
    public class InclusionConfigurationsFactory : ICreateInclusionConfigurators
    {
        public ISpecifyInclusionDetails<ItemToInclude> create_inclusion_for<ItemToInclude>(ItemToInclude item, IStoreTokens tokens)
        {
            throw new System.NotImplementedException();
        }
    }
}