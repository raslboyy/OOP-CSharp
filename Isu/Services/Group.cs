using System.Collections.Generic;
using System.Linq;
using Isu.Tools;

namespace Isu.Services
{
    public class Group
    {
        private readonly GroupName _groupName;
        private readonly List<Student> _students = new List<Student>();

        public Group(GroupName name)
        {
            _groupName = name ?? throw new GroupException("groupName is null.");
        }

        private static int MaxStudentPerGroup => 20;
        public static int GetMaxStudentPerGroup() => MaxStudentPerGroup;
        public void AddStudent(Student student)
        {
            if (_students.Count == MaxStudentPerGroup)
                throw new GroupException("Reached max student per group.");
            _students.Add(student);
            student.SetGroupName(_groupName);
        }

        public bool RemoveStudent(Student student) => _students.Remove(student);

        public Student GetStudent(int id)
        {
            Student student = _students.Find(student => student.GetId() == id);
            if (student is null)
            {
                throw new GroupException("The group does not contain a student with the specified id.");
            }

            return student;
        }

        public Student FindStudent(string name)
        {
            return _students.FirstOrDefault(student => student.Name == name);
        }

        public Student FindStudent(int id) => _students.Find(student => student.GetId() == id);
        public GroupName GetGroupName() => _groupName;
        public CourseNumber GetCourseNumber() => _groupName.GetCourseNumber();

        public List<Student> GetStudents() => new List<Student>(_students);

        public override bool Equals(object obj) => Equals(obj as Group);

        public bool Equals(Group other) => _groupName.Equals(other._groupName);

        public override int GetHashCode() => _groupName.GetHashCode();

        public int GetSize() => _students.Count;
    }
}