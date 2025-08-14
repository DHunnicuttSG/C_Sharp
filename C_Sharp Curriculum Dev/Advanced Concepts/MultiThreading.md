# C# Course: A Guide to Multi-Threading

Multi-threading is a powerful concept in programming that allows you to execute multiple sequences of instructions (threads) concurrently within a single application. This is a cornerstone of modern software development, enabling you to build responsive user interfaces, perform long-running tasks in the background, and take full advantage of multi-core processors.

## 1. Threads vs. Processes vs. Tasks 🧩

Before we dive into the code, it's helpful to clarify some key terms:

Process: A running instance of a program. Each process has its own isolated memory space. When you run a console application, you are creating a new process.

Thread: The smallest unit of execution within a process. A single process can contain multiple threads. Unlike processes, threads within the same process share the same memory space. This shared memory is what makes communication between threads fast but also introduces the risk of data corruption.

Task: A higher-level abstraction introduced by the Task Parallel Library (TPL). A Task represents an asynchronous operation. While tasks often use threads from a thread pool under the hood, they are not the same as threads. We use Task for a more structured and efficient approach to concurrency, especially with async/await.

In this module, we'll focus on the lower-level Thread class to understand the core mechanics of multi-threading.

## 2. The Danger: Race Conditions ⚠️

Because threads in the same process share memory, they can run into issues when accessing and modifying the same piece of data simultaneously. This is called a race condition.

A classic example is a shared counter. If two threads try to increment a variable at the same time, the final result might be incorrect because one thread's change could be overwritten by the other. This is a non-deterministic bug, meaning it may not happen every time, which makes it very difficult to debug.

To prevent race conditions, we must synchronize access to shared data.

## 3. Practical Example: Creating and Joining Threads 🧵

This example demonstrates how to create two threads that both try to increment a shared counter. As you'll see from the output, the final count is almost always wrong due to a race condition.

```C#
using System;
using System.Threading;

class Program
{
    // The shared resource that multiple threads will access
    private static int _sharedCounter = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Main thread started.");

        // Create two new threads, each running the IncrementCounter method
        Thread thread1 = new Thread(IncrementCounter);
        Thread thread2 = new Thread(IncrementCounter);
        Thread thread3 = new Thread(IncrementCounter);
        Thread thread4 = new Thread(IncrementCounter);

        // Start the threads
        thread1.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();

        // The Main thread waits for both worker threads to finish
        thread1.Join();
        thread2.Join();
        thread3.Join();
        thread4.Join();

        Console.WriteLine("All worker threads have finished.");
        Console.WriteLine($"Final counter value (without locking): {_sharedCounter}");
        // This value is likely to be less than 2000 due to race conditions.
    }

    public static void IncrementCounter()
    {
        for (int i = 0; i < 1000; i++)
        {
            _sharedCounter++;
        }
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished incrementing.");
    }
}
```

## 4. Solving the Race Condition with lock 🔐

To fix the race condition from the previous example, we need to ensure that only one thread can access the shared counter at a time. C# provides the lock statement for this purpose.

A lock statement acquires an exclusive lock on a given object, runs the code inside the block, and then releases the lock. Any other thread that tries to acquire the same lock will wait until the current thread releases it.

Here is the modified and corrected code:

```C#
using System;
using System.Threading;

class Program
{
    // The shared resource
    private static int _sharedCounter = 0;

    // A private, static, readonly object is the best practice for a lock object.
    private static readonly object _lockObject = new object();

    static void Main(string[] args)
    {
        Console.WriteLine("Main thread started.");

        Thread thread1 = new Thread(IncrementCounterSafe);
        Thread thread2 = new Thread(IncrementCounterSafe);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("All worker threads have finished.");
        Console.WriteLine($"Final counter value (with locking): {_sharedCounter}");
        // This value will always be 2000.
    }

    public static void IncrementCounterSafe()
    {
        for (int i = 0; i < 1000; i++)
        {
            // The lock ensures that only one thread can enter this block at a time.
            lock (_lockObject)
            {
                _sharedCounter++;
            }
        }
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished incrementing.");
    }
}
```

## 5. Exercises ✍️

1. Thread-Safe Calculator: Create a console application that uses a shared decimal variable for a balance. Create two threads: one that repeatedly adds a small amount to the balance and another that repeatedly subtracts from it.First, run the program without any locking and observe the incorrect final balance.Then, add a lock statement to the critical sections to ensure the final balance is correct and predictable.

2. Parallel ForEach: While the Thread class is useful for understanding, in modern C#, we often use the higher-level Task Parallel Library. Write a console application that uses Parallel.ForEach to iterate over a large array of numbers. Inside the loop, perform a computationally expensive operation (e.g., finding the square root) and observe how much faster it is compared to a standard foreach loop.