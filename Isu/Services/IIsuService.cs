using System.Collections.Generic;
using Isu.Essence;

namespace Isu.Services
{
    public interface IIsuService
    {
        Group AddGroup(GroupName name);
        Student AddStudent(Group group, string name);

        Student GetStudent(int id);
        Student FindStudent(string name);

        List<Student> FindStudents(GroupName name);

        List<Student> FindStudents(CourseNumber courseNumber);

        Group FindGroup(GroupName name);

        List<Group> FindGroups(CourseNumber courseNumber);

        void ChangeStudentGroup(Student student, Group newGroup);
    }
}