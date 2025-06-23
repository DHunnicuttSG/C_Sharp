using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoinExample
{
    public class CourseRepo
    {
        public static List<Course> SelectAll()
        {
            return new List<Course>
            {
                new Course { CourseId = 101, CourseName = "Math 101" },
                new Course { CourseId = 102, CourseName = "Physics 201" },
                new Course { CourseId = 103, CourseName = "Chemistry 101" },
                new Course { CourseId = 104, CourseName = "History 301" },
                new Course { CourseId = 105, CourseName = "Comp. Sci. 201" },
                new Course { CourseId = 106, CourseName = "English 101" }
            };
        }
    }
}
