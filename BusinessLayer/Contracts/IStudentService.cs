using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IStudentService
    {
        List<StudentModel> GetAllStudents();
        void AddStudent(StudentModel student);
        bool UpdateStudent(int id, StudentModel student);
        void DeleteStudent(int id);
    }
}
