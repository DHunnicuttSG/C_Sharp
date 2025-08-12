# C# System.IO: A Guide 📁

Welcome to this course on the System.IO namespace, the backbone of file and directory operations in C#. The ability to read from and write to files is a fundamental skill for any developer, as it allows your applications to persist data and interact with the user's file system.

This guide will introduce you to the core classes for handling files and directories, demonstrate how to read and write text files, and provide a hands-on exercise to solidify your understanding.

**1. Core Classes in System.IO**

The System.IO namespace contains a collection of classes designed for various input/output tasks. For working with files and directories, you'll primarily use these static classes and streams:

* File: A static class that provides methods for creating, copying, deleting, moving, and opening files. It's great for quick, one-off file operations.

* Directory: A static class for working with directories (folders). It lets you create, delete, and move directories, as well as enumerate files and subdirectories.

* Path: A static class that provides methods for performing operations on path information, such as combining paths, getting file extensions, or extracting a filename.

* StreamReader: A class that reads characters from a byte stream, making it ideal for reading text files. It handles character encoding for you.

* StreamWriter: A class that writes characters to a stream, making it ideal for writing text files.

**2. Reading and Writing Text Files**

Reading and writing text files are common tasks. The StreamReader and StreamWriter classes are the preferred tools for this, as they handle the complexities of streams and character encoding.

Writing to a File

The best practice for file operations is to use a using statement. This ensures that the file handle is properly closed and the resources are released, even if an error occurs.

```C#
using System;
using System.IO;

public static void WriteToFile(string filePath, string content)
{
    // The 'using' statement ensures the StreamWriter is properly disposed of.
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        writer.WriteLine(content);
        writer.WriteLine("This is the second line.");
    }
    Console.WriteLine($"Successfully wrote to file: {filePath}");
}
```

Reading from a File

Reading a file is just as simple with a StreamReader. You can read the file line by line or read the entire content into a single string.

```C#
using System;
using System.IO;

public static void ReadFromFile(string filePath)
{
    // The 'using' statement ensures the StreamReader is properly disposed of.
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        // Read the file line by line until the end of the stream.
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
}
```


**3. Directory Operations**

The Directory class provides everything you need to manage folders.

Creating and Deleting Directories

```C#
using System;
using System.IO;

public static void ManageDirectory(string path)
{
    // Create a new directory if it doesn't already exist.
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
        Console.WriteLine($"Created directory: {path}");
    }
    else
    {
        Console.WriteLine($"Directory already exists: {path}");
    }

    // You can also delete a directory.
    // Be careful! The 'true' parameter means it will delete all subdirectories and files.
    // Directory.Delete(path, true); 
}
```

Listing Files

```C#
using System;
using System.IO;

public static void ListFiles(string path)
{
    // Check if the directory exists first.
    if (Directory.Exists(path))
    {
        Console.WriteLine($"\nFiles in {path}:");
        // Get all file names in the specified directory.
        string[] files = Directory.GetFiles(path);

        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }
}
```

**4. Practical Exercise: Log File Manager**

Let's combine what you've learned into a practical exercise. You'll simulate a simple log file manager that reads a list of events, formats them, and writes them to a new log file in a dedicated Logs directory.

Your Task:

1. Create a Main method in a console application.
2. Create a text file named events.txt in your project folder with some lines of text (e.g., "User logged in", "Database connection failed").
3. In your Main method, read all lines from events.txt into a string[] or `List<string>`.
4. Create a new directory named Logs in your project folder. Use Path.Combine to construct the directory path to make it platform-independent.
5. Create a new file path for a log file inside the Logs directory. Name it something like app_log_YYYYMMDD.txt.
6. Write each line from events.txt to the new log file, but prefix each line with the current date and time. Use a StreamWriter for this.
7. Finally, list all files in the newly created Logs directory to confirm your new log file exists.

5. Course Summary and Next Steps

You've successfully learned the basics of file and directory management in C# using the System.IO namespace. You now have the tools to:
* Read from and write to text files.
* Create, manage, and inspect directories.
* Work with file and directory paths safely.

Next Steps:

* Asynchronous I/O: For performance-critical applications, explore asynchronous methods like File.WriteAllTextAsync() to prevent your application from freezing while waiting for a file to be read or written.
* Binary I/O: Learn how to use classes like FileStream and BinaryReader/BinaryWriter to read and write raw byte data, which is necessary for working with non-text files like images or executables.
* Exception Handling: Practice robust error handling with try...catch blocks to gracefully handle potential issues like a file not being found or a permission denied error.