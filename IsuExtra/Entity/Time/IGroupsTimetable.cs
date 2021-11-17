using System.Collections.Generic;
using Isu.Essence;
using IsuExtra.Entity.UniversityClass;

namespace IsuExtra.Entity.Time
{
    public interface IGroupsTimetable
    {
        public List<(GroupName, Lessons)> GroupsTimetable { get; }
        bool AddLessons(GroupName name, Lessons lessons);
        Lessons GetLessons(GroupName name);
    }
}