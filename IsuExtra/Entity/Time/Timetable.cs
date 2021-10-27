using System.Collections.Generic;
using System.Linq;
using Isu.Essence;
using IsuExtra.Entity.Course;
using IsuExtra.Entity.UniversityClass;
using IsuExtra.Tools;

namespace IsuExtra.Entity.Time
{
    public class Timetable : ITimetable
    {
        public Timetable()
        {
            GroupsTimetable = new List<(GroupName, Lessons)>();
            StreamsTimetable = new List<(StreamNumber, Lessons)>();
        }

        public List<(GroupName, Lessons)> GroupsTimetable { get; }
        public List<(StreamNumber, Lessons)> StreamsTimetable { get; }

        public bool AddLessons(GroupName name, Lessons lessons)
        {
            if (Contains(name))
                return false;
            GroupsTimetable.Add((name, lessons));
            return true;
        }

        public Lessons GetLessons(GroupName name)
        {
            if (!Contains(name))
                throw new TimetableException("Timetable does not contain information about this group.");
            return GroupsTimetable.First(pair => pair.Item1 == name).Item2;
        }

        public bool AddLessons(StreamNumber number, Lessons lessons)
        {
            if (Contains(number))
                return false;
            StreamsTimetable.Add((number, lessons));
            return true;
        }

        public Lessons GetLessons(StreamNumber number)
        {
            if (!Contains(number))
                throw new TimetableException("Timetable does not contain information about this stream.");
            return StreamsTimetable.First(pair => pair.Item1 == number).Item2;
        }

        public bool IsIntersect(GroupName name, StreamNumber number)
        {
            Lessons groupLessons = GetLessons(name);
            Lessons streamLessons = GetLessons(number);
            return groupLessons.IsIntersect(streamLessons);
        }

        private bool Contains(GroupName name) => GroupsTimetable.Any(pair => pair.Item1 == name);

        private bool Contains(StreamNumber number) => StreamsTimetable.Any(pair => pair.Item1 == number);
    }
}