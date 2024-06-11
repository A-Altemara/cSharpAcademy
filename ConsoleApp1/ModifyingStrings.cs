using System.Threading.Channels;

namespace ConsoleApp1;

public class ModifyingStrings
{
    public static void IndixOfAndSubString()
    {
        string message = "Find what is (inside the parentheses)";
        
        int openingPosition = message.IndexOf('(');
        int closingPosition = message.IndexOf(')');
        
        openingPosition += 1;
        
        int length = closingPosition - openingPosition;
        Console.WriteLine(message.Substring(openingPosition, length));
        
        
        string message2 = "What is the value <span>between the tags</span>?";
        
        int openingPosition2 = message2.IndexOf("<span>");
        int closingPosition2 = message2.IndexOf("</span>");
        
        openingPosition2 += 6;
        int length2 = closingPosition2 - openingPosition2;
        Console.WriteLine(message2.Substring(openingPosition2, length2));
        
        string message3 = "What is the value <span>between the tags</span>?";

        const string openSpan = "<span>"; // these define the variables and avoid missspellings with multiple variable uses.
        const string closeSpan = "</span>";

        int openingPosition3 = message3.IndexOf(openSpan);
        int closingPosition3 = message3.IndexOf(closeSpan);

        openingPosition3 += openSpan.Length;
        int length3 = closingPosition3 - openingPosition3;
        Console.WriteLine(message3.Substring(openingPosition3, length3));
    }

    public static void IndexOFAnyAndLastIndexOf()
    {
        string message = "(What if) I am (only interested) in the last (set of parentheses)?";
        int openingPosition = message.LastIndexOf('(');
        
        openingPosition += 1;
        int closingPosition = message.LastIndexOf(')');
        int length = closingPosition - openingPosition;
        Console.WriteLine(message.Substring(openingPosition, length));
        
        string message2 = "(What if) there are (more than) one (set of parentheses)?";
        while (true)
        {
            int openingPosition2 = message2.IndexOf('(');
            if (openingPosition2 == -1) break;
        
            openingPosition2 += 1;
            int closingPosition2 = message2.IndexOf(')');
            int length2 = closingPosition2 - openingPosition2;
            Console.WriteLine(message2.Substring(openingPosition2, length2));
        
            // Note the overload of the Substring to return only the remaining 
            // unprocessed message:
            message2 = message2.Substring(closingPosition2 + 1);
        }
        
        string message3 = "Help (find) the {opening symbols}";
        Console.WriteLine($"Searching THIS Message: {message3}");
        char[] openSymbols = { '[', '{', '(' };
        int startPosition3 = 5;
        int openingPosition3 = message3.IndexOfAny(openSymbols);
        Console.WriteLine($"Found WITHOUT using startPosition: {message3.Substring(openingPosition3)}");
        
        openingPosition = message3.IndexOfAny(openSymbols, startPosition3);
        Console.WriteLine($"Found WITH using startPosition {startPosition3}:  {message3.Substring(openingPosition)}");
        
        
        string message4 = "(What if) I have [different symbols] but every {open symbol} needs a [matching closing symbol]?";

        // The IndexOfAny() helper method requires a char array of characters. 
        // You want to look for:
        char[] openSymbols4 = { '[', '{', '(' };

        // You'll use a slightly different technique for iterating through the characters in the string. This time, use the closing 
        // position of the previous iteration as the starting index for the next open symbol. So, you need to initialize the closingPosition 
        // variable to zero:

        int closingPosition4 = 0;

        while (true)
        {
            int openingPosition4 = message4.IndexOfAny(openSymbols4, closingPosition4);

            if (openingPosition4 == -1) break;

            string currentSymbol = message4.Substring(openingPosition4, 1);

            // Now  find the matching closing symbol
            char matchingSymbol = ' ';

            switch (currentSymbol)
            {
                case "[":
                    matchingSymbol = ']';
                    break;
                case "{":
                    matchingSymbol = '}';
                    break;
                case "(":
                    matchingSymbol = ')';
                    break;
            }

            // To find the closingPosition, use an overload of the IndexOf method to specify 
            // that the search for the matchingSymbol should start at the openingPosition in the string. 

            openingPosition4 += 1;
            closingPosition4 = message4.IndexOf(matchingSymbol, openingPosition4);

            // Finally, use the techniques you've already learned to display the sub-string:

            int length4 = closingPosition4 - openingPosition4;
            Console.WriteLine(message4.Substring(openingPosition4, length4));
        }
        
    }

    public static void RemoveAndReplace()
    {
        string data = "12345John Smith          5000  3  ";
        string updatedData = data.Remove(5, 20);
        Console.WriteLine(updatedData);
        
        string message = "This--is--ex-amp-le--da-ta";
        message = message.Replace("--", " ");
        message = message.Replace("-", "");
        Console.WriteLine(message);
    }

    public static void Challenge1()
    {
        // desired output
        // Quantity: 5000
        // Output: <h2>Widgets &reg;</h2><span>5000</span>
        string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

        string quantity = "Quantity: ";
        string output = "Output: ";
        
        const string openSpan = "<span>";
        const string closeSpan = "</span>";
        
        var quantityStart = input.IndexOf(openSpan, StringComparison.Ordinal);
        var quantityEnd = input.IndexOf(closeSpan, StringComparison.Ordinal);
        quantityStart += openSpan.Length;
        var quantityLength = quantityEnd - quantityStart;
        quantity += input.Substring(quantityStart, quantityLength);

        const string tradeSymbol = "&trade";
        const string regsymbol = "&reg";
        input = input.Replace(tradeSymbol, regsymbol);

        var divStarter = input.IndexOf("<div>", StringComparison.Ordinal);
        var divEnder = input.IndexOf("</div>", StringComparison.Ordinal);
        divStarter += 5;
        var length = divEnder - divStarter;
        output += input.Substring(divStarter, length);

        Console.WriteLine(quantity);
        Console.WriteLine(output);
    }
}