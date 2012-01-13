using System;
using Machine.Specifications;
using app.specs.utility;
using app.web.application.catalogbrowing;
using app.web.core.urls;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Url))]
  public class UrlSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_getting_the_url_gateway : concern
    {
      Establish context = () =>
      {
        using (var scaffold = ObjectFactory.container.scaffold(spec, fake))
        {
          build_urls = scaffold.an<IBuildUrls>();
        }
      };

      Because of = () => 
        result = Url.to;

      It should_return_the_correct_url_builder = () => 
        result.ShouldEqual(build_urls);

      static IBuildUrls build_urls;
      static IBuildUrls result;
    }
  }
}