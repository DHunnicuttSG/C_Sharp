# C# Advanced Class Design: A Course Guide 🚀

Welcome to the next level of C# class design! In this guide, we'll dive deeper into powerful object-oriented programming (OOP) concepts that allow you to write more flexible, reusable, and maintainable code. We'll explore how to build relationships between classes using inheritance, define contracts with interfaces, create blueprints with abstract classes, and leverage the power of polymorphism.

**1. Inheritance: Building on Existing Classes**

Inheritance is a core principle of OOP that allows you to define a base class (or parent class) and then create derived classes (or child classes) that inherit the base class's properties and methods. This creates a powerful "is-a" relationship (e.g., a Car is a Vehicle, a Dog is an Animal).

Key Concepts:

* Base Class: The class being inherited from.

* Derived Class: The class that inherits from the base class.: operator: The syntax used to specify a derived class's base class (e.g., class Car : Vehicle).

* virtual and override: The virtual keyword allows a method in the base class to be overridden by a derived class. The override keyword is used in the derived class to provide a new implementation for that method.

Exercise 1: The Vehicle Base Class

1. Create a new Console Application project.

2. Define a Vehicle base class with some properties and a virtual method.

```C#
// Vehicle.cs
namespace AdvancedClassDesign;

public class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }

    public virtual void Drive()
    {
        Console.WriteLine("The vehicle is moving.");
    }
}
```

3. Now, create a Car class that inherits from Vehicle and overrides the Drive method.

```C#
// Car.cs
namespace AdvancedClassDesign;

public class Car : Vehicle
{
    public int NumberOfDoors { get; set; }

    // Use 'override' to provide a new implementation for the Drive method.
    public override void Drive()
    {
        Console.WriteLine($"The {Make} {Model} is driving on the road.");
    }
}
```

4. In your Program.cs file, create instances of both classes and call their methods to see the results.

```C#
// Program.cs
namespace AdvancedClassDesign;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Inheritance Exercise ---");

        Vehicle myVehicle = new Vehicle { Make = "Generic", Model = "Model X" };
        myVehicle.Drive(); // Output: "The vehicle is moving."

        Car myCar = new Car { Make = "Ford", Model = "Mustang", NumberOfDoors = 2 };
        myCar.Drive(); // Output: "The Ford Mustang is driving on the road."
        
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
```

**2. Abstract Classes: Defining a Blueprint**

An abstract class is a special kind of base class that cannot be instantiated on its own. Its purpose is to serve as a blueprint for other classes, forcing derived classes to implement certain functionality. Abstract classes can contain a mix of concrete methods (with an implementation) and abstract methods (without an implementation).

Key Concepts:

* abstract keyword: Used to declare an abstract class or an abstract method.

* No Instantiation: You cannot create an object directly from an abstract class.

* Implementation Required: Any derived class must provide an implementation for all abstract methods inherited from the abstract base class.

Exercise 2: The Animal Abstract Class

1. Let's define an abstract Animal class with an abstract method MakeSound().

```C#
// Animal.cs
namespace AdvancedClassDesign;

// An abstract class cannot be instantiated directly.
public abstract class Animal
{
    public string Name { get; set; }

    // An abstract method has no body and must be implemented by derived classes.
    public abstract void MakeSound();
    
    // Abstract classes can have concrete methods too.
    public void Sleep()
    {
        Console.WriteLine($"{Name} is sleeping.");
    }
}
```

2. Now, create Dog and Cat classes that inherit from Animal and implement the MakeSound method.

```C#
// Dog.cs
namespace AdvancedClassDesign;

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
}

// Cat.cs
namespace AdvancedClassDesign;

public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow!");
    }
}
```

3. Modify your Program.cs to use these new classes.

```C#
// Program.cs (updated)
namespace AdvancedClassDesign;

class Program
{
    static void Main(string[] args)
    {
        // ... previous code ...
        Console.WriteLine("\n--- Abstract Class Exercise ---");
        
        // You cannot do this: Animal myAnimal = new Animal();
        
        Dog myDog = new Dog { Name = "Fido" };
        myDog.MakeSound();
        myDog.Sleep();

        Cat myCat = new Cat { Name = "Whiskers" };
        myCat.MakeSound();
        myCat.Sleep();

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
```
**3. Interfaces: Defining a Contract**

An interface is similar to an abstract class, but it contains only the signatures of methods, properties, and events. It defines a contract that a class must adhere to. A class can implement multiple interfaces, which is a key advantage over inheritance (where a class can only inherit from one base class).

Key Concepts:

* interface keyword: Used to declare an interface.

* I prefix: By convention, interface names start with I (e.g., IDrivable).

* Implementation: A class uses the `:` operator to implement an interface, and it must provide a public implementation for all interface members.

Exercise 3: The IDrivable Interface

1. Let's define an IDrivable interface with a single method.

```C#
// IDrivable.cs
namespace AdvancedClassDesign;

public interface IDrivable
{
    void Drive();
}
```

2. Now, modify your Car and Vehicle classes to implement this interface.

```C#
// Car.cs (updated)
namespace AdvancedClassDesign;

public class Car : Vehicle, IDrivable
{
    public int NumberOfDoors { get; set; }

    public override void Drive()
    {
        Console.WriteLine($"The {Make} {Model} is driving on the road.");
    }
}
```

* Note: The Vehicle class already has a Drive() method. If we make Vehicle implement IDrivable, the Car class, by inheriting from Vehicle, will automatically satisfy the IDrivable contract.

**4. Polymorphism: The Power of "Many Forms"**

Polymorphism is the ability of an object to take on many forms. In C#, this means you can use a base class or an interface to refer to an object of any of its derived or implementing types. This allows you to write code that works with a collection of different objects in a uniform way.

Key Concepts:

* Base Class Reference: A variable of a base class type can hold an instance of any derived class.

* Interface Reference: A variable of an interface type can hold an instance of any class that implements that interface.

Exercise 4: Demonstrating Polymorphism

1. Modify Program.cs to showcase polymorphism using the classes we've created.

```C#
// Program.cs (updated)
namespace AdvancedClassDesign;

class Program
{
    static void Main(string[] args)
    {
        // ... previous code ...
        Console.WriteLine("\n--- Polymorphism Exercise ---");

        // A list of Animal objects, but it holds different derived types.
        List<Animal> animals = new List<Animal>
        {
            new Dog { Name = "Fido" },
            new Cat { Name = "Whiskers" }
        };

        foreach (var animal in animals)
        {
            Console.Write($"{animal.Name}: ");
            animal.MakeSound();
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
```

Summary of Concepts:
* Inheritance defines a hierarchy and a shared base implementation.

* Abstract Classes provide a partial blueprint and enforce a shared structure.

* Interfaces define a contract for behavior without any implementation.

* Polymorphism allows you to treat related objects as a single, common type.

**5. Summary and Next Steps**

This guide has given you a solid foundation in advanced class design. You've learned how to create a class hierarchy with inheritance, define contracts with interfaces, and use polymorphism to write more flexible code. These concepts are foundational to building complex, well-structured applications.

Next Steps:

* Generics: Learn how to write classes and methods that can work with any data type, without sacrificing type safety.

* Delegates and Events: Explore how to use these to create loosely coupled components that can communicate with each other.

* SOLID Principles: Study the five key principles of object-oriented design that will help you write even better code.