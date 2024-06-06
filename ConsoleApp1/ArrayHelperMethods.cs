using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace ConsoleApp1;

public class ArrayHelperMethods
{
    public static void SortAndReverse()
    {
        string[] pallets = { "B14", "A11", "B12", "A13" };

        Console.WriteLine("Sorted...");
        Array.Sort(pallets);
        foreach (var pallet in pallets)
        {
            Console.WriteLine($"-- {pallet}");
        }

        Console.WriteLine("");
        Console.WriteLine("Reversed...");
        Array.Reverse(pallets);
        foreach (var pallet in pallets)
        {
            Console.WriteLine($"-- {pallet}");
        }
    }

    public static void ClearAndResize()
    {
        string[] pallets = { "B14", "A11", "B12", "A13" };
        Console.WriteLine("");

        Array.Clear(pallets, 0, 2);
        Console.WriteLine($"Clearing 2 ... count: {pallets.Length}");
        foreach (var pallet in pallets)
        {
            Console.WriteLine($"-- {pallet}");
        }

        Console.WriteLine("");
        Array.Resize(ref pallets, 6);
        Console.WriteLine($"Resizing 6 ... count: {pallets.Length}");

        pallets[4] = "C01";
        pallets[5] = "C02";

        foreach (var pallet in pallets)
        {
            Console.WriteLine($"-- {pallet}");
        }
        
        Console.WriteLine("");
        Array.Resize(ref pallets, 3);
        Console.WriteLine($"Resizing 3 ... count: {pallets.Length}");

        foreach (var pallet in pallets)
        {
            Console.WriteLine($"-- {pallet}");
        }
        
    }

    public static void SplitAndJoin()
    {
        string values = "abc123";
        char[] valueArray = values.ToCharArray();
        foreach (var value in valueArray)
        {
            Console.Write(value + " ");
        }

        Console.WriteLine();
        Array.Reverse(valueArray);
        // string result = new (valueArray);
        string result = String.Join(",", valueArray);
        Console.WriteLine(result);
        string[] testArray = { "this is", "the test", "string." };
        string secondResult = String.Join(",", testArray);
        Console.WriteLine(secondResult);
        
        string[] items = result.Split(',');
        foreach (string item in items)
        {
            Console.WriteLine(item);
        }

        string[] secondTestArray = secondResult.Split(',');
        foreach (var entry in secondTestArray)
        {
            Console.WriteLine(entry);
        }
    }

    public static void Challenge1()
    {
        string pangram = "The quick brown fox jumps over the lazy dog";
        var holdingPangram = pangram.Split(" ");
        // var reversePangram = holdingPangram.Reverse();
        // reversePangram = String.Join(" ", reversePangram);
        // foreach (var word in reversePangram)
        // {
        //     Console.Write(word + " ");
        // }

        string reverseSentance = "";
        
        foreach (var entry in holdingPangram)
        {
            // var rev = new string(entry.Reverse().ToArray()); this does the same as the holdingArray and reverse lines in a single line
            // Console.WriteLine($"entry: " + entry);
            char[] holdingArray = entry.ToCharArray();
            Array.Reverse(holdingArray);
            // Console.WriteLine($"reverse: " + new string( holdingArray));
            reverseSentance += new string(holdingArray) + ' ';
        }

        Console.WriteLine(reverseSentance.Trim());
        
    }

    public static void Challenge2()
    {
        string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
        string[] orderIDs = orderStream.Split(",");
        Array.Sort(orderIDs);
        foreach (var OrderID in orderIDs)
        {
            if (OrderID.Length != 4)
            {
                Console.WriteLine($"{OrderID}\t- Error");
            }
            else
            {
                Console.WriteLine(OrderID);
            }
        }
    }
    
}

