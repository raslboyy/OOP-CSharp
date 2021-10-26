using IsuExtra.Tools;

namespace IsuExtra.Essence.UniversityClass
{
    public class Lesson
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
            Lecturer = new Lecturer(lecturer);
            Classroom = new Classroom(classroom);
        }

        public DayOfWeek Day { get; }
        public int Hour { get; }
        public int Minute { get; }
        public ILecturer Lecturer { get; }
        public IClassroom Classroom { get; }
    }
}