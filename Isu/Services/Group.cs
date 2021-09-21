using System.Collections.Generic;
using System.Linq;
namespace Isu.Services
{
    public class Group
    {
        private readonly GroupName _name;
        private readonly List<Student> _students = new List<Student>();

        public Group(GroupName name) => _name = name;

        private static int MaxStudentPerGroup => 20;
        public void AddStudent(Student student)
        {
            if (_students.Count == MaxStudentPerGroup)
                throw new GroupException("Reached max student per group");
            _students.Add(student);
            student.SetGroupName(_name);
        }

        public bool RemoveStudent(Student student) => _students.Remove(student);

        public Student GetStudent(int id)
        {
            foreach (Student student in _students.Where(student => student.GetId() == id))
                return student;

            throw new GroupException("The group does not contain a student with the specified id.");
        }

        public Student FindStudent(string name)
        {
            return _students.FirstOrDefault(student => student.Name == name);
        }

        public GroupName GetGroupName() => _name;
        public CourseNumber GetCourseNumber() => _name.GetCourseNumber();

        public List<Student> GetStudents() => new List<Student>(_students);

        public override bool Equals(object obj) => Equals(obj as Group);

        public bool Equals(Group other) => _name.Equals(other._name);

        public override int GetHashCode() => _name.GetHashCode();
    }
}