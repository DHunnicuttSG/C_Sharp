# C# Dependency Injection with Interfaces: A Course Guide 💉

Welcome to this course on Dependency Injection (DI)! DI is a fundamental design pattern in modern C# development that helps you create applications that are more flexible, maintainable, and testable. The core idea is to remove hard-coded dependencies from your classes, making them loosely coupled and easier to manage.This guide will introduce the concept of DI using a practical analogy, show you the crucial role that interfaces play in making it work, and provide examples and an exercise to help you master the pattern.

## 1. The Problem: Tight Coupling

Imagine you're building a Car class. A car needs an engine to run, so you might write a class like this:

```C#
public class Engine
{
    public void Start()
    {
        Console.WriteLine("Engine started!");
    }
}

public class Car
{
    private readonly Engine _engine;

    public Car()
    {
        // The Car class is tightly coupled to the Engine class.
        // It's responsible for creating its own dependency.
        _engine = new Engine();
    }

    public void Drive()
    {
        _engine.Start();
        Console.WriteLine("Car is driving!");
    }
}
```

The problem here is that the Car class is responsible for creating its own Engine dependency. This is called tight coupling. If you wanted to test the Car without a real Engine, or if you needed to use a different type of engine (e.g., an ElectricEngine), you would have to modify the Car class itself. This violates the Open-Closed Principle (a class should be open for extension, but closed for modification).

## 2. The Solution: Dependency Injection

Dependency Injection solves this problem by inverting control. Instead of a class creating its own dependencies, an external source provides them. The most common form of DI is constructor injection.

```C#
public class ElectricEngine
{
    public void Start()
    {
        Console.WriteLine("Electric engine humming to life!");
    }
}

public class Car
{
    // The Car class no longer creates its dependency; it receives it.
    private readonly ElectricEngine _engine;

    // The dependency is "injected" through the constructor.
    public Car(ElectricEngine engine)
    {
        _engine = engine;
    }

    public void Drive()
    {
        _engine.Start();
        Console.WriteLine("Car is driving silently!");
    }
}
```


In this example, the Car class no longer has to know how to build an Engine. Its dependency is "injected" at creation. This is a big step, but it's not complete. The Car is still tightly coupled to the ElectricEngine class.

## 3. The Role of Interfaces

This is where interfaces become essential. An interface allows you to program against a contract instead of a concrete implementation. Let's refactor our Car to depend on an interface instead of a specific engine class.

Step 1: Define the Interface

First, we'll create an interface that defines the contract for any type of engine.

```C#
public interface IEngine
{
    void Start();
}
```

Step 2: Implement the Interface

Next, our concrete engine classes (GasolineEngine and ElectricEngine) will implement this interface.

```C#
// The GasolineEngine now implements the IEngine contract.
public class GasolineEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Vroom! Gasoline engine started!");
    }
}

// The ElectricEngine also implements the IEngine contract.
public class ElectricEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Electric engine humming to life!");
    }
}
```

Step 3: Inject the Interface

Finally, we modify the Car class to depend on the IEngine interface. Now the Car doesn't care what kind of engine it has, as long as it fulfills the IEngine contract. This is the essence of DI.

```C#
public class Car
{
    private readonly IEngine _engine;

    // The Car now depends on the IEngine interface.
    public Car(IEngine engine)
    {
        _engine = engine;
    }

    public void Drive()
    {
        _engine.Start();
        Console.WriteLine("Car is driving!");
    }
}
```

Step 4: Putting it all together

The final step is to "wire up" our application. This is typically done in the entry point of the program, where you create the concrete objects and inject them.

```C#
using System;

// Assume all classes above are defined.

class Program
{
    static void Main(string[] args)
    {
        // 1. Create the dependencies.
        IEngine gasolineEngine = new GasolineEngine();
        IEngine electricEngine = new ElectricEngine();
        
        // 2. Inject the dependencies when creating the Car.
        Console.WriteLine("--- Creating a gasoline car ---");
        Car gasolineCar = new Car(gasolineEngine);
        gasolineCar.Drive();

        Console.WriteLine("\n--- Creating an electric car ---");
        Car electricCar = new Car(electricEngine);
        electricCar.Drive();
    }
}
```

## 4. Practical Exercise: A Logging System

Now it's your turn to put these concepts into practice. You'll create a simple logging system that uses DI to allow for different logging destinations.

Your Task:

1. Create an ILogger interface with a single method: void Log(string message).
2. Create two classes that implement this interface:
    * A ConsoleLogger that writes the message to the console.
    * A FileLogger that writes the message to a file named log.txt.
3. Create a ReportGenerator class that has a dependency on the ILogger interface. The ReportGenerator's constructor should accept an ILogger instance.
4. The ReportGenerator should have a method like GenerateReport() that logs a message (e.g., "Report is being generated...") using the injected logger.
5. In your Main method, create two ReportGenerator instances: one with a ConsoleLogger and one with a FileLogger. Call GenerateReport() on both to demonstrate how DI allows you to change behavior without changing the ReportGenerator class.

## 5. Course Summary and Next Steps

You've learned that Dependency Injection is a design pattern that promotes loose coupling by injecting dependencies instead of creating them internally. The use of interfaces is critical to this pattern, as it allows your code to depend on contracts (IEngine) rather than concrete implementations (GasolineEngine). This makes your code more modular, testable, and easier to extend.

Next Steps:
* Dependency Injection Containers: For larger applications, managing dependencies manually becomes tedious. Explore DI containers (also known as IoC containers) like Microsoft's built-in container, Autofac, or Ninject, which automatically handle the creation and injection of dependencies for you.
* Property Injection and Method Injection: While constructor injection is the most common, learn about other forms of DI, such as injecting dependencies via a public property or a method.
* Testing: Practice writing unit tests for your classes. You'll quickly see how DI makes it easy to mock dependencies and isolate the class you're testing.