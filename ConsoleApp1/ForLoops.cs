namespace ConsoleApp1;

static class ForLoops
{
    public static void BasicLoops()
    {
        // for (int i = 0; i < 10; i ++)
        // {
        //     Console.WriteLine(i);
        //     if (i==7) break;
        // }
        
        string[] names = { "Alex", "Eddie", "David", "Michael" };
        for (int i = names.Length - 1; i >= 0; i--)
        {
            Console.WriteLine(names[i]);
        }
        
        // foreach (var name in names)
        // {
        //     // Can't do this:
        //     if (name == "David") name = "Sammy";
        // }
        
        for (int i = 0; i < names.Length; i++)
            if (names[i] == "David") names[i] = "Sammy";

        foreach (var name in names) Console.WriteLine(name);
    }

    public static void FizzBuzz()
    {
        for (int i = 1; i <= 15; i++)
        {
            var foo = "";
            foo += i % 3 == 0 ? "Fizz" : "";
            foo += i % 5 == 0 ? "Buzz" : "";
            // if (i % 3 == 0)
            // {
            //     foo += "Fizz";
            // }
            // if (i % 5 == 0)
            // {
            //     foo += "Buzz";
            // }
            
            Console.WriteLine($"{i}{(foo == "" ? "" : " - " + foo)}");
            // if (i % 3 == 0 && i % 5 == 0)
            // {
            //     Console.Write($" - FizzBuzz");
            // }
            // else if (i % 3 == 0)
            // {
            //     Console.Write($" - Fizz");
            // } else if (i % 5 == 0)
            // {
            //     Console.Write($" - Buzz");
            // }
        }
    }
}