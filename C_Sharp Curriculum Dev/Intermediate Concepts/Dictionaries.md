# C# Dictionaries: A Guide 📚

Welcome to this course on the `Dictionary<TKey, TValue>` data type! Dictionaries are one of the most powerful and efficient collections in C# for storing and retrieving data. They are designed for scenarios where you need to quickly look up a value based on a unique key.

**1. What is a `Dictionary<TKey, TValue>`?**

A Dictionary stores a collection of key-value pairs. Think of it like a real-world dictionary: you look up a word (the key) to find its definition (the value). Each key must be unique, and it serves as a fast and direct way to access its corresponding value.

The `<TKey, TValue>` in the name stands for generic type parameters. This means you must specify the data type for both the key and the value when you create a Dictionary, which provides strong type safety. For example, a `Dictionary<string, int>` would store strings as keys and integers as values.

Key Characteristics:

* Key-Value Pairs: Stores data as a collection of unique keys mapped to values.

* Unique Keys: A Dictionary does not allow duplicate keys. Attempting to add a key that already exists will result in an error.

* Fast Lookups: Accessing, adding, or removing an item by its key is, on average, a very fast O(1) operation. This is its primary advantage over a `List<T>`.

* Unordered: The order of elements in a Dictionary is not guaranteed.

**2. Common `Dictionary<TKey, TValue>` Methods**

The Dictionary class provides a concise set of methods for managing your key-value data.  
| Method | Description |  
|-----|-----|  
| Add(TKey key, TValue value) | Adds the specified key and value to the dictionary. |
| Remove(TKey key) | Removes the value with the specified key.|
| ContainsKey(TKey key) | Returns true if the dictionary contains the specified key, otherwise false. This is a very important method to prevent errors. | 
| TryGetValue(TKey key, out TValue value) | Attempts to get the value associated with the specified key. Returns true on success and false if the key is not found, without throwing an exception. | 
|Count | A property that returns the number of key-value pairs in the dictionary. |
|Clear() | Removes all keys and values from the dictionary.|

**3. Practical Example: A Simple Product Inventory**

Let's create a console application that uses a Dictionary to manage a simple product inventory. We'll use the product's unique ID as the key and the product name as the value.

```C#
using System;
using System.Collections.Generic;

namespace DictionaryCourseGuide;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Product Inventory Manager ---");

        // Create a new Dictionary with int keys and string values.
        Dictionary<int, string> products = new Dictionary<int, string>();

        // Add products to the dictionary. The key is the product ID.
        products.Add(101, "Laptop");
        products.Add(102, "Mouse");
        products.Add(103, "Keyboard");
        
        Console.WriteLine($"The inventory contains {products.Count} products.");

        // Check if a product with a specific key exists before accessing it.
        int productIdToFind = 102;
        if (products.ContainsKey(productIdToFind))
        {
            Console.WriteLine($"\nFound product with ID {productIdToFind}: {products[productIdToFind]}");
        }
        else
        {
            Console.WriteLine($"\nProduct with ID {productIdToFind} not found.");
        }

        // A safer way to access a value is with TryGetValue.
        if (products.TryGetValue(103, out string productName))
        {
            Console.WriteLine($"Product with ID 103 is: {productName}");
        }

        // You can also use a foreach loop to iterate through the key-value pairs.
        Console.WriteLine("\nAll products in inventory:");
        foreach (KeyValuePair<int, string> product in products)
        {
            Console.WriteLine($"- ID: {product.Key}, Name: {product.Value}");
        }
    }
}
```

**4. Exercise: Building a Simple Phonebook**

Now it's your turn to practice! Create a new console application and build a simple phonebook system using a `Dictionary<TKey, TValue>`.

Your task:

1. Create a `Dictionary<string, string>` to represent a phonebook. The key should be the person's name (a string) and the value should be their phone number (also a string).

2. Add at least three contacts to your phonebook.

3. Check if a specific name exists in the phonebook using ContainsKey. If it does, print their phone number.

4. Remove one of the contacts from the phonebook.

5. Print all the remaining contacts in the phonebook.

**5. Course Summary and Next Steps**

You've learned that the `Dictionary<TKey, TValue>` is an incredibly useful collection for situations that require fast lookups based on a unique key. By using this collection, you can write code that is both clean and highly performant.

Next Steps:

* Performance Trade-offs: Learn about other collections like `SortedDictionary<TKey, TValue>` and how their performance differs from Dictionary (e.g., faster iteration, but slower key-based access).

* Custom Keys: Explore how to use your own custom objects as keys in a Dictionary by correctly implementing GetHashCode() and Equals().

* Error Handling: Understand how to use TryGetValue to safely access values without having to explicitly check for keys first.