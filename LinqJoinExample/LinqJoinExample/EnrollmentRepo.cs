using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoinExample
{
    public class EnrollmentRepo
    {
        public static List<StudentCourse> SelectAll()
        {
            return new List<StudentCourse>
            {
                new StudentCourse { StudentId = 1, CourseId = 101 },
                new StudentCourse { StudentId = 1, CourseId = 102 },
                new StudentCourse { StudentId = 1, CourseId = 103 },
                new StudentCourse { StudentId = 2, CourseId = 101 },
                new StudentCourse { StudentId = 3, CourseId = 103 },
                new StudentCourse { StudentId = 4, CourseId = 101 },
                new StudentCourse { StudentId = 4, CourseId = 104 },
                new StudentCourse { StudentId = 1, CourseId = 105 },
                new StudentCourse { StudentId = 2, CourseId = 105 },
                new StudentCourse { StudentId = 3, CourseId = 105 },
                new StudentCourse { StudentId = 4, CourseId = 105 }
            };
        }
    }
}
