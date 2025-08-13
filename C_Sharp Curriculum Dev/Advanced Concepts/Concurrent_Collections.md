# C# Course: A Guide to Concurrent Collections

When you're building applications that perform multiple operations at the same time—using threads or tasks—you need to be careful about how those operations interact with shared data. This module introduces you to Concurrent Collections, a set of thread-safe data structures in C# that prevent common issues like race conditions.

## 1. The Problem: Race Conditions with Standard Collections 🏃

Standard collections like `List<T>`, `Dictionary<TKey, TValue>`, and `Queue<T>` are not thread-safe. This means if multiple threads try to read from or write to the same collection simultaneously, you can run into unpredictable and dangerous behavior, known as a race condition.A race condition occurs when the outcome of a program depends on the sequence or timing of uncontrollable events. For example, if two threads try to add an item to a `List<T>` at the same time, one item might be lost, or the internal state of the list could become corrupted, leading to an exception.


```C#
// This code is NOT thread-safe and will fail.
List<int> numbers = new List<int>();

void AddNumbers()
{
    for (int i = 0; i < 1000; i++)
    {
        numbers.Add(i);
    }
}

// Running AddNumbers from two separate threads will cause issues.
// Thread 1: AddNumbers()
// Thread 2: AddNumbers()
```

To prevent this, you would traditionally have to use explicit locking mechanisms, which can be complex and error-prone.

## 2. The Solution: System.Collections.Concurrent 🤝

The System.Collections.Concurrent namespace provides a set of highly optimized, thread-safe collections. These collections handle the locking and synchronization internally, so you don't have to. You can simply use them in your multi-threaded code without worrying about race conditions.

The key benefit is that these collections are designed for high-performance concurrent scenarios. They often use lock-free or fine-grained locking strategies to minimize contention and maximize throughput.

## 3. Key Concurrent Collections 📦

Here are some of the most common and useful concurrent collections:

|Collection |Description |Best for... | 
|---|---|---|
|`ConcurrentDictionary<TKey, TValue>`|A thread-safe dictionary that supports adding, updating, and retrieving key-value pairs concurrently. |Caching, storing shared configuration data, or any scenario where you need a thread-safe dictionary. |
|`ConcurrentBag<T>` |An unordered collection of objects. Optimized for scenarios where multiple threads are adding and removing items without any particular order. |Producer/Consumer patterns, where multiple producers add items and multiple consumers process them. |
|`ConcurrentQueue<T>` |A thread-safe FIFO (First-In, First-Out) collection. Items are enqueued from one end and dequeued from the other.|Scenarios that require a queue for asynchronous tasks, such as a work queue for a thread pool.|
|`ConcurrentStack<T>` |A thread-safe LIFO (Last-In, First-Out) collection. Items are pushed and popped from the top of the stack. |Implementing undo/redo functionality or managing task lifecycles in a multi-threaded context. |

## 4. Practical Example: Using ConcurrentBag<T> 🛠️

Let's refactor our earlier, non-thread-safe example to use a ConcurrentBag<T>. We will use Task.Run to simulate multiple threads performing work simultaneously.

```C#
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Create a thread-safe ConcurrentBag
        var concurrentBag = new ConcurrentBag<int>();

        // We will simulate 1000 items being added by 4 separate tasks
        var tasks = new Task[4];
        for (int i = 0; i < tasks.Length; i++)
        {
            // Each task will add 250 items to the shared collection
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 250; j++)
                {
                    concurrentBag.Add(j);
                }
            });
        }

        // Wait for all tasks to complete
        Task.WaitAll(tasks);

        Console.WriteLine($"Number of items added to ConcurrentBag: {concurrentBag.Count}");
        
        // Use a standard LINQ query to verify the contents (this is safe after all tasks are finished)
        int sum = concurrentBag.Sum();
        Console.WriteLine($"Sum of all items: {sum}");
    }
}
```

If you were to replace `ConcurrentBag<int>` with `List<int>` in the above example, the final count would likely be less than 1000, and you might even get an exception. The ConcurrentBag, however, ensures that every single item is added successfully, and the final count is exactly as expected.

5. Exercises ✍️

1. Word Counter: Write a console application that uses a `ConcurrentDictionary<string, int>`. Create a method that takes a string of text and counts the frequency of each word. Then, use multiple Task.Run() calls to process different sentences or paragraphs concurrently, adding the word counts to the shared ConcurrentDictionary.

2. Producer-Consumer Pattern: Implement a simple producer-consumer scenario using a `ConcurrentQueue<T>`.

* Create a "Producer" task that adds random integers to the queue every few milliseconds.

* Create a "Consumer" task that tries to remove and print an item from the queue. If the queue is empty, it should simply continue trying.

* Run both tasks simultaneously and observe how the ConcurrentQueue safely manages the shared data.