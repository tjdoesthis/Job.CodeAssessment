using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Job.CodeAssessment.Tests.Integration.Setup.CastleWindsor;

namespace Job.CodeAssessment.Tests.Integration
{
    [TestClass]
    public class UnitTestBase
    {
        private IWindsorContainer _container;
        protected IStudentService _studentService;

        [TestInitialize]
        public void Init()
        {
            _container = new WindsorContainer();

            BootStrapper.ConfigureWindsorCastle(_container);

            _studentService = _container.Resolve<IStudentService>();
        }

        [TestCleanup]
        public void Dispose()
        {
            _container.Release(_studentService);

            _container.Dispose();
        }

    }
}
