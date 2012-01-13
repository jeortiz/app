using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Rhino.Mocks;
using app.utility.extensions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(EnumerableExtensions))]
  public class EnumerableExtensionsSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_iterating_a_set_of_items : concern
    {
      Establish c = () =>
      {
        items = Enumerable.Range(1, 5).ToList();
      };

      Because b = () =>
        result = items.each();

      It should_return_all_of_the_items = () =>
        result.ShouldContain(1, 2, 3, 4, 5);

      static int items_visited;
      static IEnumerable<int> items;
      static IEnumerable<int> result;
    }

    public class when_visiting_all_items_with_a_visitor : concern
    {
      public class with_a_delegate_based_visitor
      {
        Establish c = () =>
        {
          items = Enumerable.Range(1, 100).ToList();
        };

        Because b = () =>
        {
          items.visit_all_items_with(x =>
          {
            items_visited ++;
          });
        };

        It should_process_each_of_the_items_with_the_visitor = () =>
          items_visited.ShouldEqual(100);

        static int items_visited;
        static IEnumerable<int> items;
      }

      public class with_a_specific_visitor
      {
        Establish c = () =>
        {
          items = Enumerable.Range(1, 100).ToList();
          visitor = fake.an<IProcessAnItem<int>>();
        };

        Because b = () =>
        {
          items.visit_all_items_with(visitor);
        };

        It should_process_each_of_the_items_with_the_visitor = () =>
          visitor.received(x => x.process(Arg<int>.Is.Anything)).Times(100);

        static int items_visited;
        static IProcessAnItem<int> visitor;
        static IEnumerable<int> items;
      }
    }

    public class when_getting_the_result_of_visiting_all_items_with_a_visitor : concern
    {
      Establish c = () =>
      {
        items = Enumerable.Range(1, 100).ToList();
        visitor = fake.an<IProcessAndItemAndReturnState<int, int>>();
        visitor.setup(x => x.get_result()).Return(42);
      };

      Because b = () =>
      {
        result  =items.get_result_of_visiting_all_items_with(visitor);
      };

      It should_process_each_item_using_the_visitor = () =>
        visitor.received(x => x.process(Arg<int>.Is.Anything)).Times(100);
        
      It should_return_the_result_from_the_visitor = () =>
        result.ShouldEqual(42);

      static IEnumerable<int> items;
      static int result;
      static IProcessAndItemAndReturnState<int,int> visitor;
    }
  }
}
