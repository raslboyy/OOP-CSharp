using System.Collections.Generic;
using System.Linq;
using Isu.Essence;
using Isu.Services;
using IsuExtra.Essence.Course;
using IsuExtra.Essence.Time;
using IsuExtra.Essence.UniversityClass;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService : IsuService, IIsuExtraService
    {
        public IsuExtraService()
        {
            ExtraCourses = new List<IExtraCourse>();
            Timetable = new Timetable();
        }

        private List<IExtraCourse> ExtraCourses { get; }
        private ITimetable Timetable { get; }

        public IExtraCourse AddExtraCourse(string name, Faculty faculty)
        {
            if (name == null)
                throw new IsuExtraServiceException("Name of ExtraCourse cannot be null.");
            var course = new ExtraCourse(name, faculty);
            ExtraCourses.Add(course);
            return course;
        }

        public IExtraCourse GetExtraCourse(string name)
        {
            int count = ExtraCourses.Count(course => course.Name == name);
            if (count != 1)
                throw new IsuExtraServiceException("Invalid ExtraCourse name.");
            return ExtraCourses.Find(course => course.Name == name);
        }

        public IStream AddStream(IExtraCourse course, Lessons lessons)
        {
            if (course == null)
                throw new IsuExtraServiceException("ExtraCourse cannot be null.");
            IStream stream = course.AddStream();
            Timetable.AddLessons(stream.Number, lessons);
            return stream;
        }

        public Group AddGroup(GroupName name, Lessons lessons)
        {
            if (name == null)
                throw new IsuExtraServiceException("GroupName cannot name.");
            Timetable.AddLessons(name, lessons);
            return AddGroup(name);
        }

        public bool EnrollStudent(IExtraCourse course, StreamNumber number, Student student)
        {
            if (course == null)
                throw new IsuExtraServiceException("ExtraCourse cannot be null.");
            return !Timetable.IsIntersect(student.GetGroupName(), number) && course.EnrollStudent(number, student);
        }

        public bool UnEnrollStudent(IExtraCourse course, StreamNumber number, Student student)
        {
            if (course == null)
                throw new IsuExtraServiceException("ExtraCourse cannot be null.");
            return course.UnEnrollStudent(number, student);
        }

        public List<IStream> FindStreams(IExtraCourse course) => course.Streams;

        public List<Student> FindStudents(IExtraCourse course, StreamNumber number) => course.FindStudents(number);

        public List<Student> GetUnEnrolledStudents(GroupName groupName)
        {
            if (groupName == null)
                throw new IsuExtraServiceException("GroupName cannot be null.");
            Group group = FindGroup(groupName);
            return @group.GetStudents().Where(CheckStudent).ToList();
        }

        public bool CheckStudent(Student student) => ExtraCourses.Any(course => course.ContainsStudent(student));
    }
}