using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IRepository repository;
        public SubmissionService(IRepository repo)
        {
            repository = repo;
        }

        public List<SubmissionModel> GetAllSubmissions()
        {
            List<SubmissionModel> result = new List<SubmissionModel>();

            foreach (var x in repository.GetAll<SubmissionEntity>())
            {
                result.Add(new SubmissionModel { IdStudent = x.IdStudent, IdAssignment = x.IdAssignment, Link = x.Link, Comment = x.Comment });
            }

            return result;
        }

        public void AddSubmission(SubmissionModel submission, int assignmentId, int studentId)
        {
            var assignment = repository.GetAll<AssignmentEntity>().Where(x => x.Id == assignmentId).FirstOrDefault();
            var student = repository.GetAll<StudentEntity>().Where(x => x.Id == studentId).FirstOrDefault();

            if ((assignment != null) && (student != null))
            {
                repository.Add(new SubmissionEntity { IdStudent = studentId, IdAssignment = assignmentId, Link = submission.Link, Comment = submission.Comment });
                repository.SaveChanges();
            }
        }

    }
}
