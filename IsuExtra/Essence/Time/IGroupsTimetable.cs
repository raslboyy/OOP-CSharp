using System.Collections.Generic;
using Isu.Essence;
using IsuExtra.Essence.UniversityClass;

namespace IsuExtra.Essence.Time
{
    public interface IGroupsTimetable
    {
        public List<(GroupName, Lessons)> GroupsTimetable { get; }
        bool AddLessons(GroupName name, Lessons lessons);
        Lessons GetLessons(GroupName name);
    }
}