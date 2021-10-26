using System.Collections.Generic;
using IsuExtra.Essence.Course;
using IsuExtra.Essence.UniversityClass;

namespace IsuExtra.Essence.Time
{
    public interface IStreamsTimetable
    {
        public List<(StreamNumber, Lessons)> StreamsTimetable { get; }
        bool AddLessons(StreamNumber number, Lessons lessons);
        Lessons GetLessons(StreamNumber number);
    }
}