<!-- create some C# content for a class on the topic of C# data types, include exercises and real world project examples. Output the file into markdown language. -->

## C# Data Types: A Comprehensive Guide
Welcome to this comprehensive guide on C# Data Types! In C#, a data type specifies the kind of data a variable can hold, such as an integer, a floating-point number, a character, or a string. Understanding data types is the first and most crucial step in programming, as they determine what operations can be performed on the data and how it is stored in memory.

This guide will cover the two main categories of data types: Value Types and Reference Types. We'll provide detailed explanations, C# code examples, practical exercises, and real-world project examples to help you solidify your understanding.

Let's get started!

1. Value Types

Value types directly store their data within their own memory space. They are typically allocated on the stack. When you assign a value type variable to another, a new copy of the data is created.

**Common Value Types:**

* int: A 32-bit signed integer. Used for whole numbers.
    * Example: int age = 30;

* double: A 64-bit floating-point number. Used for storing numbers with decimal points.
    * Example: double price = 19.99;
* char: A single 16-bit Unicode character. Enclosed in single quotes.
    * Example: char initial = 'A';
* bool: A boolean value that can be either true or false.
    * Example: bool isStudent = true;
* decimal: A 128-bit data type with higher precision and a smaller range than double, making it suitable for financial and monetary calculations.
    * Example: decimal salary = 50000.50m;

**C# Implementation Example**

```C#
// Declaring and initializing value types
int score = 100;
double temperature = 98.6;
char grade = 'A';
bool hasPassed = true;
decimal bankBalance = 12500.75m; // 'm' suffix indicates a decimal literal

// Printing the values
Console.WriteLine($"Score: {score}");
Console.WriteLine($"Temperature: {temperature}°F");
Console.WriteLine($"Grade: {grade}");
Console.WriteLine($"Passed: {hasPassed}");
Console.WriteLine($"Bank Balance: ${bankBalance}");

// Demonstrating a copy of a value type
int x = 5;
int y = x; // A new copy of 5 is created in memory for 'y'
y = 10;
Console.WriteLine($"x is now: {x}"); // Output: x is now: 5
Console.WriteLine($"y is now: {y}"); // Output: y is now: 10
```

Exercise 1: Simple Calculator
Write a C# program that prompts the user for two numbers and an operator (+, -, *, /). The program should use double for the numbers and char for the operator, then perform the calculation and print the result.

2. Reference Types

Reference types store a reference (or memory address) to their data, which is typically stored on the heap. When you assign a reference type variable to another, both variables point to the same location in memory. Changes made through one variable will be visible through the other.

Common Reference Types:

* string: A sequence of characters. string is a reference type, but it behaves like a value type in many ways due to its immutability. Enclosed in double quotes.
    * Example: string name = "John Doe";
* object: The ultimate base class for all C# types. You can assign a value of any type to a variable of type object. This is a powerful but less common practice in modern C#.
    * Example: object myObject = 123;
* Classes: Custom types that you define yourself. All class instances are reference types.
    * Example: MyClass myInstance = new MyClass();

C# Implementation Example

```C#
// Declaring and initializing a string
string greeting = "Hello, world!";
Console.WriteLine(greeting);

// Demonstrating a reference type
string a = "Hello";
string b = a; // 'b' now refers to the same memory location as 'a'
Console.WriteLine($"Before change, a: {a}, b: {b}");

// Strings are immutable, so this creates a new string object for 'b'
b = "Goodbye";
Console.WriteLine($"After change, a: {a}, b: {b}"); // Output: a: Hello, b: Goodbye

// Demonstrating a custom class as a reference type
public class Person
{
    public string Name { get; set; }
}

Person person1 = new Person { Name = "Alice" };
Person person2 = person1; // 'person2' now refers to the SAME object in memory as 'person1'
Console.WriteLine($"Before change, person1 name: {person1.Name}, person2 name: {person2.Name}");

person2.Name = "Bob"; // We changed the object through 'person2'
Console.WriteLine($"After change, person1 name: {person1.Name}, person2 name: {person2.Name}"); // Output: both names are "Bob"
```

Exercise 2: String Manipulator

Write a C# method that takes a string as input and performs the following operations:

* Converts the string to uppercase.
* Checks if the string contains the word "Csharp" (case-insensitive).
* Replaces all spaces with hyphens.
* Prints the modified string and the result of the check.

3. Real-World Project Examples

**Project 1: User Profile Management System**

Create a simple console application for managing user profiles.

Data Types Used:
* string for UserName, Email, and FullName.
* int for UserId and Age.
* bool for IsActive.
* Custom Class: A User class to encapsulate all these properties.

Example Features:
* Add a new user by prompting for user details.
* Display a user's profile.
* Update a user's email.
* List all active users.

**Project 2: Inventory Tracking System**

Build a basic inventory system for a small store.

Data Types Used:
* string for ItemName and ItemSKU.
* int for QuantityInStock.
* decimal for UnitPrice.
Custom Class: An InventoryItem class to represent each product.

Example Features:
* Add a new item to the inventory.
* Update the stock quantity for an item.
* Calculate the total value of all items in stock.
* Find items that are low in stock (e.g., quantity < 10).

**Project 3: Simple Quiz Application**

Develop a console-based multiple-choice quiz.

Data Types Used:

* string for the QuestionText, CorrectAnswer, and PossibleAnswers (using a string[] array)
* int to track the user's Score.bool to check if the user's answer is correct.
* Custom Class: A Question class to hold the question and its related information.

Example Features:
* Load a set of questions.
* Present questions to the user one by one.
* Check the user's answer and update the score.
* Display the final score at the end of the quiz.

### Conclusion

Data types are the building blocks of every C# application. By distinguishing between value types and reference types, and understanding the purpose of each, you can write more efficient, predictable, and bug-free code. The exercises and project examples provided here will give you a solid foundation to build upon as you progress in your C# journey.