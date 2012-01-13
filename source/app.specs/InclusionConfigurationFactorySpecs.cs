 using Machine.Specifications;
 using app.web.core.urls;
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

         public class when_observation_name : concern
         {
             Establish c = () =>
                             {
            
                             };

             Because b = () =>
                             {
        
                             };

        
             It first_observation = () =>
                        {
                            
            
            
                        };
         }
     }
 }
