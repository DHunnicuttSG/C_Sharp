namespace DemoLibrary;

public class PersonProcessor
{
    public static string JoinName(string? firstName, string? lastName)
    {
        return firstName + " " + lastName;
    }
}

public class ConsoleInput
{
    public static int GetIntInput(string? prompt)
    {
        string? input;
        int output;

        while (true)
        {
            Console.Write(prompt);
            input = Console.ReadLine();

            if (int.TryParse(input, out output))
                return output;

            Console.WriteLine("That was not a valid integer... Please try again.");
        }
    }

    public static int GetIntMinMax(string? prompt, int min, int max)
    {
        string? input;
        int output;

        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();

            if (int.TryParse(input, out output))

                return output;

            Console.WriteLine("That was not a valid integer... Please try again.");
        } while (output < min || output > max);

        return output;
    }
}

