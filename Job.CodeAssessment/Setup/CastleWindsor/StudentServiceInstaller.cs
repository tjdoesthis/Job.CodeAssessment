using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Job.CodeAssessment.Setup.CastleWindsor
{
    public class StudentServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly().Pick()
                    .WithServiceDefaultInterfaces()
                    .Configure(c => c.LifestyleTransient()));
        }
    }
}
