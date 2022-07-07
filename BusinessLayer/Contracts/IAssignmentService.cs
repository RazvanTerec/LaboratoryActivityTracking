using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IAssignmentService
    {
        List<AssignmentModel> GetAllAssignments();
        List<AssignmentModel> GetAssignmentsByIdLaboratory(int idLaboratory);
        void AddAssignment(AssignmentModel assignment, int laboratoryId);
        bool UpdateAssignment(int id, AssignmentModel assignment);
        void DeleteAssignment(int id);
    }
}
