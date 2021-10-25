using System;
using Isu.Essence;
using Isu.Services;
using IsuExtra.Essence.Course;
using IsuExtra.Essence.UniversityClass;
using IsuExtra.Services;
using DayOfWeek = IsuExtra.Essence.UniversityClass.DayOfWeek;

namespace IsuExtra
{
    internal class Program
    {
        private static void Main()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            IStream stream = AddDefaultStream(isu);
            Group @group = AddDefaultGroup(isu);

            Student student = AddDefaultStudent(isu, group);
            bool actual = isu.EnrollStudent(course, stream.Number, student);

            Console.WriteLine(actual);
        }

        private static IsuExtraService CreateDefaultIsuExtraService() => new IsuExtraService();

        private static Group AddDefaultGroup(IIsuExtraService service)
        {
            const string lecturer = "Lecturer";
            var lesson1 = new Lesson(DayOfWeek.Mon, 8, 20, lecturer, 0);
            var lesson2 = new Lesson(DayOfWeek.Mon, 10, 00, lecturer, 0);
            var lesson3 = new Lesson(DayOfWeek.Mon, 11, 40, lecturer, 0);
            return service.AddGroup(new GroupName("M3101"), new Lessons(lesson1, lesson2, lesson3));
        }

        private static IExtraCourse AddDefaultExtraCourse(IIsuExtraService service) =>
            service.AddExtraCourse("course", new Faculty('P'));

        private static IStream AddDefaultStream(IIsuExtraService service)
        {
            const string lecturer = "Lecturer";
            var lesson1 = new Lesson(DayOfWeek.Fri, 8, 20, lecturer, 0);
            var lesson2 = new Lesson(DayOfWeek.Fri, 10, 00, lecturer, 0);
            var lesson3 = new Lesson(DayOfWeek.Fri, 11, 40, lecturer, 0);
            return service.AddStream(AddDefaultExtraCourse(service), new Lessons(lesson1, lesson2, lesson3));
        }

        private static Student AddDefaultStudent(IIsuService service, Group @group) =>
            service.AddStudent(group, "Student");
    }
}