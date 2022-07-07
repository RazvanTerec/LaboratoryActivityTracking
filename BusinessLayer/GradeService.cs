
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class GradeService : IGradeService
    {
        private readonly IRepository repository;

        public GradeService(IRepository repo)
        {
            repository = repo;
        }

        public List<GradeModel> GetAllGrades()
        {
            List<GradeModel> result = new List<GradeModel>();

            foreach (var x in repository.GetAll<GradeEntity>())
            {
                result.Add(new GradeModel { IdStudent = x.IdStudent, IdSubmission = x.IdSubmission, GradeStudent = x.GradeStudent });
            }

            return result;
        }

        public List<GradeModel> GetGradesByStudentId(int idStudent)
        {
            List<GradeModel> result = new List<GradeModel>();

            foreach (var x in repository.GetAll<GradeEntity>())
            {
                if (x.IdStudent == idStudent)
                {
                    result.Add(new GradeModel { IdStudent = x.IdStudent, IdSubmission = x.IdSubmission, GradeStudent = x.GradeStudent });
                }
            }
            return result;
        }

        public double CalculateAverage(int idStudent)
        {
            double average = 0;
            int count = 0;
            var result = GetGradesByStudentId(idStudent);

            foreach (var x in result)
            {
                count++;
                average += x.GradeStudent;
            }

            if (average > 0)
            {
                return average / count;
            }

            return 0;
        }

        public string ShowStatus(int idStudent)
        {
            double avg = CalculateAverage(idStudent);
            var result = GetGradesByStudentId(idStudent);

            if (avg >= 6)
            {
                foreach (var x in result)
                {
                    if (x.GradeStudent < 5)
                    {
                        return "Failed! At least one grade is less than 5.";
                    }
                }
                return "Passed!";
            }

            return "Failed! The average is less than 6.";
        }

        public void AddGrade(GradeModel grade, int submissionId)
        {
            var submission = repository.GetAll<SubmissionEntity>().Where(x => x.Id == submissionId).FirstOrDefault();

            if (submission != null)
            {
                repository.Add(new GradeEntity { IdStudent = submission.IdStudent, IdSubmission = submissionId, GradeStudent = grade.GradeStudent });
                repository.SaveChanges();
            }
        }
    }
}
