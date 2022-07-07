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
    public class LaboratoryController : ControllerBase
    {
        private readonly ILaboratoryService laboratoryService;

        public LaboratoryController(ILaboratoryService _laboratoryService)
        {
            laboratoryService = _laboratoryService;
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IEnumerable<Laboratory> Get()
        {
            var result = new List<Laboratory>();
            foreach (var x in laboratoryService.GetAllLaboratoeies())
            {
                result.Add(new Laboratory { Number = x.Number, Date = x.Date, Title = x.Title, Objectives = x.Objectives, Description = x.Description });
            }
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public void Post(Laboratory laboratory)
        {
            laboratoryService.AddLaboratory(new LaboratoryModel { Number = laboratory.Number, Date = laboratory.Date, Title = laboratory.Title, Objectives = laboratory.Objectives, Description = laboratory.Description });
        }

        [HttpPut]
        [Authorize(Roles = "Teacher")]
        public bool Update(int id, LaboratoryModel laboratory)
        {
            try
            {
                return laboratoryService.UpdateLaboratory(id, laboratory);
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
            laboratoryService.DeleteLaboratory(id);
        }
    }
}
