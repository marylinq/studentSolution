using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentCore
{
    public class StudentManagement
    {
        public List<Student> Students { get; set; }

        public StudentManagement()
        {
            Students = new List<Student>();
        }

        public void LoadStudentsFromCSV(string source)
        {
            using (var rd = new StreamReader(source))
            {
                while (!rd.EndOfStream)
                {
                    var item = rd.ReadLine().Split(';');
                    Student newStudent = new Student();
                    newStudent.StudenType = new StudentType() { Description = item[0] };
                    newStudent.Name = item[1];
                    newStudent.Gender = (Gender)Enum.Parse(typeof(Gender), item[2]);
                    newStudent.LastUpdate = Convert.ToDateTime(TimeStampToDateTime(item[3]));
                    Students.Add(newStudent);
                }
            }
        }
        public DateTime TimeStampToDateTime(string timeStamp)
        {
            return DateTime.ParseExact(timeStamp,
                                        "yyyyMMddHHmmss",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None);
        }

        public List<Student> SearchByName(string name)
        {
            return Students.Where(x => x.Name.ToLower().Contains(name.ToLower())).OrderByDescending(x => x.Name).ToList();
        }

        public List<Student> SearchByStudentType(string type)
        {
            return Students.Where(x => x.StudenType.Description.ToLower().Equals(type.ToLower())).OrderByDescending(x => x.LastUpdate).ToList();
        }

        public List<Student> SearchByGenderAndType(string gender, string type)
        {
            Gender g = (Gender)Enum.Parse(typeof(Gender), gender);
            return Students.Where(x => x.StudenType.Description.ToLower().Equals(type.ToLower()) && x.Gender==g).OrderByDescending(x => x.LastUpdate).ToList();
        }

        public void CreateNewStudent(string type, string name, Gender gender)
        {
            Student newStudent = new Student();
            newStudent.StudenType = new StudentType() { Description = type };
            newStudent.Name = name;
            newStudent.Gender =  gender;
            newStudent.LastUpdate = DateTime.Now;
            Students.Add(newStudent);
        }

        public void DeleteStudent(string name)
        {
            Students.RemoveAll(x => x.Name.ToLower().Equals(name.ToLower()));
        }

    }
}
