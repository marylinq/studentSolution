using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using studentCore;

namespace studentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateNewStudent_Test()
        {
            StudentManagement management = new StudentManagement();
            management.Students = new System.Collections.Generic.List<Student>();
            management.Students.Add(new Student() { Name = "student test", Gender = Gender.M, StudenType = new StudentType() { Description = "Kinder" }, LastUpdate = DateTime.Now });
            management.CreateNewStudent("Kinder", "Mary", Gender.F);
            var totalStudents = management.Students.FindAll(x => x.Name.Equals("Mary"));
            Assert.IsTrue(totalStudents.Count >= 1);
        }

        [TestMethod]
        public void DeleteStudent_Test()
        {
            StudentManagement management = new StudentManagement();
            management.Students = new System.Collections.Generic.List<Student>();
            management.Students.Add(new Student() { Name = "student test", Gender = Gender.M, StudenType = new StudentType() { Description = "Kinder" }, LastUpdate = DateTime.Now });
            management.DeleteStudent("student test");
            var totalStudents = management.Students.FindAll(x => x.Name.Equals("student test"));
            Assert.IsTrue(totalStudents.Count == 0);
        }

        [TestMethod]
        public void SearchByName_Test()
        {
            StudentManagement management = new StudentManagement();
            management.Students = new System.Collections.Generic.List<Student>();
            management.Students.Add(new Student() { Name = "student test", Gender = Gender.M, StudenType = new StudentType() { Description = "Kinder" }, LastUpdate = DateTime.Now });
            var studentsFinded = management.SearchByName("student test");
            Assert.IsTrue(studentsFinded.Count == 1);
        }

        [TestMethod]
        public void SearchByStudentType_Test()
        {
            StudentManagement management = new StudentManagement();
            management.Students = new System.Collections.Generic.List<Student>();
            management.Students.Add(new Student() { Name = "student test", Gender = Gender.M, StudenType = new StudentType() { Description = "Kinder" }, LastUpdate = DateTime.Now });
            var studentsFinded = management.SearchByStudentType("Kinder");
            Assert.IsTrue(studentsFinded.Count == 1);
        }

        [TestMethod]
        public void SearchByGenderAndType_Test()
        {
            StudentManagement management = new StudentManagement();
            management.Students = new System.Collections.Generic.List<Student>();
            management.Students.Add(new Student() { Name = "student test", Gender = Gender.M, StudenType = new StudentType() { Description = "Kinder" }, LastUpdate = DateTime.Now });
            var studentsFinded = management.SearchByGenderAndType("M", "Kinder");
            Assert.IsTrue(studentsFinded.Count == 1);
        }

    }
}
