using System;
using Isu.Essence;
using Isu.Services;
using Isu.Tools;
using NUnit.Framework;

namespace Isu.Tests
{
    public class Tests
    {
        private IIsuService _isuService;

        [SetUp]
        public void Setup()
        {
            _isuService = new IsuService();
            var groups = new GroupName[5, 5];
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    groups[i, j] = new GroupName((CourseNumber) i, (byte) j);
                    _isuService.AddGroup(groups[i, j]);
                }
            }

            var rand = new Random();
            for (int i = 0; i < 100; i++)
                _isuService.AddStudent(_isuService.FindGroup(groups[rand.Next(1, 5), rand.Next(1, 5)]), "Student" + i.ToString());

            _isuService.AddStudent(_isuService.FindGroup(groups[2, 1]), "Ruslan Khakimov");
        }

        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Assert.IsNotNull(_isuService.FindGroup(new GroupName(CourseNumber.Second, 1)).FindStudent("Ruslan Khakimov"));
            
            Assert.AreEqual(_isuService.FindStudent("Ruslan Khakimov").GetGroupName(), new GroupName("M3201"));
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group group = _isuService.FindGroup(new GroupName("M3201"));
            int count = 100;
            while (group.GetSize() < Group.GetMaxStudentPerGroup())
                group.AddStudent(new Student("Student" + (count++).ToString(), group.GetGroupName()));
            Assert.Catch<IsuException>(() =>
            {
                group.AddStudent(new Student("Student" + count.ToString(), group.GetGroupName()));
            });
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            Assert.Catch<IsuException>(() =>
            {
                var groupM32245 = new Group(new GroupName("M32245"));
                var groupM3000 = new Group(new GroupName("M3000"));
            });
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Student me = _isuService.FindStudent("Ruslan Khakimov");
            Group myNewGroup = _isuService.FindGroup(new GroupName("M3202"));
            _isuService.ChangeStudentGroup(me, myNewGroup);
            Assert.AreEqual(me.GetGroupName(), myNewGroup.GetGroupName());
        }
    }
}