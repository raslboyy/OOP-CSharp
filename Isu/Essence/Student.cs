namespace Isu.Essence
{
    public class Student
    {
        private static int _idCounter = 0;
        private readonly int _id;
        private GroupName _group;

        public Student(string name, GroupName @group)
        {
            Name = name;
            _id = _idCounter++;
            _group = @group;
        }

        public string Name { get; }

        public static bool operator ==(Student left, Student right) =>
            ReferenceEquals(left, right) || (!ReferenceEquals(left, null) && left.Equals(right));

        public static bool operator !=(Student left, Student right) => !(left == right);

        public int GetId() => _id;
        public GroupName GetGroupName() => _group;
        public void SetGroupName(GroupName newGroupName) => _group = newGroupName;

        public override bool Equals(object obj) => Equals(obj as Student);

        public bool Equals(Student other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return _id == other._id;
        }

        public override int GetHashCode() => _id.GetHashCode();
    }
}