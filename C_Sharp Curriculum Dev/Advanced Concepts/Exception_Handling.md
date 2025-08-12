# C# Exception Handling: A Guide 🛡️

Welcome to this course on Exception Handling in C#. In the real world, things don't always go as planned. Files might be missing, network connections can drop, or users might enter invalid data. Exceptions are C#'s way of dealing with these unexpected or exceptional events during a program's execution.

This guide will teach you how to use try, catch, and finally blocks to gracefully handle errors, prevent your application from crashing, and provide a better user experience.

**1. What Are Exceptions?**

An exception is an object that contains information about an error that occurred. When an error happens, an exception is "thrown." If your code doesn't "catch" this exception, the program will terminate. Some common built-in exceptions include:

* FileNotFoundException: Thrown when a file at a specified path cannot be found.
* DivideByZeroException: Thrown when an attempt is made to divide an integer by zero.
* FormatException: Thrown when the format of an argument is invalid.
* IndexOutOfRangeException: Thrown when you try to access an array or list element using an index that is outside its bounds.

**2. The try...catch Block**

The try...catch block is the core of exception handling. You place the code that might throw an exception inside the try block. If an exception is thrown, the program's execution jumps to the catch block, where you can handle the error.

Basic Syntax

```C#
try
{
    // Code that might throw an exception.
    // For example: opening a file that doesn't exist.
}
catch (Exception ex)
{
    // Code to handle the exception.
    // You can log the error, display a message, etc.
    Console.WriteLine($"An error occurred: {ex.Message}");
}
```

Catching Specific Exceptions

It is best practice to catch specific, more granular exceptions rather than a general Exception. This allows you to handle different types of errors in different ways.

```C#
using System;
using System.IO;

public static void FileOperation(string filePath)
{
    try
    {
        string content = File.ReadAllText(filePath);
        Console.WriteLine("File content:\n" + content);
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine("Error: The specified file was not found.");
        // Log the specific file path that was not found.
        Console.WriteLine($"Details: {ex.Message}");
    }
    catch (UnauthorizedAccessException ex)
    {
        Console.WriteLine("Error: You do not have permission to access this file.");
        // Log the security details.
        Console.WriteLine($"Details: {ex.Message}");
    }
    catch (Exception ex)
    {
        // This is a generic catch-all for any other unexpected errors.
        Console.WriteLine("An unexpected error occurred.");
        Console.WriteLine($"Details: {ex.Message}");
    }
}
```

**3. The finally Block**

The finally block is optional, but it's crucial for resource management. Code inside a finally block will always execute, regardless of whether an exception was thrown or not. This is the perfect place to clean up resources, such as closing file streams or database connections.

```C#
using System;
using System.IO;

public static void SafeFileRead(string filePath)
{
    StreamReader reader = null; // Declare outside the try block.
    try
    {
        reader = new StreamReader(filePath);
        string line = reader.ReadLine();
        Console.WriteLine($"First line: {line}");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("File not found.");
    }
    finally
    {
        // This code will always run.
        if (reader != null)
        {
            reader.Close();
            Console.WriteLine("File stream closed successfully.");
        }
    }
}
```

**4. Throwing Your Own Exceptions**

Sometimes you may want to explicitly "throw" an exception to signal an invalid state in your own code. This is useful for validating user input or ensuring a method's contract is met.

```C#
using System;

public class Calculator
{
    public double Divide(double numerator, double denominator)
    {
        if (denominator == 0)
        {
            // Throw a new instance of an exception.
            throw new ArgumentException("Cannot divide by zero.", nameof(denominator));
        }
        return numerator / denominator;
    }
}
```

**5. Practical Exercise: A Robust Calculator**

Now it's your turn to put these concepts into practice. Create a console application that prompts the user for two numbers and a division operation. Your task is to use try...catch and finally blocks to make it robust and handle potential errors.

Your Task:

1. Create a Main method.
2. Use a try...catch block to wrap the entire operation.
3. Inside the try block:
    * Prompt the user to enter a numerator and a denominator.
    * Use int.Parse() to convert the input from strings to integers.
    * Perform the division operation and print the result.
4. Add a catch block for a FormatException to handle cases where the user enters non-numeric input.
5. Add a separate catch block for a DivideByZeroException to handle division by zero.
6. Add a finally block that prints a message like "Calculation complete." to show that the program has finished the operation, regardless of the outcome.

**6. Course Summary and Next Steps**

You've learned that exception handling is a vital part of writing robust, professional C# applications. By using try...catch...finally blocks, you can anticipate and gracefully handle errors, making your code more reliable and user-friendly.

Next Steps:

* Custom Exceptions: Learn how to create your own custom exception classes for specific application errors.

* Exception Filters: Explore how to use when clauses in catch blocks to filter exceptions based on a specific condition.

* Async/Await and Exceptions: Understand how exceptions are propagated in asynchronous methods.