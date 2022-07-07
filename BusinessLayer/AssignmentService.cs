using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IRepository repository;

        public AssignmentService(IRepository repo)
        {
            repository = repo;
        }
        public void AddAssignment(AssignmentModel assignment, int laboratoryId)
        {
            var laboratory = repository.GetAll<LaboratoryEntity>().Where(x => x.Id == laboratoryId).FirstOrDefault();

            if (laboratory != null)
            {
                repository.Add(new AssignmentEntity { Name = assignment.Name, Deadline = assignment.Deadline, Description = assignment.Description, LaboratoryId = laboratoryId });
                repository.SaveChanges();
            }
        }

        public void DeleteAssignment(int id)
        {
            var assignment = repository.GetAll<AssignmentEntity>().Where(x => x.Id == id).FirstOrDefault();

            if (assignment != null)
            {
                repository.Delete(assignment);
            }
        }

        public List<AssignmentModel> GetAllAssignments()
        {
            List<AssignmentModel> result = new List<AssignmentModel>();

            foreach (var x in repository.GetAll<AssignmentEntity>())
            {
                result.Add(new AssignmentModel { Name = x.Name, Deadline = x.Deadline, Description = x.Description, LaboratoryId = x.LaboratoryId });
            }

            return result;
        }

        public List<AssignmentModel> GetAssignmentsByIdLaboratory(int idLaboratory)
        {
            List<AssignmentModel> result = new List<AssignmentModel>();

            foreach (var x in repository.GetAll<AssignmentEntity>())
            {
                if (x.LaboratoryId == idLaboratory)
                {
                    result.Add(new AssignmentModel { Name = x.Name, Deadline = x.Deadline, Description = x.Description, LaboratoryId = x.LaboratoryId });
                }
            }
            return result;
        }

        public bool UpdateAssignment(int id, AssignmentModel assignment)
        {
            var _assignment = repository.GetAll<AssignmentEntity>().Where(x => x.Id == id).FirstOrDefault();

            if (_assignment != null)
            {
                _assignment.Name = assignment.Name;
                _assignment.Deadline = assignment.Deadline;
                _assignment.Description = assignment.Description;
                _assignment.LaboratoryId = assignment.LaboratoryId;

                repository.Update(_assignment);
                return true;
            }

            return false;
        }
    }
}
