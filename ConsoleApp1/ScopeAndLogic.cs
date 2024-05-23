namespace ConsoleApp1;

static class ScopeAndLogic
{
    public static void Scope()
    {
        
        int value;
        bool flag = true;
        if (flag)
        {
            value = 10;
            Console.WriteLine($"inside the code block: {value}");
        }
        value = 20;
        Console.WriteLine($"outside the code block: {value}");

        if (flag) 
            Console.WriteLine(flag);

        // readable 'one-line' if else statement
        string name = "steve";
        if (name == "bob") 
            Console.WriteLine("found bob");
        else if (name == "steve") 
            Console.WriteLine("found steve");
        else 
            Console.WriteLine("found Chuck");
        
    }

    public static void ChallengeScope()
    {
        
        // scoped code per example
        int[] numbers1 = { 4, 8, 15, 16, 23, 42 };
        int total1 = 0;
        bool found = false;
        foreach (int number in numbers1)
        {
            total1 += number;
            if (number == 42)
                found = true;
        }

        if (found) 
            Console.WriteLine("Set contains 42");
        
        Console.WriteLine($"Total1: {total1}");
        
        // simplified code as found variable was not needed
        int[] numbers2 = { 4, 8, 15, 16, 23, 42 };
        int total2 = 0;
        foreach (int number in numbers2)
        {
            total2 += number;
            if (number == 42)
                Console.WriteLine("Set contains 42");
        }
        Console.WriteLine($"Total2: {total2}");
    }
}


