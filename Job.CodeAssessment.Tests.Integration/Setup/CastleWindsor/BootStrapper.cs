using Castle.Windsor;
using Castle.Windsor.Installer;
using Job.CodeAssessment.Setup.CastleWindsor;

namespace Job.CodeAssessment.Tests.Integration.Setup.CastleWindsor
{
    public static class BootStrapper
    {
        public static void ConfigureWindsorCastle(IWindsorContainer container)
        {
            container.Install(FromAssembly.This());

            container.Install(FromAssembly.Containing<StudentServiceInstaller>());
        }
    }
}
