using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqJoinExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = StudentRepo.SelectAll();

            List<Course> courses = CourseRepo.SelectAll();

            List<StudentCourse> enrollments = EnrollmentRepo.SelectAll();

            GetStudentCourseData(students, enrollments, courses);
            Console.WriteLine("\n");
            
            GetAllStudentsWithCourses(students, enrollments, courses);
            Console.WriteLine("\n");
            
            GetCoursesWithStudents(students, enrollments, courses);
            Console.WriteLine("\n");
            
            FilterByStudentId(students, enrollments, courses);
            Console.WriteLine("\n");

            GroupStudentsByClass(students, enrollments, courses);
            Console.WriteLine("\n");

        } //end of main
    

        public static void GetStudentCourseData(List<Student> students, List<StudentCourse> enrollments, List<Course> courses)
        {
            // Create a linq query that joins all the lists and prints out data
            var StudentCourseData = from s in students
                                    join sc in enrollments on s.StudentId equals sc.StudentId
                                    join c in courses on sc.CourseId equals c.CourseId
                                    select new
                                    {
                                        s.StudentId,
                                        s.StudentName,
                                        c.CourseName
                                    };

            Console.WriteLine("{0, -10} {1, -10} {2}", "Id", "Name", "Course Name");

            foreach (var row in StudentCourseData)
            {
                Console.WriteLine("{0, -10} {1, -10} {2}", row.StudentId, row.StudentName, row.CourseName);
            }
            
        }
        public static void GetAllStudentsWithCourses(List<Student> students, List<StudentCourse> enrollments, List<Course> courses)
        {
            // Create a left join from students
            var AllStudentsAndCourses = from s in students
                                        join sc in enrollments on s.StudentId equals sc.StudentId into studentEnrollments
                                        from se in studentEnrollments.DefaultIfEmpty()
                                        join c in courses on (se == null ? 0 : se.CourseId) equals c.CourseId into CourseDetails
                                        from cd in CourseDetails.DefaultIfEmpty()
                                        select new
                                        {
                                            s.StudentId,
                                            s.StudentName,
                                            CourseName = cd?.CourseName ?? "No Courses",
                                        };

            Console.WriteLine("{0, -10} {1, -10} {2}", "Id", "Name", "Course Name");

            foreach (var row in AllStudentsAndCourses)
            {
                Console.WriteLine("{0, -10} {1, -10} {2}", row.StudentId, row.StudentName, row.CourseName);
            }
            
        }

        public static void GetCoursesWithStudents(List<Student> students, List<StudentCourse> enrollments, List<Course> courses)
        {
            //Create a left join from Students = same type of query just different list order
            var CoursesWithStudents = from c in courses
                                      join sc in enrollments on c.CourseId equals sc.CourseId into courseEnrollments
                                      from ce in courseEnrollments.DefaultIfEmpty()
                                      join s in students on (ce == null ? 0 : ce.StudentId) equals s.StudentId into studentDetails
                                      from sd in studentDetails.DefaultIfEmpty()
                                      select new
                                      {
                                          c.CourseId,
                                          c.CourseName,
                                          StudentName = sd?.StudentName ?? "No Students"
                                      };

            Console.WriteLine("{0, -10} {1, -20} {2}", "Id", "Name", "Course Name");
            foreach (var row in CoursesWithStudents)
            {
                Console.WriteLine("{0, -10} {1, -20} {2}", row.CourseId, row.CourseName, row.StudentName);
            }
        }

        public static void FilterByStudentId(List<Student> students, List<StudentCourse> enrollments, List<Course> courses)
        {
            var CoursesByStudentId = from s in students
                                     join sc in enrollments on s.StudentId equals sc.StudentId
                                     join c in courses on sc.CourseId equals c.CourseId
                                     where s.StudentName == "Alice" 
                                     //orderby c.CourseName descending
                                     select new
                                     {
                                         s.StudentId,
                                         s.StudentName,
                                         c.CourseName
                                     };
            Console.WriteLine("{0, -10} {1, -20} {2}", "Id", "Name", "Course Name");
            foreach (var row in CoursesByStudentId)
            {
                Console.WriteLine("{0, -10} {1, -20} {2}", row.StudentId, row.StudentName, row.CourseName);
            }
        }

        public static void GroupStudentsByClass(List<Student> students, List<StudentCourse> enrollments, List<Course> courses)
        {
            var GroupByClass = from s in students
                               join sc in enrollments on s.StudentId equals sc.StudentId
                               join c in courses on sc.CourseId equals c.CourseId
                               orderby c.CourseName, s.StudentName
                               group s by c.CourseName;
                                     
            //Console.WriteLine("{0, -10} {1, -20} {2}", "Id", "Name", "Course Name");
            foreach (var group in GroupByClass)
            {
                Console.WriteLine(group.Key);
                foreach (var student in group)
                {
                    Console.WriteLine("\t{0}", student.StudentName);
                }
            }
        }

    } // end of Program class


    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
