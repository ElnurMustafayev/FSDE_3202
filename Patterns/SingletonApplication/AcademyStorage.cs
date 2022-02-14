using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonApplication
{
    public class AcademyStorage
    {
        private static AcademyStorage instance;

        public static AcademyStorage Instance => instance ??= new AcademyStorage();

        private AcademyStorage() { }

        private List<Student> Students = new List<Student>();

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public List<Student> GetStudents()
        {
            return Students;
        }
    }
}
