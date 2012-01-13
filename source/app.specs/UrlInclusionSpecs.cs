using System;
using System.Linq.Expressions;
using Machine.Specifications;
using app.specs.utility;
using app.web.core.urls;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(UrlInclusion<>))]
  public class UrlInclusionSpecs
  {
    public abstract class concern : Observes<ISpecifyInclusionDetails<ItemToInclude>,
                                      UrlInclusion<ItemToInclude>>
    {
    }

    public class when_including_the_value_of_a_property : concern
    {
      Establish c = () =>
      {
        token_store = depends.on<IStoreTokens>();
        property_name_mapper = depends.on<IMapAPropertyNameFromAnExpression>();
        property_name = ObjectFactory.expressions.to_target<ItemToInclude>().property_name_of(x => x.value);
        item = new ItemToInclude {value = 42};
        depends.on(item);
        expression = x => x.value;
        property_name_mapper.setup(x => x.map_from(expression)).Return(property_name);
      };

      Because b = () =>
        sut.include(expression);

      It should_store_a_token_for_the_property_with_the_value_of_the_property_from_the_item = () =>
        token_store.received(x => x.store_token(property_name, item.value));

      static IStoreTokens token_store;
      static ItemToInclude item;
      static string property_name;
      static IMapAPropertyNameFromAnExpression property_name_mapper;
      static Expression<Func<ItemToInclude,int>> expression;
    }

    public class ItemToInclude
    {
      public int value { get; set; }
    }
  }
}