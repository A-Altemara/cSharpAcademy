namespace ConsoleApp1;

static class Switches
{
    public static void ImplementSwitch()
    {
        int employeeLevel = 170;
        string employeeName = "John Smith";

        string title = "";

        switch (employeeLevel)
        {
            case 100:
            case < 200:
                title = "Senior Associate";
                break;
            case < 300:
                title = "Manager";
                break;
            case < 400:
                title = "Senior Manager";
                break;
            default:
                title = "Associate";
                break;
        }

        Console.WriteLine($"{employeeName}, {title}");
    }

    public static void ChallengeSwitch()
    {
        // SKU = Stock Keeping Unit. 
        // SKU value format: <product #>-<2-letter color code>-<size code>
        string sku = "01-MN-L";

        string[] product = sku.Split('-');

        string type = "";
        string color = "";
        string size = "";

        switch (product[0])
        {
            case "01":
                type = "Sweat shirt";
                break;
            case "02":
                type = "T-Shirt";
                break;
            case "03":
                type = "Sweat pants";
                break;
            default:
                type = "Other";
                break;
        }

        color = product[1] switch
        {
            "BL" => "Black",
            "MN" => "Maroon",
            _ => "White"
        };

        size = product[2] switch
        {
            "S" => "Small",
            "M" => "Medium",
            "L" => "Large",
            _ => "One Size Fits All"
        };

        Console.WriteLine($"Product: {size} {color} {type}");
    }
}

