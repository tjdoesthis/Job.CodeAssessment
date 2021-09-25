using System;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Job.CodeAssessment
{
    public class StudentService : IStudentService
    {
        public StudentService()
        {

        }
        public Student GetStudent(int studentId, bool isStudentArchived)
        {

            Student archivedStudent = null;

            if (isStudentArchived)
            {
                var archivedDataService = new ArchivedDataService();
                archivedStudent = archivedDataService.GetArchivedStudent(studentId);

                return archivedStudent;
            }
            else
            {

                var failoverRespository = new FailoverRepository();
                var failoverEntries = failoverRespository.GetFailOverEntries();


                var failedRequests = 0;

                foreach (var failoverEntry in failoverEntries)
                {
                    if (failoverEntry.DateTime > DateTime.Now.AddMinutes(-10))
                    {
                        failedRequests++;
                    }
                }

                StudentResponse studentResponse = null;
                Student student = null;

                if (failedRequests > 100 && (ConfigurationManager.AppSettings["IsFailoverModeEnabled"] == "true" || ConfigurationManager.AppSettings["IsFailoverModeEnabled"] == "True"))
                {
                    studentResponse = FailoverStudentDataAccess.GetStudentById(studentId);
                }
                else
                {
                    var dataAccess = new StudentDataAccess();
                    studentResponse = dataAccess.LoadStudent(studentId);

                    
                }

                if (studentResponse.IsArchived)
                {
                    var archivedDataService = new ArchivedDataService();
                    student = archivedDataService.GetArchivedStudent(studentId);
                }
                else
                {
                    student = studentResponse.Student;
                }


                return student;
            }
        }
    }
}
