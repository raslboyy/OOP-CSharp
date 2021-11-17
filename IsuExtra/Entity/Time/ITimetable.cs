using Isu.Essence;
using IsuExtra.Entity.Course;

namespace IsuExtra.Entity.Time
{
    public interface ITimetable : IGroupsTimetable, IStreamsTimetable
    {
        public bool IsIntersect(GroupName name, StreamNumber number);
    }
}