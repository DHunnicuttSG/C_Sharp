# C# Strings and Common Members: A Comprehensive Guide

Welcome to this guide on the C# string type! In C#, the string type is used to represent a sequence of characters. It is one of the most fundamental data types and is essential for working with any kind of text, from user input to file content.

This guide will cover the core concepts of the string type, including its immutability and many of the built-in members (properties and methods) that make text manipulation simple and powerful. We'll also provide practical exercises to help you master these concepts.

Let's begin!

1. The string Type and Immutability

In C#, a string is a reference type, but it behaves differently than most other reference types because it is immutable. This means that once a string object is created, its value cannot be changed. Any operation that appears to modify a string, such as converting it to uppercase, actually creates a new string object in memory with the new value. The original string remains unchanged.

C# Implementation Example

```C#
string originalString = "hello world";

// This method returns a new string in uppercase.
// The originalString variable is not changed.
string upperCaseString = originalString.ToUpper();

Console.WriteLine($"Original: {originalString}"); // Output: Original: hello world
Console.WriteLine($"New: {upperCaseString}");     // Output: New: HELLO WORLD

// This is an assignment, which replaces the reference to the original string
// with a reference to the new string.
originalString = originalString.Replace("world", "C#");

Console.WriteLine($"Modified variable: {originalString}"); // Output: Modified variable: hello C#
```

2. Common String Properties and Methods
The string type comes with a rich set of built-in properties and methods for manipulating text.

**Properties**
* Length: A property that returns the number of characters in the string.

**Modification Methods**
These methods return a new string with the modified content.

* ToUpper(): Returns a copy of the string converted to uppercase.
* ToLower(): Returns a copy of the string converted to lowercase.
* Trim(): Returns a new string with all leading and trailing whitespace characters removed.
* Substring(int startIndex): Returns a new string that is a substring from a specified start index to the end.
* Substring(int startIndex, int length): Returns a new string that is a substring of a specified length from a specified start index.
* Replace(string oldValue, string newValue): Returns a new string in which all occurrences of oldValue are replaced with newValue.

C# Implementation Example

```C#
string sentence = "   Hello, C# world!   ";
Console.WriteLine($"Original: '{sentence}'");

// Using various modification methods
string trimmed = sentence.Trim();
Console.WriteLine($"Trimmed: '{trimmed}'");

string uppercase = trimmed.ToUpper();
Console.WriteLine($"Uppercase: '{uppercase}'");

string sub = trimmed.Substring(7, 2); // Get "C#" from "Hello, C# world!"
Console.WriteLine($"Substring: '{sub}'");

string replaced = trimmed.Replace("C#", "C-Sharp");
Console.WriteLine($"Replaced: '{replaced}'");
```

**Search and Information Methods**
These methods return a bool or an int based on a search.

* Contains(string value): Returns true if the string contains the specified substring.
* StartsWith(string value): Returns true if the string starts with the specified substring.
* EndsWith(string value): Returns true if the string ends with the specified substring.
* IndexOf(string value): Returns the zero-based index of the first occurrence of the specified substring. Returns -1 if the substring is not found.

C# Implementation Example

```C#
string path = "C:\\Users\\Guest\\Documents\\report.txt";

// Using various search and information methods
Console.WriteLine($"Does the path contain 'Documents'? {path.Contains("Documents")}");
Console.WriteLine($"Does the path start with 'C:'? {path.StartsWith("C:")}");
Console.WriteLine($"Does the path end with '.txt'? {path.EndsWith(".txt")}");

int lastSlashIndex = path.LastIndexOf('\\'); // Using LastIndexOf for a specific use case
if (lastSlashIndex != -1)
{
    string fileName = path.Substring(lastSlashIndex + 1);
    Console.WriteLine($"The filename is: {fileName}");
}
```

3. Exercises
Try these exercises to test your understanding of string methods.

Exercise 1: User Input and Manipulation

Write a program that prompts the user for their full name. Then, perform the following actions and print the results:

* Print the length of their name.
* Print their name in all uppercase.
* Print their initials by finding the first letter of the first name and the first letter after the first space.

```C#
// Your code here...
Console.Write("Please enter your full name: ");
string fullName = Console.ReadLine();

// 1. Print the length
// 2. Print the name in uppercase
// 3. Print the initials
```

Exercise 2: Email Validation

Write a method that takes an email address (string) as an argument and returns true if it appears to be valid, and false otherwise. A simple validation check is to ensure the string contains an "@" symbol and a "." (dot). Use the Contains() method.

```C#
// Your code here...
public bool IsValidEmail(string email)
{
    // Check if the email contains '@' and '.'
    // ...
}

// Call your method with some test emails
string testEmail1 = "test@example.com";
string testEmail2 = "invalid-email";
```

Exercise 3: Simple URL Parser
Write a program that takes a URL as a string. Check if the URL starts with "https://" and ends with ".com". If both conditions are true, print "Valid URL." Otherwise, print "Invalid URL."

```C#
// Your code here...
string url = "https://www.google.com";

// Use StartsWith() and EndsWith() to check the URL
```

## Conclusion

The string type is the foundation for all text processing in C#. By understanding its immutable nature and leveraging its extensive set of built-in members, you can efficiently manipulate, search, and format text to meet the needs of any application. The exercises provided here will give you a solid foundation for working with strings in your own projects.