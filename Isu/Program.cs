using System;
using System.Collections;
using System.Collections.Generic;
using Isu.Services;

namespace Isu
{
    internal class Program
    {
        private static void Main()
        {
            var isuService = new IsuService();
            var groups = new GroupName[5, 5];
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
            {
                groups[i, j] = new GroupName((CourseNumber)i, (byte)j);
                isuService.AddGroup(groups[i, j]);
            }
            }

            var rand = new Random();
            for (int i = 0; i < 100; i++)
                isuService.AddStudent(isuService.FindGroup(groups[rand.Next(1, 5), rand.Next(1, 5)]), "Student" + i.ToString());

            isuService.AddStudent(isuService.FindGroup(groups[2, 1]), "Ruslan Khakimov");
            Student me = isuService.FindStudent("Ruslan Khakimov");
            Group myNewGroup = isuService.FindGroup(new GroupName("M3200"));
            isuService.ChangeStudentGroup(me, myNewGroup);
            Console.WriteLine(me.GetGroupName().GetCourseNumber());
            Console.WriteLine(me.GetGroupName().GetGroupNumber());

            // var isu = new IsuService();
            // var groupM3101 = new GroupName("M3101");
            // var groupM3204 = new GroupName("M3204");
            // var groupM3300 = new GroupName("M3300");
            // var groupM3301 = new GroupName("M3301");
            // isu.AddGroup(groupM3101).AddStudent(new Student("Student0", groupM3101));
            // isu.AddGroup(groupM3204).AddStudent(new Student("Student1", groupM3204));
            // isu.AddGroup(groupM3300).AddStudent(new Student("Student2", groupM3300));
            // isu.AddGroup(groupM3301);
            //
            // isu.AddStudent(isu.FindGroup(groupM3101), "Student3");
            // isu.AddStudent(isu.FindGroup(groupM3204), "Student4");
            // isu.AddStudent(isu.FindGroup(groupM3300), "Student5");
            // isu.ChangeStudentGroup(isu.FindGroup(groupM3101).GetStudent(3), isu.FindGroup(groupM3301));
            // Console.WriteLine(isu.GetStudent(3).Name);
            // Console.WriteLine(isu.FindStudent("Student1").Name);
            // foreach (Student student in isu.FindStudents(groupM3101))
            //     Console.Write(student.Name + " ");
            // Console.WriteLine();
            // foreach (Group @group in isu.FindGroups(CourseNumber.Third))
            // {
            //     foreach (Student student in @group.GetStudents())
            //         Console.Write(student.Name + " ");
            //     Console.WriteLine();
            // }
            //
            // foreach (Student student in isu.FindStudents(CourseNumber.Second))
            //     Console.Write(student.Name + " ");
            // Console.WriteLine();
        }
    }
}