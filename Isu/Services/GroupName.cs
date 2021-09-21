using System;
using Isu.Tools;

namespace Isu.Services
{
    public enum CourseNumber
    {
        /// <summary>
        /// first course
        /// </summary>
        First = 1,

        /// <summary>
        /// second course
        /// </summary>
        Second,

        /// <summary>
        /// third course
        /// </summary>
        Third,

        /// <summary>
        /// fourth course
        /// </summary>
        Fourth,
    }

    public class GroupName
    {
        private readonly CourseNumber _courseNumber;
        private readonly byte _groupNumber;

        public GroupName(string name)
            : this((CourseNumber)Enum.Parse(typeof(CourseNumber), name[2..3]), byte.Parse(name[3..5]))
        {
            if (name.Length != 5 || name[..2] != "M3")
                throw new GroupNameException("Group name is incorrect");
            if (int.Parse(name[2..3]) > 4 || int.Parse(name[2..3]) < 1)
                throw new GroupNameException("Group name is incorrect: course number must belong to the range [1, 4].");
        }

        public GroupName(CourseNumber courseNumber, byte groupNumber)
        {
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
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return (_courseNumber == other._courseNumber) && (_groupNumber == other._groupNumber);
        }

        public override int GetHashCode() => (_courseNumber, _groupNumber).GetHashCode();

        public byte GetGroupNumber() => _groupNumber;
        public CourseNumber GetCourseNumber() => _courseNumber;
    }
}