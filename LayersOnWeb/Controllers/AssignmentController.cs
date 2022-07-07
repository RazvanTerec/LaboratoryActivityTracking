using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService assignmentService;

        public AssignmentController(IAssignmentService _assignmentService)
        {
            assignmentService = _assignmentService;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IEnumerable<Assignment> Get()
        {
            var result = new List<Assignment>();
            foreach (var x in assignmentService.GetAllAssignments())
            {
                result.Add(new Assignment { Name = x.Name, Deadline = x.Deadline, Description = x.Description, LaboratoryId = x.LaboratoryId });

            }

            return result;
        }

        [HttpGet("Get-assignments-by-id-laboratory")]
        [Authorize(Roles = "Student")]
        public IEnumerable<Assignment> GetAssignmentsByIdLaboratory(int idLaboratory)
        {
            var result = new List<Assignment>();
            foreach (var x in assignmentService.GetAssignmentsByIdLaboratory(idLaboratory))
            {
                result.Add(new Assignment { Name = x.Name, Deadline = x.Deadline, Description = x.Description, LaboratoryId = x.LaboratoryId });
            }
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public void Post(Assignment assignment, int laboratoryId)
        {
            assignmentService.AddAssignment(new AssignmentModel { Name = assignment.Name, Deadline = assignment.Deadline, Description = assignment.Description, LaboratoryId = laboratoryId }, laboratoryId);
        }

        [HttpPut]
        [Authorize(Roles = "Teacher")]
        public bool Update(int id, AssignmentModel assignment)
        {
            try
            {
                return assignmentService.UpdateAssignment(id, assignment);
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Teacher")]
        public void Delete(int id)
        {
            assignmentService.DeleteAssignment(id);
        }

    }
}
