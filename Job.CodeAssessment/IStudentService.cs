using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Job.CodeAssessment
{
    public interface IStudentService
    {
        Student GetStudent(int studentId, bool isStudentArchived);
    }
}
