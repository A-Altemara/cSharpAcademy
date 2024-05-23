namespace ConsoleApp1;

static class BooleanExpressions
{
    
    public static void EvaluatingExpressions()
    {
        // Console.WriteLine("a" == "a");
        // Console.WriteLine("a" != "A");
        // Console.WriteLine( 1 != 2 );
        
        // string value1 = "a ";
        // string value2 = " A";
        // Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());

        // Console.WriteLine( 1 < 2 );
        // Console.WriteLine( 1 > 2 );
        // Console.WriteLine( 1 >= 1 );
        // Console.WriteLine( 1 <= 2 );
        
        // string pangram = "The quick brown fox jumps over the lazy dog.";
        // Console.WriteLine( pangram.Contains("fox") );
        // Console.WriteLine( !pangram.Contains("cow") );

        // Ternary structure
        // <evaluate this expression> ? <if condition is true, return this value> : <if condition is false, return this value>
        // Apply a $100 discount or orders above 1000 and $50 on orders less than 1000
        // int saleAmount = 50;
        // int discount = saleAmount > 1000 ? 100 : ( saleAmount < 1000 && saleAmount > 200 ? 50 : 10);
        
        // Console.WriteLine($"Discount : {discount}");
        // Console.WriteLine($"Discount : {(saleAmount > 1000 ? 100 : 50)}");

        Random random = new();
        int coinFlip = random.Next(0, 2);
        Console.WriteLine($"Coin Flip Result: {(coinFlip == 1 ? "heads" : "Tails")}");

        // string permission = "Employee";
        // string permission = "Manager";
        string permission = "Admin";
        int level = 58;

        // if (permission.Contains("Admin"))
        // {
        //     Console.WriteLine($"{(level > 55 ? "Welcome, Super Admin User" : "Welcome, Admin User")}");
        //     // if (level > 55)
        //     // {
        //     //     Console.WriteLine("Welcome, Super Admin User");
        //     // }
        //     // else
        //     // {
        //     //     Console.WriteLine("Welcome, Admin User");
        //     // }
        // } else if (permission.Contains("Manager"))
        // {
        //     Console.WriteLine($"{(level >= 20 ? "Contact Admin for Access" : "You do not have sufficient privileges")}");
        // } else
        // {
        //     Console.WriteLine("You do not have sufficient privileges");
        //
        // }
        
        if (permission.Contains("Admin") && level > 55)
        {
            Console.WriteLine($"Welcome, Super Admin User");
            
        }
        else if (permission.Contains("Admin") && level <= 55)
        {
            Console.WriteLine($"Welcome, Admin User");
            
        } else if (permission.Contains("Manager") && level >= 20)
        {
            Console.WriteLine($"Contact Admin for Access");
        } else
        {
            Console.WriteLine("You do not have sufficient privileges");
   
        }
        
    }
}