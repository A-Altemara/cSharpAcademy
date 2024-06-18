using System.Collections.Concurrent;

namespace ConsoleApp1;

public static class CreatingMethods
{
    public static void DisplayRandomNumbers()
    {
        Random random = new();
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"{random.Next(1, 100)} ");
        }

        Console.WriteLine();
    }

    public static void AvoidDuplications()
    {
        int[] times = { 800, 1200, 1600, 2000 };
        int diff = 0;

        Console.WriteLine("Enter current GMT");
        int currentGMT = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Current Medicine Schedule:");

        /* Format and display medicine times */
        TimeZoneAdjustment(times);

        Console.WriteLine();

        Console.WriteLine("Enter new GMT");
        int newGMT = Convert.ToInt32(Console.ReadLine());

        if (Math.Abs(newGMT) > 12 || Math.Abs(currentGMT) > 12)
        {
            Console.WriteLine("Invalid GMT");
        }
        else if (newGMT <= 0 && currentGMT <= 0 || newGMT >= 0 && currentGMT >= 0)
        {
            diff = 100 * (Math.Abs(newGMT) - Math.Abs(currentGMT));

            /* Adjust the times by adding the difference, keeping the value within 24 hours */
            AdjustTimeByDifference(times, diff);
        }
        else
        {
            diff = 100 * (Math.Abs(newGMT) + Math.Abs(currentGMT));

            /* Adjust the times by adding the difference, keeping the value within 24 hours */
            AdjustTimeByDifference(times, diff);
            // for (int i = 0; i < times.Length; i++) 
            // {
            //     times[i] = ((times[i] + diff)) % 2400;
            // }
        }

        Console.WriteLine("New Medicine Schedule:");

        /* Format and display medicine times */
        TimeZoneAdjustment(times);
        // foreach (int val in times)
        // {
        //     string time = val.ToString();
        //     int len = time.Length;
        //
        //     if (len >= 3)
        //     {
        //         time = time.Insert(len - 2, ":");
        //     }
        //     else if (len == 2)
        //     {
        //         time = time.Insert(0, "0:");
        //     }
        //     else
        //     {
        //         time = time.Insert(0, "0:0");
        //     }
        //
        //     Console.Write($"{time} ");
        // }

        Console.WriteLine();
    }

    private static void AdjustTimeByDifference(int[] times, int diff)
    {
        for (int i = 0; i < times.Length; i++)
        {
            times[i] = ((times[i] + diff)) % 2400;
        }
    }

    private static void TimeZoneAdjustment(int[] times)
    {
        foreach (int val in times)
        {
            string time = val.ToString();
            int len = time.Length;

            if (len >= 3)
            {
                time = time.Insert(len - 2, ":");
            }
            else if (len == 2)
            {
                time = time.Insert(0, "0:");
            }
            else
            {
                time = time.Insert(0, "0:0");
            }

            Console.Write($"{time} ");
        }
    }

    public static void CheckIPAddress()
    {
        // string ipv4Input = "107.31.1.257";
        string[] ipv4Input = {"107.31.1.5", "255.0.0.255", "555..0.555", "255...255"};

        foreach (var input in ipv4Input)
        {
            string[] address = input.Split(".", StringSplitOptions.RemoveEmptyEntries);

            if (ValidateLength(address) && ValidateZeroes(address) && ValidateRange(address))
            {
                Console.WriteLine($"{input} is a valid IPv4 address");
            }
            else
            {
                Console.WriteLine($"{input} is an invalid IPv4 address");
            }
        }
    }

    private static bool ValidateLength(string[] address)
    {
        return address.Length == 4;

        // var validLength = address.Length == 4;
        // return validLength;
    }


    private static bool ValidateZeroes(string[] address)
    {
        foreach (string number in address)
        {
            if (number.Length > 1 && number.StartsWith('0'))
            {
                return false;
            }
        }

        return true;
    }

    private static bool ValidateRange(string[] address)
    {
        foreach (string number in address)
        {
            if (!int.TryParse(number, out int value) || 
                value < 0 || value > 255)
            {
                return false;
            }
        }

        return true;
    }

    public static void TellFortune()
    {
        Random random = new Random();
        int luck = random.Next(100);

        string[] text = {"You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to"};
        string[] good = {"look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!"};
        string[] bad = {"fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life."};
        string[] neutral = {"appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature."};

        DisplayFortune(luck, good, bad, neutral, text);
        
        void DisplayFortune(int luck1, string[] strings, string[] bad1, string[] neutral1, string[] text1)
        {
            Console.WriteLine("A fortune teller whispers the following words:");
            string[] fortune = (luck1 > 75 ? strings : (luck1 < 25 ? bad1 : neutral1));
            for (int i = 0; i < 4; i++) 
            {
                Console.Write($"{text1[i]} {fortune[i]} ");
            }
        }

    }
}