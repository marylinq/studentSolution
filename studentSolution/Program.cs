using studentCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManagement management = new StudentManagement();

            if (args[1].ToLower().Contains("name"))
            {
                //name
                management.LoadStudentsFromCSV(args[0]);
                string nameToSearch = args[1].Split('=')[1];
                List<Student> names = management.SearchByName(nameToSearch);
                print(names);
            }

            if (args[1].ToLower().Contains("type") && args.ToList().Count == 2)
            {
                management.LoadStudentsFromCSV(args[0]);
                string typeToSearch = args[1].Split('=')[1];
                List<Student> names = management.SearchByStudentType(typeToSearch);
                print(names);
            }

            if (args.ToList().Count == 3 && args[1].ToLower().Contains("type") && args[2].ToLower().Contains("gender"))
            {
                management.LoadStudentsFromCSV(args[0]);
                string typeToSearch = args[1].Split('=')[1];
                string genderToSearch = args[2].Split('=')[1];
                Console.WriteLine(genderToSearch);
                List<Student> names = management.SearchByGenderAndType(genderToSearch, typeToSearch);
                print(names);
            }

            //management.LoadStudentsFromCSV("input.csv");

            //management.CreateNewStudent("kinder", "Paola Jordan", Gender.M);

            //management.DeleteStudent("Paola Jordan");

            ////var names = management.SearchByName("Jho");

            //var studenTypes = management.SearchByStudentType("kinder");

            //var genderTypes = management.SearchByGenderAndType("F", "Kinder");

        }

        private static void print(List<Student> listStudents)
        {
            foreach (var item in listStudents)
            {
                Console.WriteLine(string.Format("{0},{1},{2},{3}", item.StudenType.Description, item.Name, item.Gender, ShowTimeStamp(item.LastUpdate)));
            }
        }

        private static string ShowTimeStamp(DateTime d)
        {
            return string.Format("{0}{1}{2}{3}{4}{5}", d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }
    }
}
