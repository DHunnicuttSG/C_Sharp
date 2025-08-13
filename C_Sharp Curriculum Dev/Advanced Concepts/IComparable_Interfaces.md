C# IComparable Interface: A Course Guide 📝Welcome to this course on the IComparable<T> interface in C#. While built-in types like int and string have a natural sorting order, your custom classes do not. The IComparable<T> interface is a powerful tool that allows you to define a default sorting order for objects of your own design.By implementing this interface, you are providing a blueprint for how your objects should be compared to one another, enabling collections like List<T> to be sorted automatically using methods like Sort().1. What is IComparable<T>?The IComparable<T> interface is a contract that requires a class to implement a single method: CompareTo. This method takes one object of the same type and returns an int that represents the comparison result.The CompareTo method must return:A negative value if the current instance is less than the object being compared.0 if the current instance is equal to the object being compared.A positive value if the current instance is greater than the object being compared.By following this simple contract, any class can be sorted in a predictable way.2. Practical Example: Sorting a Custom ClassLet's create a Car class and demonstrate how IComparable allows us to sort a list of cars.Step 1: The Car Class (Without IComparable)First, let's define our Car class without implementing the interface. If you try to sort a List<Car> at this point, you will get a runtime error because C# doesn't know how to compare two Car objects.public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    // This override is for better console output.
    public override string ToString()
    {
        return $"{Year} {Make} {Model}";
    }
}
Step 2: Implementing IComparable<T>Now, let's update our Car class to implement IComparable<Car>. We'll define the CompareTo logic to sort the cars primarily by their Year and secondarily by their Make (in case the years are the same).using System;
using System.Collections.Generic;

public class Car : IComparable<Car>
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Car(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    // The CompareTo method is the core of the IComparable interface.
    public int CompareTo(Car? other)
    {
        if (other == null) return 1;

        // Primary sort: by year.
        int yearComparison = this.Year.CompareTo(other.Year);
        if (yearComparison != 0)
        {
            return yearComparison;
        }

        // Secondary sort: if years are the same, sort by make.
        return this.Make.CompareTo(other.Make);
    }

    public override string ToString()
    {
        return $"{Year} {Make} {Model}";
    }
}
Step 3: Sorting the ListWith the interface implemented, our List<Car> can now be sorted. The List.Sort() method will automatically use the CompareTo method we defined.using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>
        {
            new Car("Ford", "Mustang", 1965),
            new Car("Chevrolet", "Camaro", 1969),
            new Car("Ford", "Thunderbird", 1965),
            new Car("Dodge", "Charger", 1969)
        };

        Console.WriteLine("Cars before sorting:");
        cars.ForEach(car => Console.WriteLine(car));

        // The Sort() method now works because Car implements IComparable<Car>.
        cars.Sort();

        Console.WriteLine("\nCars after sorting:");
        cars.ForEach(car => Console.WriteLine(car));
    }
}
Expected Output:Cars before sorting:
1965 Ford Mustang
1969 Chevrolet Camaro
1965 Ford Thunderbird
1969 Dodge Charger

Cars after sorting:
1965 Ford Mustang
1965 Ford Thunderbird
1969 Chevrolet Camaro
1969 Dodge Charger
Notice how the cars are sorted by year, and then the 1965 cars are sorted by make.3. Practical Exercise: Sorting EmployeesNow it's your turn! Create a console application to practice implementing IComparable<T>.Your Task:Create a simple Employee class with properties: FirstName (string), LastName (string), and Salary (decimal).Implement the IComparable<Employee> interface on the Employee class.Write the CompareTo method to provide a default sort order for employees. The sort should be primarily by LastName and secondarily by FirstName if the last names are the same.In your Main method, create a List<Employee> with at least four employees, including some with the same last name but different first names.Print the list before sorting.Call the Sort() method on your list.Print the sorted list to the console to verify that the sorting logic works as expected.4. Course Summary and Next StepsYou've learned that IComparable<T> is the standard way to define a single, default sorting order for a custom type. This is a fundamental concept for making your classes compatible with standard C# collection methods.Next Steps:The IComparer Interface: While IComparable defines a single default sort, the IComparer interface allows you to define multiple, different sorting strategies for a class. This is useful if you want to sort a list of employees by salary, age, or any other criteria.Default Equality: Explore how to use IEquatable<T> and override the Equals and GetHashCode methods to define how two objects of your class are considered equal.