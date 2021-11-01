using System.Collections.Generic;
using System.Linq;
using Isu.Essence;
using Isu.Services;
using IsuExtra.Entity.Course;
using IsuExtra.Entity.Time;
using IsuExtra.Entity.UniversityClass;
using IsuExtra.Tools;

namespace IsuExtra.Services
{
    public class IsuExtraService : IsuService, IIsuExtraService
    {
        public IsuExtraService()
        {
            Timetable = new Timetable();
            Storage = new ExtraCoursesStorage();
        }

        private ExtraCoursesStorage Storage { get; }
        private ITimetable Timetable { get; }

        public IExtraCourse AddExtraCourse(string name, Faculty faculty) => Storage.AddCourse(name, faculty);

        public IExtraCourse GetExtraCourse(string name) => Storage.GetCourse(name);

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
            if (Timetable.IsIntersect(student.GetGroupName(), number))
                return false;
            int count = Storage.CountEnrolls(student);
            if (count == 2 || (count == 1 && Storage.FindEnroll(student).Faculty == course.Faculty))
                return false;

            bool result = course.EnrollStudent(number, student);
            if (result)
                Storage.AddEnroll(student, course);
            return result;
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
            return @group.GetStudents().Where(Storage.CheckStudent).ToList();
        }
    }
}