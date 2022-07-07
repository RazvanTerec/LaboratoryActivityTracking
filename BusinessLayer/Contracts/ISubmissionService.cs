using System.Collections.Generic;

namespace BusinessLayer
{
    public interface ISubmissionService
    {
        List<SubmissionModel> GetAllSubmissions();
        void AddSubmission(SubmissionModel submission, int assignmentId, int studentId);
    }
}
