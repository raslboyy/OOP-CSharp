using System;
using Isu.Tools;

namespace Isu.Essence
{
    public class GroupName
    {
        private readonly CourseNumber _courseNumber;
        private readonly byte _groupNumber;
        private readonly Faculty _faculty;

        public GroupName(string name)
            : this((CourseNumber)Enum.Parse(typeof(CourseNumber), name[2..3]), byte.Parse(name[3..5]), new Faculty(name[0]))
        {
            if (name.Length != 5)
                throw new GroupNameException("Group name is incorrect");
            if (int.Parse(name[2..3]) > 4 || int.Parse(name[2..3]) < 1)
                throw new GroupNameException("Group name is incorrect: course number must belong to the range [1, 4].");
        }

        public GroupName(CourseNumber courseNumber, byte groupNumber, Faculty? faculty = null)
        {
            _faculty = faculty ?? new Faculty('M');
            if (!char.IsUpper(_faculty.Literal))
                throw new GroupNameException("Group name is incorrect: faculty can be uppercase.");
            _courseNumber = courseNumber;
            if (groupNumber > 99)
                throw new GroupNameException("Group name is incorrect: group number cannot be more than 99.");
            _groupNumber = groupNumber;
        }

        public static bool operator ==(GroupName lhs, GroupName rhs)
        {
            if (lhs is null)
                return rhs is null;
            return lhs.Equals(rhs);
        }

        public static bool operator !=(GroupName lhs, GroupName rhs) => !(lhs == rhs);

        public override bool Equals(object obj) => Equals(obj as GroupName);

        public bool Equals(GroupName other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return (GetCourseNumber() == other.GetCourseNumber()) && (GetGroupNumber() == other.GetGroupNumber());
        }

        public override int GetHashCode() => (_courseNumber, _groupNumber).GetHashCode();

        public byte GetGroupNumber() => _groupNumber;
        public CourseNumber GetCourseNumber() => _courseNumber;

        public Faculty GetFaculty() => _faculty;
    }
}