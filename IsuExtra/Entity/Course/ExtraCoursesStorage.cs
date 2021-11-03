using System.Collections.Generic;
using System.Linq;
using Isu.Essence;
using IsuExtra.Tools;

namespace IsuExtra.Entity.Course
{
    public class ExtraCoursesStorage
    {
        public ExtraCoursesStorage()
        {
            ExtraCourses = new List<IExtraCourse>();
            History = new List<StudentExtraCourse>();
        }

        private List<IExtraCourse> ExtraCourses { get; }
        private List<StudentExtraCourse> History { get; }

        public IExtraCourse AddCourse(string name, Faculty faculty)
        {
            if (name == null)
                throw new ExtraCoursesStorageException("Name cannot be null.");
            var course = new ExtraCourse(name, faculty);
            ExtraCourses.Add(course);
            return course;
        }

        public IExtraCourse GetCourse(string name)
        {
            int count = ExtraCourses.Count(course => course.Name == name);
            if (count == 0)
                throw new IsuExtraServiceException("Course not in service.");
            return ExtraCourses.Find(course => course.Name == name);
        }

        public int CountEnrolls(Student student) => History.Count(studentExtraCourse => studentExtraCourse.Student == student);

        public IExtraCourse GetEnroll(Student student) => History.Find(studentExtraCourse => studentExtraCourse.Student == student)?.ExtraCourse;

        public void AddEnroll(Student student, IExtraCourse course) => History.Add(new StudentExtraCourse(student, course));
        public bool CheckStudent(Student student) => ExtraCourses.All(course => !course.ContainsStudent(student));
    }
}