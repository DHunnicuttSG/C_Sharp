# C# Classes and Class Libraries: A Course Guide 📚

This course guide will introduce you to two fundamental concepts in C# development: classes and class libraries. Understanding these is essential for writing organized, reusable, and maintainable code. A class is a blueprint for creating objects, while a class library is a container for those classes that you can easily share and reuse across multiple projects.

**1. The Building Block: C# Classes**

In C#, a class is a template or blueprint for creating objects. It defines the structure and behavior of a type of object, specifying what kind of data it can hold and what actions it can perform. The concept of a class is central to Object-Oriented Programming (OOP), providing a way to model real-world entities.

Key Components of a Class: 

* Fields: These are variables that hold the class's state. They are the data members of the class. By convention, fields are usually declared as private to ensure encapsulation, meaning the internal state of an object is hidden from the outside world.

* Properties: Properties are the preferred way to expose data from a class. They provide a controlled way to read and write private fields. A property can have a get accessor (to read the value) and a set accessor (to write the value). Properties can also be "auto-implemented," where the compiler automatically creates a hidden private field for you.

* Constructors: Constructors are special methods that are automatically called when an object of the class is created using the new keyword. A class can have multiple constructors with different parameters, allowing you to create objects in various ways.

    * A default constructor has no parameters and is used to create an object with default values.
    
    * A parameterized constructor takes arguments to initialize the object's properties or fields upon creation.
    
* Methods: Methods are functions that define the class's behavior. They perform actions or computations, and they can access and modify the class's fields and properties.

* Access Modifiers: Keywords like public and private are used to control the visibility and accessibility of a class's members.

    * public: Accessible from anywhere.

    * private: Accessible only within the class itself.

**Example: A More Robust Book Class**

Let's refine our Book class to demonstrate these concepts more thoroughly, including a private field and multiple constructors.

```C#
namespace MyLibrary;

public class Book
{
    // A private field to hold the publication year.
    // We use a private field for better control and validation.
    private int _publicationYear;

    // Public auto-implemented properties for Title and Author.
    // The compiler handles the hidden backing field for these.
    public string Title { get; set; }
    public string Author { get; set; }

    // A public property with a private set accessor.
    // The value can be read from anywhere, but only the class itself can change it.
    public int Id { get; private set; }

    // A public property with custom logic in the accessors.
    // This allows for validation when setting the value.
    public int PublicationYear
    {
        get { return _publicationYear; }
        set
        {
            if (value > 0 && value <= DateTime.Now.Year)
            {
                _publicationYear = value;
            }
            else
            {
                // We could throw an exception here or just set a default value.
                Console.WriteLine("Warning: Invalid publication year provided.");
                _publicationYear = DateTime.Now.Year;
            }
        }
    }

    // A parameterized constructor to initialize a new Book object.
    // This is the primary way to create a Book.
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        PublicationYear = year;
        // The Id is set by the class itself, not by the caller.
        this.Id = GenerateUniqueId();
    }

    // A default constructor that calls the parameterized one.
    // This is useful for creating an empty Book object.
    public Book() : this("Untitled", "Unknown Author", DateTime.Now.Year)
    {
        // This constructor just calls the other one with default values.
    }

    // A private helper method to generate a unique ID.
    private int GenerateUniqueId()
    {
        // For this example, we'll just use a random number.
        // In a real application, this would come from a database or a service.
        return new Random().Next(1000, 9999);
    }

    // A public method to display information about the book.
    public void DisplayInfo()
    {
        Console.WriteLine($"Book ID: {Id}");
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Published: {PublicationYear}");
    }
}
```

**2. Packaging for Reuse: Class Libraries**

A class library is a project type in Visual Studio that produces a .dll (Dynamic Link Library) file. This DLL contains one or more classes, interfaces, and other types that can be referenced and used by other projects. Class libraries are the foundation of modular, reusable code in .NET.

Namespaces: Organizing Your Code

Every class is contained within a namespace. A namespace is a way to organize and group related code, preventing naming conflicts. When you reference a class library, you need to use the using keyword in your consuming project to bring the namespace into scope. This is what allows BookApp to "see" the Book class from the MyBookLibrary namespace.

For example, using MyBookLibrary; allows you to refer to the Book class directly as Book instead of its fully qualified name, MyBookLibrary.Book.

**3. Practical Exercises: Building and Using a Library**

Let's go through the steps of creating a solution with a class library and a console application that uses it.

Exercise 1: Create the Solution and Projects

1. In Visual Studio, create a new solution.

2. Add a new project to the solution and select "Class Library" from the templates. Name it MyBookLibrary.

3. Add another new project to the same solution and select "Console App". Name it BookApp.

Your solution should now contain two projects.

Exercise 2: Define a Class in the Library

1. In the MyBookLibrary project, you'll see a default Class1.cs file. Rename this file to Book.cs.

2. Replace the contents of Book.cs with the more robust Book class example provided in Section 1.

Exercise 3: Add a Project Reference

Before you can use the Book class in your console application, you need to tell the console app about the class library.

1. In the Solution Explorer, right-click on the BookApp project's "Dependencies" node.

2. Select "Add Project Reference...".

3. In the dialog box, check the box next to MyBookLibrary and click "OK".

The BookApp project now has access to all the public classes in MyBookLibrary.

Exercise 4: Use the Class from the Library

1. Open the Program.cs file in your BookApp project.

2. Replace the default code with the following. This code will create instances of the Book class using both constructors and call its methods.

```C#
using System;
using MyBookLibrary; // This using directive is now possible because of the project reference

namespace BookApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Book Application!");
        
        // --- CREATE an instance of the Book class using the parameterized constructor ---
        Console.WriteLine("Creating a book using the parameterized constructor:");
        Book myBook = new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", 1979);
        myBook.DisplayInfo();
        Console.WriteLine("---------------------");

        // --- CREATE an instance of the Book class using the default constructor ---
        Console.WriteLine("Creating a book using the default constructor:");
        Book anotherBook = new Book();
        anotherBook.DisplayInfo();
        Console.WriteLine("---------------------");

        // --- USE the custom property logic ---
        Console.WriteLine("Attempting to set an invalid publication year:");
        myBook.PublicationYear = 1200; // This will trigger the validation logic
        myBook.DisplayInfo();
        Console.WriteLine("---------------------");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
```

4. Course Summary and Next Steps

This updated guide has provided an understanding of C# classes, focusing on encapsulation with private fields and public properties, and the flexibility of using multiple constructors. You've also seen how class libraries and namespaces work together to create modular and reusable code.

Next Steps:

* Inheritance: Explore how classes can inherit properties and methods from other classes.

* Interfaces: Learn about interfaces, which define a contract that classes must follow.

* Abstract Classes: Understand the concept of abstract classes, which cannot be instantiated directly but can be inherited from.

* NuGet: Package your class library into a NuGet package to share it with a wider audience.