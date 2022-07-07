
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IGradeService
    {
        List<GradeModel> GetAllGrades();
        void AddGrade(GradeModel grade, int submissionId);
        List<GradeModel> GetGradesByStudentId(int idStudent);
        double CalculateAverage(int idStudent);
        string ShowStatus(int idStudent);

    }
}
