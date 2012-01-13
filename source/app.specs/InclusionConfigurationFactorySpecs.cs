 using System;
 using System.Linq.Expressions;
 using Machine.Specifications;
 using app.web.core.urls;
 using developwithpassion.specifications.extensions;
 using developwithpassion.specifications.rhinomocks;

namespace app.specs
{

    [Subject(typeof(InclusionConfigurationsFactory))]
     public class InclusionConfigurationFactorySpecs
     {
         public abstract class concern :  Observes<ICreateInclusionConfigurators,
                                              InclusionConfigurationsFactory>
         {
        
         }

         public class when_creating_an_inclusion_for_an_item : concern
         {
             Establish c = () =>
                               {
                                   item = fake.an<StubItemType>();
                                   
                                   tokens_store = fake.an<IStoreTokens>();
                                   name_mapper = depends.on<IMapAPropertyNameFromAnExpression>();
                               };

             Because b = () =>
                 result = sut.create_inclusion_for(item,tokens_store);


             private It should_return_an_url_inclusion_for_the_item = () =>
                                                                          {

                                                                              var inclusion = result.ShouldBeAn<UrlInclusion<StubItemType>>();
                                                                              inclusion.item.ShouldEqual(item);
                                                                              inclusion.token_store.ShouldEqual(tokens_store);
                                                                              inclusion.name_mapper.ShouldEqual(name_mapper);
                                                                          };

             private static IMapAPropertyNameFromAnExpression name_mapper;
             private static StubItemType item;
             private static IStoreTokens tokens_store;
             private static ISpecifyInclusionDetails<StubItemType> result;
             private static ISpecifyInclusionDetails<StubItemType> url_inclusion;
         }
     }

    public class StubItemType
    {
    }
}
