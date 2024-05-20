namespace ConsoleApp1;

static class Readable
{
    public static void CreatingComments()
    {
        string firstName = "Bob";
        int widgetsPurchased = 7;
        // Testing change to the message.
        // int widgetsSold = 7;
        // Console.WriteLine($"{firstName} sold {widgetsSold} widgets.");
        Console.WriteLine($"{firstName} sold {widgetsPurchased} widgets.");

        /* The following is a bad example of commenting code. It over explains the functions like Random.
        Random randomNumberGenerator = new Random();
        string[] orderIDs = new string[5];
        // Loop through each blank orderID
        for (int i = 0; i < orderIDs.Length; i++)
        {
            // Get a random value that equates to ASCII letters A through E
            int prefixValue = randomNumberGenerator.Next(65, 70);
            // convert the random value to a char, then a string
            string prefix = Convert.ToChar(prefixValue).ToString();
            // create a random number, pad with zeroes
            string suffix = randomNumberGenerator.Next(1, 1000).ToString("000");
            // combine the prefix and suffix together, then assign to current OrderID
            orderIDs[i] = prefix + suffix;
        }
        // print out each orderID
        foreach (var orderID in orderIDs)
        {
            Console.WriteLine(orderID);
        }
        */
        
        // A better commented code would look like the following
        /*
         * THe folliwing code creates 5 random OrderIDs to test the fraud detection process
         * OrderIDs consist of a letter fro A to E, and a three-digit number. Ex: A123.
         */
        Random randomNumberGenerator = new Random();
        string[] orderIDs = new string[5];
        for (int i = 0; i < orderIDs.Length; i++)
        {
            int prefixValue = randomNumberGenerator.Next(65, 70);
            string prefix = Convert.ToChar(prefixValue).ToString();
            string suffix = randomNumberGenerator.Next(1, 1000).ToString("000");
            orderIDs[i] = prefix + suffix;
        }
        foreach (var orderID in orderIDs)
        {
            Console.WriteLine(orderID);
        }
        
    }

    public static void WhiteSpace()
    {
        Random dice = new Random();
        int roll1 = dice.Next(1, 7);
        int roll2 = dice.Next(1, 7);
        int roll3 = dice.Next(1, 7);
        
        int total = roll1 + roll2 + roll3;
        Console.WriteLine($"Dice Roll: {roll1} + {roll2} + {roll3}");
 
        if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
        {
            if ((roll1 == roll2) && (roll2 == roll3))
            {
                Console.WriteLine("You rolled tripples! +6 bonus to total!");
                total += 6;
            }
            else
            {
                Console.WriteLine("You Rolled DOubles! +2 bonus to total");
                total += 2;
            }
        }
    }

    public static void ReabilityUpdate()
    {
        /*
         THe following was an example to base the bellow correction on:
        string str = "The quick red fox jumps over the lazy brown dog";
        // convert message to a char array
        char[] charMessage = str.ToCharArray();
        // Reverse the chars
        Array.Reverse(charMessage);
        int x = 0;
        // count the o's
        foreach (var i in charMessage) if (i =='o')  x++;
        // convert back to a string.
        string new_message = new String(charMessage);
        // print it out
        Console.WriteLine(new_message);
        Console.WriteLine($"'o' appears {x} times.");
        */
        
        // Reverses string, counts the number of times a specific char appears in it.
        // It displays the results in the console
       
        string originalMessage = "The quick red fox jumps over the lazy brown dog";

        char[] message = originalMessage.ToCharArray();
        Array.Reverse(message);
        
        int letterCount = 0;
        foreach ( char letter in message)
        {
            if (letter == 't' || letter == 'T')
            {
                letterCount++;
            }
        }
        
        string newMessage = new String(message);

        Console.WriteLine(newMessage);
        Console.WriteLine($"'t' appears {letterCount} times.");
        

    }
}