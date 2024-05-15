namespace ConsoleApp1;

static class Lesson1
{
    public static void DiceRandom()
    {
        Random dice = new Random();
        int roll0 = dice.Next(50, 101);
        int roll1 = dice.Next();
        int roll2 = dice.Next(101);
        Console.WriteLine(roll0);
        Console.WriteLine(roll1);
        Console.WriteLine(roll2);

        int number = 7;
        string text = "seven";

        Console.WriteLine(number); // 7
        Console.WriteLine(); // does nothing
        Console.WriteLine(text); // seven

        int firstValue = 500;
        int secondValue = 600;
        int largerValue = Math.Max(firstValue, secondValue);

        Console.WriteLine(largerValue);
    }
}