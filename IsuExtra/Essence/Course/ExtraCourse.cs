using System.Collections.Generic;
using System.Linq;
using Isu.Essence;
using IsuExtra.Tools;

namespace IsuExtra.Essence.Course
{
    public class ExtraCourse : IExtraCourse
    {
        public ExtraCourse(string name, Faculty faculty)
        {
            Name = name;
            Faculty = faculty;
            Streams = new List<IStream>();
        }

        public string Name { get; }
        public Faculty Faculty { get; }
        public List<IStream> Streams { get; }

        public IStream AddStream()
        {
            var stream = new Stream(Streams.Count);
            Streams.Add(stream);
            return stream;
        }

        public List<Student> FindStudents(StreamNumber number) =>
            !IsValidIndex((int)number) ? null : GetStream(number).Students;

        public bool EnrollStudent(StreamNumber stream, Student student) =>
            CheckFaculty(student.GetGroupName().GetFaculty()) && GetStream(stream).Enroll(student);

        public bool UnEnrollStudent(StreamNumber stream, Student student) => GetStream(stream).UnEnroll(student);

        public bool ContainsStudent(Student student) => Streams.Any(stream => stream.ContainsStudent(student));

        public IStream GetStream(StreamNumber number)
        {
            if (!IsValidIndex((int)number))
                throw new ExtraCourseException("Invalid StreamNumber.");
            return Streams[(int)number];
        }

        private bool IsValidIndex(int i) => !(i < 0 || i > Streams.Count - 1);
        private bool CheckFaculty(Faculty other) => Faculty != other;
    }
}