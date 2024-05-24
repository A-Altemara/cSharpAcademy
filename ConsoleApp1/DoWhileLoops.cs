namespace ConsoleApp1;

static class DoWhileAndWhileLoops
{
    public static void DoWhileLoops()
    {
        Random random = new();
        int current = random.Next(1, 11);
        int counter = 0;
        
        do
        {
            current = random.Next(1, 11);
            if (current >= 8) // this ensures that a value >=8 will never be written to the console
                continue; // returns to the top of the statment (loop) to continue from there.
            counter += 1;
            Console.WriteLine($"DoWhile loopcurrent: {current}, counter: {counter}");
        }while (current !=7);
    }
    public static void WhileLoops()
    {
        Random random = new();
        int current = random.Next(1, 11);
        int counter = 0;
        while(current >= 3)
        {
            Console.WriteLine(current);
            current = random.Next(1, 11);
            counter += 1;
        }
        Console.WriteLine($"While Loop: current: {current}, counter: {counter}");
    }

    public static void RollPlayingGame()
    {
        int heroHealth = 10;
        int monsterHealth = 10;
        Random hitRoll = new();
        do
        {
            int attack = hitRoll.Next(1,11);
            monsterHealth -= attack;
            Console.WriteLine($"Hero deals {attack} damage. Monster health at {monsterHealth}");
            if (monsterHealth < 1)
            {
                break;
            }
            attack = hitRoll.Next(1,11);
            heroHealth -= attack;
            Console.WriteLine($"Monster deals {attack} damage. Hero health at {heroHealth}");

        } while (heroHealth > 0);
        Console.WriteLine($"{(heroHealth < 1 ? "Monster wins" : "Hero wins")}");
    }

    public static void nullableVariable()
    {
        // string? readResult;
        // Console.WriteLine("Enter a string:");
        // do
        // {
        //     readResult = Console.ReadLine();
        // } while (readResult == null);
        
        bool validEntry = false;
        Console.WriteLine("Enter a string containing at least three characters:");
        do
        {
            string? readResult = Console.ReadLine();
            if (readResult != null)
            {
                if (readResult.Length >= 3)
                {
                    validEntry = true;
                }
                else
                {
                    Console.WriteLine("Your input is invalid, please try again.");
                }
            }
        } while (validEntry == false);

    }
    
    public static void TryParse()
    {
        bool validEntry = false; // declared in outer scope so it can be used as loop condition
        int numericValue = 0; // declared in outer scope so it can be printed
        Console.WriteLine("Enter a number.");
        do
        {
            var readResult = Console.ReadLine(); // declared here to keep it within the narrowest scope
            if (readResult != null)
            {
                validEntry = int.TryParse( readResult, out numericValue);
                if (!validEntry)
                {
                    Console.WriteLine("Your input is invalid, please try again.");
                }
            }
            else
            {
                Console.WriteLine("Your input is invalid, please try again.");
            }
        } while (!validEntry);
        
        //do something with numericValue
        Console.WriteLine($"You entered the int {numericValue}");
    }

    public static void RequestNumber()
    {
        Console.WriteLine("Imput an integer between 5 and 10");
        
    }
}