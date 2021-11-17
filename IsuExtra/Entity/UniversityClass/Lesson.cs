using System;
using IsuExtra.Tools;

namespace IsuExtra.Entity.UniversityClass
{
    public readonly struct Lesson
    {
        public Lesson(DayOfWeek day, int hour, int minute, string lecturer, int classroom)
        {
            Day = day;
            if (hour is < 0 or > 24)
                throw new LessonException("Invalid hour.");
            Hour = hour;
            if (minute is < 0 or > 59)
                throw new LessonException("Invalid minute.");
            Minute = minute;
            Lecturer = lecturer;
            Classroom = classroom;
        }

        public DayOfWeek Day { get; }
        public int Hour { get; }
        public int Minute { get; }
        public string Lecturer { get; }
        public int Classroom { get; }

        public static bool operator ==(Lesson left, Lesson right) => left.Equals(right);

        public static bool operator !=(Lesson left, Lesson right) => !(left == right);

        public override bool Equals(object obj) => obj is Lesson other && Equals(other);

        public override int GetHashCode()
        {
            return HashCode.Combine((int)Day, Hour, Minute, Lecturer, Classroom);
        }

        public bool Equals(Lesson other) =>
            Day.Equals(other.Day) && Hour.Equals(other.Hour) && Minute.Equals(other.Minute);
    }
}