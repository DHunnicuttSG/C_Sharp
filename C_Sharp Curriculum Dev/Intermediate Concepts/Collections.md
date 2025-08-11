# C# Collections: A Guide 📦

Collections are fundamental data structures in C# used to store and manage groups of objects. While a simple array is a fixed-size collection, the .NET framework provides a rich set of specialized collections that offer more flexibility and powerful features. Understanding these collections is crucial for writing efficient and organized code.

This guide will focus on three of the most frequently used generic collections: `List<T>`, `Dictionary<TKey, TValue>`, and `HashSet<T>`.

**1. `List<T>`: The Flexible Array**

A `List<T>` is a dynamic array that can grow or shrink in size. It's the most common collection and a great choice when you need an ordered sequence of elements that you can access by index.

Key Characteristics:

* Ordered: Elements are stored in the order they are added.

* Allows Duplicates: You can add the same element multiple times.

* Index-based Access: You can access elements by their integer index, like an array (myList[0]). This is a very fast O(1) operation.

* Dynamic Size: The list automatically resizes its internal array as you add more items.

Example: A Shopping List

```C#
using System;
using System.Collections.Generic;

namespace CollectionsGuide;

public class ShoppingListExample
{
    public static void Run()
    {
        Console.WriteLine("--- Using List<T> for a Shopping List ---");

        // Create a new List of strings.
        List<string> shoppingList = new List<string>();

        // Add items to the list.
        shoppingList.Add("Milk");
        shoppingList.Add("Bread");
        shoppingList.Add("Eggs");

        // Lists allow duplicates.
        shoppingList.Add("Milk");
        
        Console.WriteLine("My shopping list has " + shoppingList.Count + " items.");

        // Access an item by its index.
        Console.WriteLine("The first item is: " + shoppingList[0]);

        // Remove an item.
        shoppingList.Remove("Bread");
        
        Console.WriteLine("The list after removing bread:");
        foreach (string item in shoppingList)
        {
            Console.WriteLine("- " + item);
        }
    }
}
```

**2. `Dictionary<TKey, TValue>`: The Key-Value Store**

A `Dictionary<TKey, TValue>` is a collection that stores a set of key-value pairs. Each key must be unique, and it maps to a specific value. It is optimized for incredibly fast lookups by key.

Key Characteristics:

* Unordered: The order of elements is not guaranteed.

* Unique Keys: Each key must be unique. If you try to add a key that already exists, it will throw an exception.

* Fast Lookups: Finding, adding, or removing an item by its key is, on average, a very fast O(1) operation.

* Strongly Typed: Both the key and the value have a specific type defined when the dictionary is created.

Example: A User's Profile

```C#
using System;
using System.Collections.Generic;

namespace CollectionsGuide;

public class UserProfileExample
{
    public static void Run()
    {
        Console.WriteLine("\n--- Using Dictionary<TKey, TValue> for a User Profile ---");

        // Create a new Dictionary with string keys and string values.
        Dictionary<string, string> userProfile = new Dictionary<string, string>();

        // Add key-value pairs.
        userProfile.Add("Name", "John Doe");
        userProfile.Add("Email", "john.doe@example.com");
        userProfile.Add("Role", "Admin");

        // Access a value by its key.
        Console.WriteLine("User's email is: " + userProfile["Email"]);

        // Check if a key exists before accessing it to avoid an error.
        if (userProfile.ContainsKey("Role"))
        {
            userProfile["Role"] = "Editor";
        }
        
        Console.WriteLine("User's new role is: " + userProfile["Role"]);

        // Iterate through all key-value pairs.
        Console.WriteLine("All profile details:");
        foreach (KeyValuePair<string, string> entry in userProfile)
        {
            Console.WriteLine("- " + entry.Key + ": " + entry.Value);
        }
    }
}
```

**3. `HashSet<T>`: The Set of Unique Elements**

A `HashSet<T>` is a high-performance collection that stores unique elements. It is an unordered set and provides extremely fast operations for adding elements and checking for their existence.

Key Characteristics:

* Unordered: The order of elements is not guaranteed.

* No Duplicates: A HashSet will automatically ignore any attempt to add an element that already exists.

* Fast Existence Checks: Checking if an element is in the set is, on average, a very fast O(1) operation.

Example: A List of Unique Tags

```C#
using System;
using System.Collections.Generic;

namespace CollectionsGuide;

public class TagsExample
{
    public static void Run()
    {
        Console.WriteLine("\n--- Using HashSet<T> for Unique Tags ---");

        // Create a new HashSet of strings.
        HashSet<string> tags = new HashSet<string>();

        // Add some tags.
        tags.Add("C#");
        tags.Add("Programming");
        tags.Add("Algorithms");

        // Attempt to add a duplicate. The HashSet will ignore it.
        tags.Add("C#");
        
        Console.WriteLine("Number of unique tags: " + tags.Count);
        
        // Check for the existence of a tag. This is very fast.
        if (tags.Contains("Algorithms"))
        {
            Console.WriteLine("The tag 'Algorithms' exists.");
        }
        
        Console.WriteLine("All unique tags:");
        foreach (string tag in tags)
        {
            Console.WriteLine("- " + tag);
        }
    }
}
```
**4. Practical Exercise: Tying it all together**

Now, let's use all three collections in a single program to manage a simple inventory.

1. Create a new Console Application project.

2. Copy and paste the following code into your Program.cs file.

```C#
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Inventory Management System ---");

        // Use a List to keep track of product names in the inventory.
        List<string> inventoryList = new List<string> { "Apple", "Banana", "Orange", "Apple" };

        // Use a Dictionary to store product prices.
        Dictionary<string, decimal> productPrices = new Dictionary<string, decimal>
        {
            { "Apple", 0.99m },
            { "Banana", 0.79m },
            { "Orange", 1.29m }
        };

        // Use a HashSet to quickly find out if a product is a fruit.
        HashSet<string> fruits = new HashSet<string> { "Apple", "Banana", "Orange" };

        Console.WriteLine("\n- Inventory Check -");
        foreach (string product in inventoryList)
        {
            // Check if the product is in the 'fruits' HashSet.
            if (fruits.Contains(product))
            {
                // Look up the price in the 'productPrices' Dictionary.
                decimal price = productPrices[product];
                Console.WriteLine($"Found a fruit: {product}, Price: {price:C}");
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
```

**5. Course Summary and Next Steps**

You've learned about three of the most important C# collections: `List<T>`, `Dictionary<TKey, TValue>`, and `HashSet<T>`. By understanding their strengths, you can choose the right tool for the job. Remember, a List is for ordered data, a Dictionary is for key-value lookups, and a HashSet is for unique items and fast existence checks.

Next Steps:

* More Collections: Explore other useful collections like `Queue<T>` (First-In, First-Out), `Stack<T>` (Last-In, First-Out), and `SortedList<TKey, TValue>`.

* LINQ: Learn how to use Language-Integrated Query (LINQ) to perform powerful and expressive queries on collections.

* Performance: Deepen your understanding of Big O notation and how it helps you select the most efficient collection for your specific use case.