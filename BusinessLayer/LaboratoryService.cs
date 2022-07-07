using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LaboratoryService : ILaboratoryService
    {
        private readonly IRepository repository;

        public LaboratoryService(IRepository repo)
        {
            repository = repo;
        }
        public void AddLaboratory(LaboratoryModel laboratory)
        {
            repository.Add(new LaboratoryEntity { Number = laboratory.Number, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description });
            repository.SaveChanges();
        }

        public void DeleteLaboratory(int id)
        {
            var laboratory = repository.GetAll<LaboratoryEntity>().Where(x => x.Id == id).FirstOrDefault();
            if (laboratory != null)
            {
                repository.Delete(laboratory);
            }
        }

        public List<LaboratoryModel> GetAllLaboratoeies()
        {
            List<LaboratoryModel> result = new List<LaboratoryModel>();
            foreach (var x in repository.GetAll<LaboratoryEntity>())
            {
                result.Add(new LaboratoryModel { Number = x.Number, Date = x.Date, Title = x.Title, Objectives = x.Objectives, Description = x.Description });
            }

            return result;
        }

        public bool UpdateLaboratory(int id, LaboratoryModel laboratory)
        {
            var _laboratory = repository.GetAll<LaboratoryEntity>().Where(x => x.Id == id).FirstOrDefault();

            if (_laboratory != null)
            {
                _laboratory.Number = laboratory.Number;
                _laboratory.Date = laboratory.Date;
                _laboratory.Title = laboratory.Title;
                _laboratory.Objectives = laboratory.Objectives;
                _laboratory.Description = laboratory.Description;

                repository.Update(_laboratory);
                return true;
            }

            return false;
        }
    }
}
