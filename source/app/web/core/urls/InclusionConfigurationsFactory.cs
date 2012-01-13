namespace app.web.core.urls
{
    public class InclusionConfigurationsFactory : ICreateInclusionConfigurators
    {
        private readonly IMapAPropertyNameFromAnExpression mapper;

        public InclusionConfigurationsFactory(IMapAPropertyNameFromAnExpression mapper)
        {
            this.mapper = mapper;
        }

        public ISpecifyInclusionDetails<ItemToInclude> create_inclusion_for<ItemToInclude>(ItemToInclude item, IStoreTokens tokens)
        {
            ISpecifyInclusionDetails<ItemToInclude> url_inclusion = new UrlInclusion<ItemToInclude>(item, tokens, mapper);
            return url_inclusion;
        }
    }
}