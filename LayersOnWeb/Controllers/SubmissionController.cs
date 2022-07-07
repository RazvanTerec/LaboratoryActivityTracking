using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService submissionService;

        public SubmissionController(ISubmissionService _submissionService)
        {
            submissionService = _submissionService;
        }

        [HttpGet]
        public IEnumerable<Submission> Get()
        {
            var result = new List<Submission>();
            foreach (var x in submissionService.GetAllSubmissions())
            {
                result.Add(new Submission { IdStudent = x.IdStudent, IdAssignment = x.IdAssignment, Link = x.Link, Comment = x.Comment });

            }

            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public void Post(Submission submission, int assignmentId, int studentId)
        {
            submissionService.AddSubmission(new SubmissionModel { IdStudent = studentId, IdAssignment = assignmentId, Link = submission.Link, Comment = submission.Comment }, assignmentId, studentId);
        }

    }
}
