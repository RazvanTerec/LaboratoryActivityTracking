using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class StudentService : IStudentService
    {
        private readonly IRepository repository;

        public StudentService(IRepository repo)
        {
            repository = repo;
        }
        public void AddStudent(StudentModel student)
        {
            repository.Add(new StudentEntity { Email = student.Email, FullName = student.FullName, Group = student.Group, Hobby = student.Hobby, Average = 0, Status = null });
            repository.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = repository.GetAll<StudentEntity>().Where(x => x.Id == id).FirstOrDefault();
            if (student != null)
            {
                repository.Delete(student);
            }
        }


        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> result = new List<StudentModel>();
            GradeService grade = new GradeService(repository);
            double avg = 0;
            string status = null;

            foreach (var x in repository.GetAll<StudentEntity>())
            {
                avg = grade.CalculateAverage(x.Id);
                status = grade.ShowStatus(x.Id);
                result.Add(new StudentModel { Email = x.Email, FullName = x.FullName, Group = x.Group, Hobby = x.Hobby, Average = avg, Status = status });
                x.Average = avg;
                x.Status = status;
                repository.Update(x);
            }

            return result;
        }

        public bool UpdateStudent(int id, StudentModel student)
        {
            var _student = repository.GetAll<StudentEntity>().Where(x => x.Id == id).FirstOrDefault();

            if (_student != null)
            {
                _student.Email = student.Email;
                _student.FullName = student.FullName;
                _student.Group = student.Group;
                _student.Hobby = student.Hobby;

                repository.Update(_student);
                return true;
            }

            return false;
        }
    }
}
