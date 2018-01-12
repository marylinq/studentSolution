using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentCore
{
    public class Student
    {
        public StudentType StudenType { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public enum Gender {F, M};
}
