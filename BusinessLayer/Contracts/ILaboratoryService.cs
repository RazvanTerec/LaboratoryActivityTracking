using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ILaboratoryService
    {
        List<LaboratoryModel> GetAllLaboratoeies();
        void AddLaboratory(LaboratoryModel laboratory);
        bool UpdateLaboratory(int id, LaboratoryModel laboratory);
        void DeleteLaboratory(int id);
    }
}
