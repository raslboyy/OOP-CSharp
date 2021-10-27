using System.Collections.Generic;
using IsuExtra.Entity.Course;
using IsuExtra.Entity.UniversityClass;

namespace IsuExtra.Entity.Time
{
    public interface IStreamsTimetable
    {
        public List<(StreamNumber, Lessons)> StreamsTimetable { get; }
        bool AddLessons(StreamNumber number, Lessons lessons);
        Lessons GetLessons(StreamNumber number);
    }
}