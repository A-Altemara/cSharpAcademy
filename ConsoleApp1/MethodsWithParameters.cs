using System.Threading.Channels;

namespace ConsoleApp1;

public class MethodsWithParameters
{
    public static void FirstParameters(int[] times, int currentGMT, int newGMT)
    {
        int diff = 0;
        if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
        {
            Console.WriteLine("invalid GMT");
        }
        else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
        {
            diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));
        }
        else
        {
            diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));
        }

        for (int i = 0; i < times.Length; i++)
        {
            int newTime = ((times[i] + diff)) % 2400;
            Console.WriteLine($"{times[i]} -> {newTime}");
        }
    }


    public static void DisplayStudents(string[] students)
    {
        foreach (string student in students)
        {
            Console.Write($"{student}, ");
        }

        Console.WriteLine();
    }

    const double pi = 3.14159;

    public static void PrintCircleArea(int radius)
    {
        Console.WriteLine($"Circle with radius {radius}");
        double area = pi * (radius * radius);
        Console.WriteLine($"Area = {area}");
        PrintCircleCircumference(radius);
    }

    public static void PrintCircleCircumference(int radius)
    {
        double circumference = 2 * pi * radius;
        Console.WriteLine($"Circumference = {circumference}");
    }

    public static void Multiply(int a, int b, int c) // ints are value types
    {
        Console.WriteLine($"global statement: {a} x {b} = {c}");
        c = a * b;
        Console.WriteLine($"inside Multiply method: {a} x {b} = {c}");
    }

    public static void PrintArray(int[] array) // Arrays are reference types
    {
        foreach (int a in array)
        {
            Console.Write($"{a} ");
        }

        Console.WriteLine();
    }

    public static void Clear(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 0;
        }
    }

    public static void
        SetHealth(string status2,
            bool isHealthy) // this is updating the local version of the variable that is being passed in
    {
        status2 = (isHealthy ? "Healthy" : "Unhealthy");
        Console.WriteLine($"Middle: {status2}");
    }

    // this works with global variable that does not need to be passes, so it can update the value directly
    // public static void CorrectSetHealth(bool isHealthy) 
    // {
    //     status = (isHealthy ? "Healthy" : "Unhealthy");
    //     Console.WriteLine($"Middle: {status}");
    // }

    static string[] guestList = { "Rebecca", "Nadia", "Noor", "Jonte" };
    static string[] rsvps = new string[10];
    static int count = 0;

    public static void RSVP(string name, int partySize = 1, string allergies = "none", bool inviteOnly = true)
    {
        if (inviteOnly)
        {
            bool found = false;
            foreach (string guest in guestList)
            {
                if (guest.Equals(name))
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Sorry, {name} is not on the guest list");
                return;
            }
        }

        rsvps[count] = $"Name: {name}, \tParty Size: {partySize}, \tAllergies: {allergies}";
        count++;
    }

    public static void ShowRSVPs()
    {
        Console.WriteLine("\nTotal RSVPs:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(rsvps[i]);
        }
    }

    public static void DisplayEmail()
    {
        string[,] corporate =
        {
            { "Robert", "Bavin" }, { "Simon", "Bright" },
            { "Kim", "Sinclair" }, { "Aashrita", "Kamath" },
            { "Sarah", "Delucchi" }, { "Sinan", "Ali" }
        };

        string[,] external =
        {
            { "Vinnie", "Ashton" }, { "Cody", "Dysart" },
            { "Shay", "Lawrence" }, { "Daren", "Valdes" }
        };

        string externalDomain = "hayworth.com";

        for (int i = 0; i < corporate.GetLength(0); i++)
        {
            BuildEmail(first: corporate[i, 0], last: corporate[i, 1]);
        }

        for (int i = 0; i < external.GetLength(0); i++)
        {
            BuildEmail(first: external[i, 0], last: external[i, 1], domain: externalDomain);
        }
    }

    public static void BuildEmail(string first, string last, string domain = "contoso.com")
    {
        string email = first.Substring(0, 2) + last;
        email = email.ToLower();
        Console.WriteLine($"{email}@{domain}");
    }

    public static int add(int a, int b)
    {
        return a + b;
    }


    static double total = 0;
    static double minimumSpend = 30.00;

    static double[] items = { 15.97, 3.50, 12.25, 22.99, 10.98 };
    static double[] discounts = { 0.30, 0.00, 0.10, 0.20, 0.50 };

    public static void CalculateDiscount()
    {
        for (int i = 0; i < items.Length; i++)
        {
            total += GetDiscountedPrice(i);
        }

        total -= TotalMeetsMinimum() ? 5.00 : 0.00;

        Console.WriteLine($"Total: ${FormatDecimal(total)}");
    }

    public static double GetDiscountedPrice(int itemIndex)
    {
        return items[itemIndex] * (1 - discounts[itemIndex]);
    }

    public static bool TotalMeetsMinimum()
    {
        return total >= minimumSpend;
    }

    public static string FormatDecimal(double input)
    {
        return input.ToString().Substring(0, 5);
    }

    public static string ReverseWord(string word)
    {
        string result = "";
        for (int i = word.Length - 1; i >= 0; i--)
        {
            result += word[i];
        }

        return result;
    }

    public static string ReverseSentence(string input)
    {
        string result = "";
        string[] words = input.Split(" ");

        foreach (string word in words)
        {
            result += ReverseWord(word) + " ";
        }

        return result.Trim();
    }

    static int target = 30;
    static int[] coins = new int[] {5, 5, 50, 25, 25, 10, 5};
    static int[,] result = MethodsWithParameters.TwoCoins(coins, target);
    public static void PrintChange()
    {
        if (result.Length == 0) 
        {
            Console.WriteLine("No two coins make change");
        } 
        else 
        {
            Console.WriteLine("Change found at positions:");
            for (int i = 0; i < result.GetLength(0); i++) 
            {
                if (result[i,0] == -1) 
                {
                    break;
                }
                Console.WriteLine($"{result[i,0]},{result[i,1]}");
            }
        }
    }

    public static int[,] TwoCoins(int[] coins, int target) 
    {
        int[,] result = {{-1,-1},{-1,-1},{-1,-1},{-1,-1},{-1,-1}};
        int count = 0;

        for (int curr = 0; curr < coins.Length; curr++) 
        {
            for (int next = curr + 1; next < coins.Length; next++) 
            {
                if (coins[curr] + coins[next] == target) 
                {
                    result[count, 0] = curr;
                    result[count, 1] = next;
                    count++;
                }
                if (count == result.GetLength(0)) 
                {
                    return result;
                }
            }
        }
        return (count == 0) ? new int[0,0] : result;
    }

    public static void MiniGame()
    {
        Random random = new Random();

        Console.WriteLine("Would you like to play? (Y/N)");
        if (ShouldPlay()) 
        {
            PlayGame();
        }

        void PlayGame() 
        {
            var play = true;

            while (play) 
            {
                var target = GetTarget();
                var roll = RollDice();

                Console.WriteLine($"Roll a number greater than {target} to win!");
                Console.WriteLine($"You rolled a {roll}");
                Console.WriteLine(WinOrLose(target, roll));
                Console.WriteLine("\nPlay again? (Y/N)");

                play = ShouldPlay();
            }
        }

        bool ShouldPlay()
        {
            string result = Console.ReadLine();
            if (result.ToLower() == "y")
            {
                return true;
            }
            return false;
            
        }

        string WinOrLose(int rollTarget, int diceRoll)
        {
            if (diceRoll > rollTarget)
            {
                return "You Win";
            }
            return "Sorry, You Lose";
            
        }
        int GetTarget() 
        {
            return random.Next(1, 6);
        }

        int RollDice() 
        {
            return random.Next(1, 7);
        }
    }
}