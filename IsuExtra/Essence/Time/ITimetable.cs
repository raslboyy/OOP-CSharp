using Isu.Essence;
using IsuExtra.Essence.Course;

namespace IsuExtra.Essence.Time
{
    public interface ITimetable : IGroupsTimetable, IStreamsTimetable
    {
        public bool IsIntersect(GroupName name, StreamNumber number);
    }
}