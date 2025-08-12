# C# LINQ & Query Writing: A Guide 📊

Welcome to this course on LINQ, which stands for Language-Integrated Query. LINQ is one of the most powerful features in C#, providing a uniform and readable syntax for querying data from a wide variety of sources, including collections, databases, XML documents, and more.

Instead of writing a different query language for each data source, you can use a single, consistent syntax that feels like a natural part of the C# language. This makes your code more concise, maintainable, and less prone to errors.

**1. The Core Concept of LINQ**

At its heart, LINQ is about querying data sources that implement the `IEnumerable<T>` interface, which includes most C# collections like `List<T>`, arrays, and `Dictionary<TKey, TValue>`.

LINQ provides two primary ways to write queries:

* Query Syntax: This looks a lot like a SQL query and is often more readable for simple, straightforward queries.

* Method Syntax: This uses extension methods on `IEnumerable<T>` and is more flexible and powerful for complex queries.

Most important, the compiler translates both syntaxes into the same underlying code, so you can often use whichever you prefer!

**2. Common LINQ Operators and Examples**

Let's dive into the most common LINQ operators with practical examples using a list of students.We'll use a Student class for our examples:

```C#
public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public double Gpa { get; set; }
}
```

Now, let's create a list of students to query:List<Student> students = new List<Student>

```C#
{
    new Student { FirstName = "Alice", LastName = "Smith", Age = 20, Gpa = 3.8 },
    new Student { FirstName = "Bob", LastName = "Johnson", Age = 22, Gpa = 3.1 },
    new Student { FirstName = "Charlie", LastName = "Brown", Age = 20, Gpa = 3.5 },
    new Student { FirstName = "Diana", LastName = "Miller", Age = 21, Gpa = 4.0 },
    new Student { FirstName = "Ethan", LastName = "Davis", Age = 22, Gpa = 2.9 }
};
```

Where: Filtering Data

The Where clause is used to filter elements based on a condition.

Query Syntax:

```C#
var studentsOver20 = from s in students
                    where s.Age > 20
                    select s;
```

Method Syntax:

```C#
var studentsOver20 = students.Where(s => s.Age > 20);
```

Select: Projecting Data

The Select clause transforms each element into a new form. This is useful for creating a new collection with only a subset of the original data or a completely different type.

Query Syntax:

```C#
var studentFullNames = from s in students
                       select $"{s.FirstName} {s.LastName}";
```

Method Syntax:

```C#
var studentFullNames = students.Select(s => $"{s.FirstName} {s.LastName}");
```

OrderBy / OrderByDescending: Sorting Data

These operators sort the elements in ascending or descending order.

Query Syntax:

```C#
var sortedByGpa = from s in students
                  orderby s.Gpa descending
                  select s;
```

Method Syntax:

```
var sortedByGpa = students.OrderByDescending(s => s.Gpa);
```

Aggregation Operators

LINQ also includes methods for performing calculations on the data, such as Count, Sum, Average, Min, and Max.

Method Syntax:

```C#
int numberOfStudents = students.Count();
double averageGpa = students.Average(s => s.Gpa);
double highestGpa = students.Max(s => s.Gpa);
```

**3. Practical Exercise: Combining Queries**

Now it's your turn to combine these operators to answer more complex questions about the student data.

1. Filter: Write a LINQ query to find all students who are 21 years old or younger and have a GPA higher than 3.0.

2. Sort: Sort the results of your filter in alphabetical order by last name.

3. Project: From the sorted results, create a new collection of strings that includes only the full name and GPA of each student (e.g., "Alice Smith - 3.8").

4. Aggregate: Calculate and print the number of students who meet these criteria.

C# Code Snippet for the Exercise

```C#
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQCourseGuide;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { FirstName = "Alice", LastName = "Smith", Age = 20, Gpa = 3.8 },
            new Student { FirstName = "Bob", LastName = "Johnson", Age = 22, Gpa = 3.1 },
            new Student { FirstName = "Charlie", LastName = "Brown", Age = 20, Gpa = 3.5 },
            new Student { FirstName = "Diana", LastName = "Miller", Age = 21, Gpa = 4.0 },
            new Student { FirstName = "Ethan", LastName = "Davis", Age = 22, Gpa = 2.9 }
        };

        // TODO: Your LINQ query and code goes here!
        // 1. Filter for students <= 21 years old and GPA > 3.0.
        // 2. Sort by last name.
        // 3. Project to a new string format.
        // 4. Count the results.
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public double Gpa { get; set; }
}
```

4. Course Summary and Next Steps

LINQ provides an elegant and consistent way to query data, making your C# code more readable and expressive. By mastering Where, Select, OrderBy, and the aggregation methods, you have a solid foundation for working with data in any C# application.

Next Steps:

* Advanced Operators: Explore more advanced operators like GroupBy, Join, and Take/Skip.

* LINQ to XML: Learn how to use LINQ to read, create, and manipulate XML data.

* Entity Framework Core: Discover how LINQ is used to query databases efficiently through object-relational mapping (ORM).