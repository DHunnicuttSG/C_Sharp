using DemoLibrary;

Console.Write("What is your first name?: ");
string? firstName = Console.ReadLine();

Console.Write("What is your last name?: ");
string? lastName = Console.ReadLine();

string fullName = PersonProcessor.JoinName(firstName, lastName);

Console.WriteLine($"Your full name is: {fullName}");