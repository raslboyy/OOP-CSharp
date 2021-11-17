using Isu.Essence;

namespace IsuExtra.Entity.Course
{
    public class StudentExtraCourse
    {
        public StudentExtraCourse(Student student, IExtraCourse extraCourse)
        {
            Student = student;
            ExtraCourse = extraCourse;
        }

        public Student Student { get; }
        public IExtraCourse ExtraCourse { get; }
    }
}