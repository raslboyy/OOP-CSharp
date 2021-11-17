using System.Collections.Generic;
using Isu.Essence;

namespace IsuExtra.Entity.Course
{
    public class Stream : IStream
    {
        public Stream(int number, int maxStudentPerStream = 5)
        {
            Number = new StreamNumber(number);
            Students = new List<Student>();
            MaxStudentPerStream = maxStudentPerStream;
        }

        public StreamNumber Number { get; }
        public List<Student> Students { get; }
        private int MaxStudentPerStream { get; }

        public bool Enroll(Student student)
        {
            if (ContainsStudent(student) || Students.Count == MaxStudentPerStream)
                return false;
            Students.Add(student);
            return true;
        }

        public bool UnEnroll(Student student) => Students.Remove(student);

        public bool ContainsStudent(Student student) => Students.Contains(student);
    }
}