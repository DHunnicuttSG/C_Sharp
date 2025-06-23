using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoinExample
{
    public class StudentRepo
    {
        public static List<Student> SelectAll()
        {
            return new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Alice" },
                new Student { StudentId = 2, StudentName = "Bob" },
                new Student { StudentId = 3, StudentName = "Charlie" },
                new Student { StudentId = 4, StudentName = "Diana" },
                new Student { StudentId = 5, StudentName = "Patrice" }
            };
        }
    }
}
