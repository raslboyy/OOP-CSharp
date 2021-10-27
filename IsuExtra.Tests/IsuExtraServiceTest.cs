using System;
using System.Collections.Generic;
using Isu.Essence;
using Isu.Services;
using IsuExtra.Entity.Course;
using IsuExtra.Entity.UniversityClass;
using IsuExtra.Services;
using NUnit.Framework;

namespace IsuExtra.Tests
{
    public class IsuExtraServiceTest
    {
        [Test]
        public void AddExtraCourse_ExtraCourseAdded()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();

            isu.AddExtraCourse("name", new Faculty());

            IExtraCourse actual = isu.GetExtraCourse("name");
        }

        [Test]
        public void EnrollStudent_ReachMaxStudentPerStream_ReturnFalse()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            IStream stream = AddDefaultStream(isu, course);
            Group @group = AddDefaultGroup(isu);

            for (int i = 0; i < 5; i++)
            {
                Student trueStudent = AddDefaultStudent(isu, group);
                isu.EnrollStudent(course, stream.Number, trueStudent);
            }
            Student student = AddDefaultStudent(isu, group);
            bool actual = isu.EnrollStudent(course, stream.Number, student);
            
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void EnrollStudent_LessonsAreNotIntersect_ReturnTrue()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            IStream stream = AddDefaultStream(isu, course);
            Group @group = AddDefaultGroup(isu);
            
            Student student = AddDefaultStudent(isu, group);
            bool actual = isu.EnrollStudent(course, stream.Number, student);
            
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void EnrollStudent_LessonsAreIntersect_ReturnFalse()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            Group @group = AddDefaultGroup(isu);
            const string lecturer = "Lecturer";
            var lesson1 = new Lesson(DayOfWeek.Friday, 8, 20, lecturer, 0);
            var lesson2 = new Lesson(DayOfWeek.Monday, 10, 00, lecturer, 0);
            var lesson3 = new Lesson(DayOfWeek.Friday, 11, 40, lecturer, 0);
            IStream stream = isu.AddStream(course, new Lessons(lesson1, lesson2, lesson3));
            
            Student student = AddDefaultStudent(isu, group);
            bool actual = isu.EnrollStudent(course, stream.Number, student);
            
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void EnrollStudent_TwoStreamsInDifferentFaculties_OneDoesNotFit()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse falseCourse = isu.AddExtraCourse("course", new Faculty('P'));
            IExtraCourse trueCourse = isu.AddExtraCourse("course", new Faculty('K'));
            Group @group = AddDefaultGroup(isu);
            const string lecturer = "Lecturer";
            var lesson1 = new Lesson(DayOfWeek.Friday, 8, 20, lecturer, 0);
            var lesson2 = new Lesson(DayOfWeek.Monday, 10, 00, lecturer, 0);
            var lesson3 = new Lesson(DayOfWeek.Friday, 11, 40, lecturer, 0);
            IStream falseStream = isu.AddStream(falseCourse, new Lessons(lesson1, lesson2, lesson3));
            IStream trueStream = AddDefaultStream(isu, trueCourse);
            
            Student student = AddDefaultStudent(isu, group);
            bool actual = isu.EnrollStudent(trueCourse, trueStream.Number, student);
            
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void EnrollStudent_SameFaculties_ReturnFalse()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = isu.AddExtraCourse("course", new Faculty('M'));
            IStream stream = AddDefaultStream(isu, course);
            Group @group = AddDefaultGroup(isu);
            
            Student student = AddDefaultStudent(isu, group);
            bool actual = isu.EnrollStudent(course, stream.Number, student);
            
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void EnrollStudent_TryMoreThanTwoExtraCourse_ReturnFalse()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course1 = isu.AddExtraCourse("course", new Faculty('R'));
            IExtraCourse course2 = isu.AddExtraCourse("course", new Faculty('K'));
            IExtraCourse course3 = isu.AddExtraCourse("course", new Faculty('P'));
            IStream stream1 = AddDefaultStream(isu, course1);
            IStream stream2 = AddDefaultStream(isu, course2);
            IStream stream3 = AddDefaultStream(isu, course3);
            Group @group = AddDefaultGroup(isu);
            
            Student student = AddDefaultStudent(isu, group);
            isu.EnrollStudent(course1, stream1.Number, student);
            isu.EnrollStudent(course2, stream2.Number, student);
            bool actual = isu.EnrollStudent(course3, stream3.Number, student);
            
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void UnEnrollStudent_StudentWasEnrolled_ReturnTrue()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            IStream stream = AddDefaultStream(isu, course);
            Group @group = AddDefaultGroup(isu);
            
            Student student = AddDefaultStudent(isu, group);
            isu.EnrollStudent(course, stream.Number, student);
            bool actual = isu.UnEnrollStudent(course, stream.Number, student);
            
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void UnEnrollStudent_StudentWasNotEnrolled_ReturnFalse()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            IStream stream = AddDefaultStream(isu, course);
            Group @group = AddDefaultGroup(isu);
            
            Student student = AddDefaultStudent(isu, group);
            bool actual = isu.UnEnrollStudent(course, stream.Number, student);
            
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void FindStreams_ReturnCorrectList()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            Group @group = AddDefaultGroup(isu);
            
            IStream stream1 = AddDefaultStream(isu, course);
            IStream stream2 = AddDefaultStream(isu, course);
            var expected = new List<IStream>() {stream1, stream2};
            List<IStream> actual = isu.FindStreams(course);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindStudents_ReturnCorrectList()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            IStream stream = AddDefaultStream(isu, course);
            Group @group = AddDefaultGroup(isu);

            Student student1 = isu.AddStudent(group, "Student1");
            Student student2 = isu.AddStudent(group, "Student2");
            isu.EnrollStudent(course, stream.Number, student1);
            isu.EnrollStudent(course, stream.Number, student2);
            var expected = new List<Student>() {student1, student2};
            List<Student> actual = isu.FindStudents(course, stream.Number);
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetUnEnrolledStudents_ReturnCorrectList()
        {
            IsuExtraService isu = CreateDefaultIsuExtraService();
            IExtraCourse course = AddDefaultExtraCourse(isu);
            IStream stream = AddDefaultStream(isu, course);
            Group @group = AddDefaultGroup(isu);
            
            Student student1 = isu.AddStudent(group, "Student1");
            Student student2 = isu.AddStudent(group, "Student2");
            isu.EnrollStudent(course, stream.Number, student1);
            var expected = new List<Student>() {student2};
            List<Student> actual = isu.GetUnEnrolledStudents(group.GetGroupName());
            
            Assert.AreEqual(expected, actual);
        }

        private static IsuExtraService CreateDefaultIsuExtraService() => new IsuExtraService();

        private static Group AddDefaultGroup(IIsuExtraService service)
        {
            const string lecturer = "Lecturer";
            var lesson1 = new Lesson(DayOfWeek.Monday, 8, 20, lecturer, 0);
            var lesson2 = new Lesson(DayOfWeek.Monday, 10, 00, lecturer, 0);
            var lesson3 = new Lesson(DayOfWeek.Monday, 11, 40, lecturer, 0);
            return service.AddGroup(new GroupName("M3101"), new Lessons(lesson1, lesson2, lesson3));
        }

        private static IExtraCourse AddDefaultExtraCourse(IIsuExtraService service) =>
            service.AddExtraCourse("course", new Faculty('P'));

        private static IStream AddDefaultStream(IIsuExtraService service, IExtraCourse course)
        {
            const string lecturer = "Lecturer";
            var lesson1 = new Lesson(DayOfWeek.Friday, 8, 20, lecturer, 0);
            var lesson2 = new Lesson(DayOfWeek.Friday, 10, 00, lecturer, 0);
            var lesson3 = new Lesson(DayOfWeek.Friday, 11, 40, lecturer, 0);
            return service.AddStream(course, new Lessons(lesson1, lesson2, lesson3));
        }

        private static Student AddDefaultStudent(IIsuService service, Group @group) =>
            service.AddStudent(group, "Student");
    }
}