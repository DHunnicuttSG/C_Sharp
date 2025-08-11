# C# Lists: A Course Guide 📝

Welcome to this course on the List<T> data type! The List<T> is one of the most widely used and versatile collections in C#. It's an essential building block for many applications, providing a flexible way to work with sequences of data.1. What is List<T>?Think of a List<T> as a supercharged array. Like an array, it stores an ordered collection of objects that you can access by an integer index. Unlike a standard array, a List<T> can dynamically grow and shrink as you add or remove elements, so you don't have to worry about managing its size manually.The <T> in the name stands for generic type parameter. This means a List can hold a specific type of data, such as a List<string>, List<int>, or List<Product>. This provides strong type safety, preventing you from accidentally adding an integer to a list of strings.Key Characteristics:Ordered: Elements are stored in the order they are added and can be accessed by their index (e.g., myList[0]).Dynamic Size: You can add or remove elements, and the list will automatically handle the memory management.Allows Duplicates: You can add the same element multiple times to a list.Fast Index-based Access: Accessing an element by its index is an extremely fast O(1) operation.2. Common List<T> MethodsThe List<T> class provides a rich set of methods for working with your data. Here are some of the most common ones you'll use:MethodDescriptionAdd(T item)Adds an item to the end of the list.Remove(T item)Removes the first occurrence of a specific item from the list.RemoveAt(int index)Removes the item at the specified index.CountA property that returns the number of elements in the list.Contains(T item)Returns true if the list contains the specified item, otherwise false.Clear()Removes all elements from the list.ForEach(Action<T> action)Performs the specified action on each element of the list.3. Practical Example: Managing a To-Do ListLet's create a simple console application to see the List<T> in action. We'll build a small to-do list manager that allows us to add, remove, and display tasks.using System;
using System.Collections.Generic;

namespace ListCourseGuide;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- To-Do List Manager ---");

        // Create a new List of strings to hold our tasks.
        List<string> tasks = new List<string>();

        // Add some initial tasks.
        tasks.Add("Buy groceries");
        tasks.Add("Walk the dog");
        tasks.Add("Finish C# course guide");

        Console.WriteLine($"You have {tasks.Count} tasks on your to-do list.");
        Console.WriteLine("Here are your tasks:");

        // Use a for loop to iterate through the list by index.
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"- Task {i + 1}: {tasks[i]}");
        }

        Console.WriteLine("\nMarking 'Walk the dog' as complete...");
        // Use the Remove method to remove a specific item.
        tasks.Remove("Walk the dog");

        Console.WriteLine($"\nYour updated to-do list has {tasks.Count} tasks.");
        
        // Use a foreach loop for a more concise way to iterate.
        Console.WriteLine("Here are your remaining tasks:");
        foreach (string task in tasks)
        {
            Console.WriteLine($"- {task}");
        }

        Console.WriteLine("\nDoes the list contain 'Buy groceries'?");
        // Use the Contains method to check for an item's existence.
        if (tasks.Contains("Buy groceries"))
        {
            Console.WriteLine("Yes, it does!");
        }
        else
        {
            Console.WriteLine("No, it doesn't.");
        }
    }
}
4. Exercise: Building a Simple Shopping CartNow it's your turn! Create a new console application and try to build a simple shopping cart system using a List<T>.Your task:Create a List<string> to represent a shopping cart.Add at least three different items to the cart.Add one duplicate item to demonstrate that a List allows them.Print the total number of items in the cart.Remove a specific item from the cart.Print the final list of items in the cart.5. Course Summary and Next StepsYou've learned that List<T> is a fundamental and flexible collection for managing ordered sequences of data. Its dynamic sizing and fast index-based access make it a powerful tool for a wide range of tasks.Next Steps:Performance: Consider the performance of List<T> when inserting or removing items from the middle, which can be an O(n) operation.Other Collections: Explore other collections like Dictionary<TKey, TValue> and HashSet<T> to see how they are optimized for different use cases.LINQ: Learn how to use LINQ (Language-Integrated Query) to perform powerful and expressive queries on your lists.