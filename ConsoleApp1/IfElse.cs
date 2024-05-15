namespace ConsoleApp1;

static class IfElse
{
    public static void PlayGame()
    {
        Random dice = new Random();

        int roll1 = dice.Next(1, 7);
        int roll2 = dice.Next(1, 7);
        int roll3 = dice.Next(1, 7);

        int total = roll1 + roll2 + roll3;

        Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

        if ((roll1 == roll2) && (roll2 == roll3))
        {
            Console.WriteLine("You rolled Triples! +6 bonus to the total");
            total += 6;
        }
        else if ((roll1 == roll2) || (roll1 == roll3) || (roll2 == roll3))
        {
            Console.WriteLine("You rolled doubles! +2 bonus to the total");
            total += 2;
        }
        
        if (total >= 15)
        {
            Console.WriteLine($"You Win! Final total {total}");
        }
        else
        {
            Console.WriteLine($"Sorry, You Lose. Final total {total}");
        }
    }

    public static void RenewSubscription()
    {
        Random random = new Random();
        int daysUntilExpiration = random.Next(12);
        int discountPercentage = 0;
        // Console.WriteLine(daysUntilExpiration);

        if (daysUntilExpiration > 10)
        {
            return;
        } else if (daysUntilExpiration == 0)
        {
            Console.WriteLine("Your Subscription has expired.");
        }
        else if (daysUntilExpiration == 1)
        {
            Console.WriteLine($"Your Subscription expires with a day!");
            discountPercentage = 20;
            Console.WriteLine($"Renew now and save {discountPercentage}%");
        }
        else if (daysUntilExpiration <= 5)
        {
            Console.WriteLine($"Your Subscription expires with {daysUntilExpiration} days.");
            discountPercentage = 10;
            Console.WriteLine($"Renew now and save {discountPercentage}%");
        } else
        {
            Console.WriteLine("Your Subscription expires soon. Renew Now!");
        }
    }
}