using System.Collections.Generic;
using System.Linq;
using Isu.Tools;

namespace Isu.Services
{
    public class IsuService : IIsuService
    {
        private readonly List<Group> _groups = new List<Group>();
        public Group AddGroup(GroupName name)
        {
            var group = new Group(name);
            if (_groups.Contains(group))
                throw new IsuException("This group is already in the Isu.");
            _groups.Add(group);
            return group;
        }

        public Student AddStudent(Group group, string name)
        {
            var student = new Student(name, group.GetGroupName());
            group.AddStudent(student);
            return student;
        }

        public Student GetStudent(int id)
        {
            foreach (Group @group in _groups)
            {
                try
                {
                    Student student = @group.GetStudent(id);
                    return student;
                }
                catch
                {
                    // ignored
                }
            }

            throw new IsuException("The Isu does not contain a student with the specified id.", new GroupException());
        }

        public Student FindStudent(string name)
        {
            return (from @group in _groups where @group.FindStudent(name) != null select @group.FindStudent(name)).FirstOrDefault();
        }

        public List<Student> FindStudents(GroupName name)
        {
            return FindGroup(name) is null ? null : FindGroup(name).GetStudents();
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            var studentList = new List<Student>();
            foreach (Group @group in FindGroups(courseNumber))
                studentList.AddRange(@group.GetStudents());
            return studentList;
        }

        public Group FindGroup(GroupName name)
        {
            return _groups.FirstOrDefault(@group => @group.GetGroupName() == name);
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return _groups.Where(@group => @group.GetCourseNumber() == courseNumber).ToList();
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            if (FindGroup(newGroup.GetGroupName()) is null)
                throw new IsuException("The new student group is not in the Isu.");
            if (FindStudent(student.Name) is null)
                throw new IsuException("The student is not in the Isu.");
            FindGroup(student.GetGroupName()).RemoveStudent(student);
            newGroup.AddStudent(student);
        }
    }
}