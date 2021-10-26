using System.Collections.Generic;
using Isu.Essence;
using IsuExtra.Essence;
using IsuExtra.Essence.Course;
using IsuExtra.Essence.Time;
using IsuExtra.Essence.UniversityClass;

namespace IsuExtra.Services
{
    public interface IIsuExtraService
    {
        IExtraCourse AddExtraCourse(string name, Faculty faculty);
        IExtraCourse GetExtraCourse(string name);
        IStream AddStream(IExtraCourse course, Lessons lessons);
        Group AddGroup(GroupName name, Lessons lessons);
        bool EnrollStudent(IExtraCourse course, StreamNumber number, Student student);
        bool UnEnrollStudent(IExtraCourse course, StreamNumber number, Student student);
        List<IStream> FindStreams(IExtraCourse course);
        List<Student> FindStudents(IExtraCourse course, StreamNumber number);
        List<Student> GetUnEnrolledStudents(GroupName groupName);
        bool CheckStudent(Student student);
    }
}