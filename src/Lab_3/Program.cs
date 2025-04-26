// Task 1: Fix naming conventions (use camelCase for variables, PascalCase for methods)
class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
    }
    private static void Task1()
    {
        int userAge = 20; // Changed 'user_age' to camelCase
        string userName = "Андрій"; // Changed 'UserName' to camelCase
        Console.WriteLine($"Привіт, {userName}! Твій вік: {userAge}");
    }

    // Task 2: Fix reserved words in variable names
    private static void Task2()
    {
        int userAge = 20; // Variable name is fine, no reserved word
        string userName = "Андрій"; // Variable name is fine, no reserved word
        Console.WriteLine($"Привіт, {userName}! Твій вік: {userAge}");
    }

    // Task 3: Add explanatory comments to each line
    private static void Task3()
    {
        // Declare and initialize a string variable to store the user's name
        string name = "Анна";
        // Declare and initialize an integer variable to store the user's age
        int age = 25;
        // Output a greeting message with the user's name and age to the console
        Console.WriteLine($"Привіт, {name}! Твій вік: {age}");
    }
}