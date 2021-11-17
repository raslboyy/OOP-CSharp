using System.Collections.Generic;
using System.Linq;

namespace IsuExtra.Entity.UniversityClass
{
    public class Lessons
    {
        public Lessons()
        {
            List = new List<Lesson>();
        }

        public Lessons(params Lesson[] list)
        {
            List = new List<Lesson>(list);
        }

        private List<Lesson> List { get; }

        public void AddLesson(Lesson lesson) => List.Add(lesson);

        public bool IsIntersect(Lessons other)
            => List.Any(lesson => other.List.Any(otherLesson => lesson == otherLesson));
    }
}