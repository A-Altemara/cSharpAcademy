namespace ConsoleApp1;

public class CastingDataTypes
{
    public static void ExploringCasting()
    {
        int first = 2;
        string second = "4";
        // Console.WriteLine(first + second);
        // Console.WriteLine(first + (int)second); fails because complier can't cast string to an int

        int myInt = 3;
        // Console.WriteLine($"int: {myInt}");
        decimal myDecimal = myInt; // this widens the data making it larger so the int can easily "fit" in the decimal.
        // Console.WriteLine($"decimal: {myDecimal}");
        
        decimal myDecimal2 = 3.14m;
        // Console.WriteLine($"myDecimal2: {myDecimal2}");
        decimal  myInt2 = (int)myDecimal2; // this widens the data making it larger so the int can easily "fit" in the decimal.
        // Console.WriteLine($"decimal2: {myInt2}");

        decimal myDecimal3 = 1.23456789m;
        float myFloat = (float)myDecimal3;
        // Console.WriteLine($"Decimal3: {myDecimal3}");
        // Console.WriteLine($"Float: {myFloat}");

        int third = 5;
        int fourth = 7;
        // Console.WriteLine(third.ToString() + fourth.ToString());

        string prime = "5";
        string secund = "7";
        int sum = int.Parse(prime) + int.Parse(secund);
        // Console.WriteLine(sum);

        string value1 = "5";
        string value2 = "7";
        // Console.WriteLine(Convert.ToInt32(value1) * Convert.ToInt32(value2));

        int value3 = (int)1.5m; // casting trucates
        // Console.WriteLine(value3);

        int value4 = Convert.ToInt32(1.5m); // converting rounds up
        // Console.WriteLine(value4);

        string value5 = "102";
        int result = 0;
        if (int.TryParse(value5, out result))
        {
            Console.WriteLine($"Measurement: {result}");
        } 
        else 
        {
            Console.WriteLine("Unable to report the measurement");
        }
    }

    public static void CombiningTypes()
    {
        string[] values = { "12.3", "45", "ABC", "11", "DEF" };
        string phrase = "";
        decimal total = 0.0m;

        for (int i = 0; i < values.Length; i++)
        {
            decimal number;

            var result = decimal.TryParse(values[i], out number);
            if (result)
            {
                total += (decimal)number;
            }
            else
            {
                phrase += values[i];
            }
        }
        

        Console.WriteLine($"Message: {phrase}");
        Console.WriteLine($"Total: {total}");
    }

    public static void TypeScope()
    {
        int value1 = 11;
        decimal value2 = 6.2m;
        float value3 = 4.3f;

        int result1 = Convert.ToInt32(value1 / value2);
        Console.WriteLine($"Divide value1 by value2, display the result as an int: {result1}");

        decimal result2 = value2 / (decimal)value3;
        Console.WriteLine($"Divide value2 by value3, display the result as a decimal: {result2}");

        float result3 = value3 / value1;
        Console.WriteLine($"Divide value3 by value1, display the result as a float: {result3}");
        
        
    }
}