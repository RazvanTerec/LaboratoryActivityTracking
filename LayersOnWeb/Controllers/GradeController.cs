using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService gradeService;

        public GradeController(IGradeService _gradeService)
        {
            gradeService = _gradeService;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IEnumerable<Grade> Get()
        {
            var result = new List<Grade>();
            foreach (var x in gradeService.GetAllGrades())
            {
                result.Add(new Grade { IdStudent = x.IdStudent, IdSubmission = x.IdSubmission, GradeStudent = x.GradeStudent });

            }

            return result;
        }

        [HttpGet("Get-grades-by-student-id")]
        [Authorize(Roles = "Teacher")]
        public IEnumerable<Grade> GetById(int idStudent)
        {
            var result = new List<Grade>();
            foreach (var x in gradeService.GetGradesByStudentId(idStudent))
            {
                result.Add(new Grade { IdStudent = x.IdStudent, IdSubmission = x.IdSubmission, GradeStudent = x.GradeStudent });

            }

            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public void Post(Grade grade, int submissionId)
        {
            gradeService.AddGrade(new GradeModel { IdStudent = grade.IdStudent, IdSubmission = submissionId, GradeStudent = grade.GradeStudent }, submissionId);
        }

        [HttpGet("Average")]
        [Authorize(Roles = "Teacher")]
        public double CalculateAverage(int idStudent)
        {
            double avg = gradeService.CalculateAverage(idStudent);
            return avg;
        }

        [HttpGet("Status")]
        [Authorize(Roles = "Teacher")]
        public string ShowStatus(int idStudent)
        {
            return gradeService.ShowStatus(idStudent);
        }
    }
}
