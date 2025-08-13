# C# Course: Introduction to Dependency Injection

Dependency Injection (DI) is a fundamental software design pattern that has become a cornerstone of modern C# development. It's a powerful technique for creating loosely coupled, maintainable, and testable applications. In this module, we'll explore the what, why, and how of DI, complete with practical examples.

## 1. What is Dependency Injection? 🧱

At its core, Dependency Injection is a way of providing a class with its dependencies from an external source, rather than having the class create them itself.

Think of it this way: a Car class needs an Engine to function.

Without DI (Tight Coupling): The Car class is responsible for creating its own Engine instance. This creates a tight coupling between the two classes. If we want to test the Car with a different type of engine (e.g., an electric engine), we have to change the Car class's code.

```C#
// Without DI, Car is tightly coupled to CombustionEngine
public class Car
{
    private CombustionEngine _engine;

    public Car()
    {
        // The Car class is creating its own dependency
        _engine = new CombustionEngine();
    }

    public void Start()
    {
        _engine.Ignite();
        Console.WriteLine("Car started!");
    }
}
```

With DI (Loose Coupling): The Car class doesn't care how the Engine is created; it just needs an Engine to be provided to it. The responsibility of creating the Engine is "injected" from the outside. This allows us to easily swap out the CombustionEngine for an ElectricEngine without changing the Car's code.

The power of DI comes from the ability to program to an interface rather than a concrete implementation.

```C#
// Define an interface for the engine
public interface IEngine
{
    void Ignite();
}

public class CombustionEngine : IEngine
{
    public void Ignite()
    {
        Console.WriteLine("Combustion engine ignited!");
    }
}

public class ElectricEngine : IEngine
{
    public void Ignite()
    {
        Console.WriteLine("Electric motor engaged!");
    }
}

// With DI, Car is loosely coupled to the IEngine interface
public class Car
{
    private IEngine _engine;

    // The dependency is "injected" via the constructor
    public Car(IEngine engine)
    {
        _engine = engine;
    }

    public void Start()
    {
        _engine.Ignite();
        Console.WriteLine("Car started!");
    }
}
```

## 2. The Core Concepts 🧠

* Inversion of Control (IoC): DI is a specific implementation of this broader principle. IoC means that a class doesn't control the creation of its dependencies; instead, control is "inverted" and given to an external framework or container.

* Interfaces: These are critical for DI. By defining dependencies as interfaces (e.g., IEngine), we can easily swap out different implementations (CombustionEngine, ElectricEngine) without modifying the client class (Car). This is the key to decoupling.

* DI Container (or IoC Container): A DI container is a framework that automates the process of managing and injecting dependencies. It's responsible for creating instances of classes and injecting the correct dependencies into them. Popular C# containers include Microsoft.Extensions.DependencyInjection, Autofac, and Ninject.

## 3. Types of Dependency Injection 🛠️

There are three primary ways to inject a dependency:

1. Constructor Injection: The dependency is provided through a class's constructor. This is the most common and recommended approach, as it ensures the class is always in a valid state (its required dependencies are always present).

```C#
public class ReportService
{
    public ReportService(IExporter exporter) // Constructor Injection
    {
        // ...
    }
}
```

2. Property Injection: The dependency is set via a public property. This is useful for optional dependencies.

```C#
public class ReportService
{
    public ILogger Logger { get; set; } // Property Injection
}
```

3. Method Injection: The dependency is passed as a parameter to a specific method. This is useful when a dependency is only needed for one particular operation.

```C#
public class ReportService
{
    public void ExportReport(IExporter exporter) // Method Injection
    {
        exporter.Export();
    }
}
```

## 4. Practical Example with a DI Container 📦

Let's use the built-in Microsoft.Extensions.DependencyInjection container to build a simple console application. This container is commonly used in ASP.NET Core applications.

```C#
using Microsoft.Extensions.DependencyInjection;
using System;

// 1. Define the interfaces and classes
public interface IMessageSender
{
    void SendMessage(string message);
}

public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Email sent: {message}");
    }
}

public class NotificationService
{
    private readonly IMessageSender _sender;

    public NotificationService(IMessageSender sender)
    {
        _sender = sender;
    }

    public void Notify(string message)
    {
        _sender.SendMessage(message);
    }
}

// 2. Configure the DI container
class Program
{
    static void Main(string[] args)
    {
        // Create a new service collection
        var services = new ServiceCollection();

        // Register our dependencies and services
        // The container will create an instance of EmailSender whenever an IMessageSender is requested
        services.AddSingleton<IMessageSender, EmailSender>();

        // We can also register our NotificationService
        services.AddSingleton<NotificationService>();

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        // 3. Resolve the service from the container
        // The container automatically provides the NotificationService with an instance of EmailSender
        var notificationService = serviceProvider.GetService<NotificationService>();
        notificationService.Notify("Hello from Dependency Injection!");
    }
}
```

In the example above, we never explicitly created an EmailSender or NotificationService. The DI container handled all of that for us based on our registration.

## 5. Dependency Lifetimes

When you register a service with a DI container, you specify its lifetime. This determines how long the container keeps an instance of the service.

`AddSingleton<TInterface, TClass>()`: A single instance of the service is created and shared for the entire lifetime of the application.
`AddScoped<TInterface, TClass>()`: A new instance is created once per "scope" (e.g., once per web request in an ASP.NET Core app).
`AddTransient<TInterface, TClass>()`: A new instance is created every time the service is requested.

## 6. Exercises 📝

1. Refactoring Challenge: You have the following tightly coupled code. Refactor it to use Constructor Injection with an interface to make it more testable and flexible.

Before:

```C#
public class DataProcessor
{
    private DataBaseConnection _connection;

    public DataProcessor()
    {
        _connection = new DataBaseConnection();
    }

    public void ProcessData()
    {
        _connection.Open();
        // ... processing logic
        _connection.Close();
    }
}
public class DataBaseConnection
{
    public void Open() { Console.WriteLine("DB connection opened."); }
    public void Close() { Console.WriteLine("DB connection closed."); }
}
```

Your Task:
* Create an IDataConnection interface.
* Implement IDataConnection in a new class, SqlDataConnection.
* Modify DataProcessor to accept IDataConnection via its constructor.

2. DI Container Implementation: Expand on the refactoring challenge above. Create a console application that uses a ServiceCollection to:
* Register IDataConnection and SqlDataConnection as a singleton.
* Register DataProcessor as a transient service.
* Use the serviceProvider to resolve and run DataProcessor.ProcessData().