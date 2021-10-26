using System.Collections.Generic;
using Isu.Essence;

namespace IsuExtra.Essence.Course
{
    public interface IStream
    {
        public StreamNumber Number { get; }
        public List<Student> Students { get; }
        public bool Enroll(Student student);
        public bool UnEnroll(Student student);
        public bool ContainsStudent(Student student);
    }
}