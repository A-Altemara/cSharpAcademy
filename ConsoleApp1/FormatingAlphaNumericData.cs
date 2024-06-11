using System.Text;

namespace ConsoleApp1;

static class FormatingAlphaNumericData
{
    public static void StringFormatingBasics()
    {
        decimal price = 123.45m;
        int discount = 50;
        Console.WriteLine($"Price: {price:C} (Save {discount:C})");
        
        decimal measurement = 123456.78912m;
        Console.WriteLine($"Measurement: {measurement:N} units");
    }

    public static void ExplorStingInterpolation()
    {
        int invoiceNumber = 1201;
        decimal productShares = 25.4568m;
        decimal subtotal = 2750.00m;
        decimal taxPercentage = .15825m;
        decimal total = 3185.19m;

        Console.WriteLine($"Invoice Number: {invoiceNumber}");
        Console.WriteLine($"   Shares: {productShares:N3} Product");
        Console.WriteLine($"     Subtotal: {subtotal:C}");
        Console.WriteLine($"           Tax: {taxPercentage:P2}");
        Console.WriteLine($"     Total Billed: {total:C}");
    }

    public static void PaddingAndAlignment()
    {
        // string input = "Pad this";
        // Console.WriteLine(input.PadLeft(12));
        // Console.WriteLine(input.PadRight(12));
        // Console.WriteLine(input.PadLeft(12, '-'));
        // Console.WriteLine(input.PadRight(12, '-'));
        
        string paymentId = "769C";
        string payeeName = "Mr. Stephen Ortega";
        string paymentAmount = "$5,000.00";

        var formattedLine = paymentId.PadRight(6);
        formattedLine += payeeName.PadRight(24);
        formattedLine += paymentAmount.PadLeft(10);

        Console.WriteLine("1234567890123456789012345678901234567890");
        Console.WriteLine(formattedLine);
    }

    public static void Challenge1()
    {
        
        /*  sample text
           Dear Ms. Barros,
           As a customer of our Magic Yield offering we are excited to tell you about a new financial product that would dramatically increase your return.
           
           Currently, you own 2,975,000.00 shares at a return of 12.75%.
           
           Our new product, Glorious Future offers a return of 13.13%.  Given your current volume, your potential profit would be ¤63,000,000.00.
           
           Here's a quick comparison:
           
           Magic Yield         12.75%   $55,000,000.00      
           Glorious Future     13.13%   $63,000,000.00
           */
        
        string customerName = "Ms. Barros";

        string currentProduct = "Magic Yield";
        int currentShares = 2975000;
        decimal currentReturn = 0.1275m;
        decimal currentProfit = 55000000.0m;

        string newProduct = "Glorious Future";
        decimal newReturn = 0.13125m;
        decimal newProfit = 63000000.0m;

        // could do all the needed words like this
        // Console.WriteLine($"Dear {customerName},\n");
        // Console.WriteLine($"As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.\n");

        // complete solution that allows for whole thing to be output with one instruction.
        var builder = new StringBuilder();

        builder.AppendLine($"Dear {customerName},");
        builder.AppendLine($"As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.\n");
        builder.AppendLine($"Currently, you own {currentShares:N} shares at a return of {currentReturn:P}.\n");
        builder.AppendLine($"Our new product, {newProduct} offers a return of {newReturn:P}.  Given your current volume, your potential profit would be {newProfit:N}.\n");
        builder.AppendLine("Here's a quick comparison:\n");
        builder.AppendLine($"{currentProduct,-21}{currentReturn,-9:P}{currentProfit:C}");
        builder.AppendLine($"{newProduct,-21}{newReturn,-9:P}{newProfit:C}");


        string comparisonMessage = builder.ToString();
        Console.WriteLine(comparisonMessage);
    }
}

