namespace ConsoleApp1;

static class ArraysForEach
{
    public static void LearnArrays()
    {
        string[] fraudelentOrderIds = new string[3];
        fraudelentOrderIds[0] = "A123";
        fraudelentOrderIds[1] = "B456";
        fraudelentOrderIds[2] = "C789";
        // fraudelentOrderIds[3] = "C789"; outside of bounds of array
        
        Console.WriteLine($"Second: {fraudelentOrderIds[1]}");

        string[] fraudelentOrderIds1 = { "a123", "b456", "c789" };
        Console.WriteLine($"Second declariation: {fraudelentOrderIds1[0]}");
        fraudelentOrderIds1[0] = "f00";
        Console.WriteLine($"reassign: {fraudelentOrderIds1[0]}");
        
        Console.WriteLine($"There are {fraudelentOrderIds1.Length} elements in this array");
    }

    public static void LearnForEach()
    {
        int[] inventory = [200, 450, 700, 175, 250];
        int sum = 0;
        int bin = 0;
        foreach (int items in inventory)
        {
            sum += items;
            bin++;
            Console.WriteLine($"Bin {bin} = {items} items (running total: {sum})");
        }
        Console.WriteLine($"We have {sum} items in inventory");
    }

    public static void UseForEach()
    {
        string[] orderList = ["b123", "c234", "a345", "c15", "b177", "g3003", "c234", "b179"];
         
        foreach (var orderNumber in orderList)
        {
            // if (orderNumber.StartsWith('b'))
            if (orderNumber[0] == 'b')
            {
                Console.Write($"{orderNumber} ");
                fraudCheck.Add(orderNumber);
            }
        }

        Console.WriteLine();
        Console.WriteLine(fraudCheck);
        
        var fraudCheck2 = orderList.Where(order => order.StartsWith("b"));
        Console.WriteLine(string.Join(',',fraudCheck2));
        List<object> things = [0, 1.5, "Hellow World!", new List<int> { 1, 2, 3 }];
    }
}