using System;

namespace Isu.Services
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

        public int GetId() => _id;
        public GroupName GetGroupName() => _group;
        public void SetGroupName(GroupName newGroupName) => _group = newGroupName;
    }
}