using System.Collections.Generic;
using Isu.Essence;

namespace IsuExtra.Essence.Course
{
    public interface IExtraCourse
    {
        public string Name { get; }
        public Faculty Faculty { get; }
        public List<IStream> Streams { get; }
        public IStream AddStream();
        public List<Student> FindStudents(StreamNumber number);
        public bool EnrollStudent(StreamNumber stream, Student student);
        public bool UnEnrollStudent(StreamNumber stream, Student student);
        public bool ContainsStudent(Student student);
    }
}