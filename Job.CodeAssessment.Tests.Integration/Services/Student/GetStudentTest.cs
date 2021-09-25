using Microsoft.VisualStudio.TestTools.UnitTesting;
using Job.CodeAssessment.Tests.Integration;

namespace Job.CodeAssessment.Tests.Integration.Services.Student
{
    [TestClass]
    public class GetStudentTest : UnitTestBase
    {
        [TestMethod]
        public void GetValidStudentTest()
        {
            var student = _studentService.GetStudent(1, false);
        }
    }
}
