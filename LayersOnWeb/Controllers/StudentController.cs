using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LayersOnWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            var result = new List<Student>();

            foreach (var x in studentService.GetAllStudents())
            {
                result.Add(new Student { Email = x.Email, FullName = x.FullName, Group = x.Group, Hobby = x.Hobby, Average = x.Average, Status = x.Status });
            }
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public void Post(Student student)
        {
            studentService.AddStudent(new StudentModel { Email = student.Email, FullName = student.FullName, Group = student.Group, Hobby = student.Hobby, Average = 0, Status = null });
        }

        [HttpPut]
        [Authorize(Roles = "Teacher")]
        public bool Update(int id, StudentModel student)
        {
            try
            {
                return studentService.UpdateStudent(id, student);
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
            studentService.DeleteStudent(id);
        }
    }
}
