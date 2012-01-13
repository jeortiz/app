using System;
using System.Collections.Generic;
using Machine.Specifications;
using app.web.core.urls;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(UrlBuilder))]
  public class UrlBuilderSpecs
  {
    public abstract class concern : Observes<IBuildUrls,
                                      UrlBuilder>
    {
      Establish c = () =>
      {
        token_store = depends.on<IStoreTokens>();
        visitor = depends.on<IFormatUrls>();
      };

      protected static IStoreTokens token_store;
      protected static IFormatUrls visitor;
    }

    public class when_a_request_is_specified : concern
    {
      Because b = () =>
        result = sut.run<StubRequest>();

      It should_store_the_request_token_in_the_token_store = () =>
        token_store.received(x => x.store_token(UrlTokens.request, typeof(StubRequest)));

      It should_return_an_item_to_continue_configuring_the_url = () =>
        result.ShouldEqual(sut);

      static IConfigureAUrl result;
    }

    public class when_formatting_as_a_string : concern
    {
      public class explicitly
      {
        Establish c = () =>
        {
          the_result_from_the_visitor = "sdfsdf";
          visitor.setup(x => x.get_result()).Return(the_result_from_the_visitor);
          token_store.setup(x => x.all_tokens()).Return(new List<IRepresentAToken>());
        };

        Because b = () =>
          result = sut.ToString();

        It should_return_the_result_of_visiting_the_token_store_with_the_formatting_visitor = () =>
          result.ShouldEqual(the_result_from_the_visitor);

        static string result;
        static string the_result_from_the_visitor;

      }
    }

    public class concern_for_configuring_the_url : Observes<IConfigureAUrl, UrlBuilder>
    {
      Establish c = () =>
      {
        token_store = depends.on<IStoreTokens>();
        visitor = depends.on<IFormatUrls>();
      };

      protected static IStoreTokens token_store;
      protected static IFormatUrls visitor;
    }

    public class when_a_conditional_is_specified : concern_for_configuring_the_url
    {
      public class and_the_condition_is_met
      {
        Because b = () =>
          result = sut.or<SecondRequest>(true);

        It should_add_the_request_to_the_token_store = () =>
          token_store.received(x => x.store_token(UrlTokens.request, typeof(SecondRequest)));

        It should_return_the_builder_to_keep_configuring = () =>
          result.ShouldEqual(sut);
      }

      public class and_the_condition_is_not_met
      {
        Because b = () =>
          result = sut.or<SecondRequest>(false);
          
        It should_add_the_request_to_the_token_store = () =>
          token_store.never_received(x => x.store_token(UrlTokens.request, typeof(SecondRequest)));

        It should_return_the_builder_to_keep_configuring = () =>
          result.ShouldEqual(sut);
      }

      static IConfigureAUrl result;
    }

    public class when_an_inclusion_is_specified : concern_for_configuring_the_url
    {
      Establish c = () =>
      {
        some_item = new TheItemToInclude();
        inclusion_details = fake.an<ISpecifyInclusionDetails<TheItemToInclude>>();
        inclusion_factory = depends.on<ICreateInclusionConfigurators>();

        inclusion_factory.setup(x => x.create_inclusion_for(some_item,token_store))
          .Return(inclusion_details);
      };

      Because b = () =>
        result = sut.include(some_item, x =>
        {
          x.ShouldEqual(inclusion_details);
        }
          );

      It should_return_the_builder_to_keep_configuring = () =>
        result.ShouldEqual(sut);

      static TheItemToInclude some_item;
      static IConfigureAUrl result;
      static Action<ISpecifyInclusionDetails<TheItemToInclude>> configuration;
      static ISpecifyInclusionDetails<TheItemToInclude> inclusion_details;
      static ICreateInclusionConfigurators inclusion_factory;
    }
  }

  public class StubRequest
  {
  }

  public class TheItemToInclude
  {
  }

  public class SecondRequest
  {
  }
}