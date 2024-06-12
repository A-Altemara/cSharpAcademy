namespace ConsoleApp1;

public static class VariableDataChallenge
{
    public static void Challenge1()
    {
        // #1 the ourAnimals array will store the following: 
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";
        string suggestedDonation = "";

        // #2 variables that support data entry
        int maxPets = 8;
        string? readResult;
        string menuSelection = "";
        decimal decimalDonation = 0.0m;

        // #3 array used to store runtime data, there is no persisted data
        string[,] ourAnimals = new string[maxPets, 7];

        // #4 create sample data ourAnimals array entriesÒ
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription =
                        "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                    animalPersonalityDescription =
                        "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    suggestedDonation = "85.00";
                    break;

                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription =
                        "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription =
                        "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "gus";
                    suggestedDonation = "49.99";
                    break;

                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "snow";
                    suggestedDonation = "40.00";
                    break;

                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "3";
                    animalPhysicalDescription =
                        "Medium sized, long hair, yellow, female, about 10 pounds. Uses litter box.";
                    animalPersonalityDescription = "A people loving cat that likes to sit on your lap.";
                    animalNickname = "Lion";
                    suggestedDonation = "";
                    break;

                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    suggestedDonation = "";
                    break;
            }

            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "Species: " + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

            if (!decimal.TryParse(suggestedDonation, out decimalDonation))
            {
                decimalDonation = 45.00m; // if suggested is not a number default to 45.00
            }

            ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
        }


        // #5 display the top-level menu options
        do
        {
            // NOTE: the Console.Clear method is throwing an exception in debug sessions
            Console.Clear();

            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Display all dogs with a specified characteristic");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            // use switch-case to process the selected menu option
            switch (menuSelection)
            {
                case "1":
                    // list all pet info
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 7; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j]);
                            }
                        }
                    }

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "2":
                    // Display all dogs with a specified characteristic
                    string dogCharacteristic = "";
                    string dogDescription = "";

                    while (dogCharacteristic == "")
                    {
                        // have the user enter physical characteristics to search for
                        Console.WriteLine($"\nEnter one desired dog characteristics to search for");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            dogCharacteristic = readResult.ToLower().Trim();
                        }
                    }


                    bool noMatchesDog = true;

                    // #6 loop through the ourAnimals array to search for matching animals
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 1].Contains("dog"))
                        {
                            // #7 Search combined descriptions and report results
                            dogDescription = ourAnimals[i, 4] + "/n" + ourAnimals[i, 5];
                            if (dogDescription.Contains(dogCharacteristic))
                            {
                                Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match");
                                Console.WriteLine(dogDescription);
                                noMatchesDog = false;
                            }
                        }
                    }

                    if (noMatchesDog)
                    {
                        Console.WriteLine("None of our dogs are a match for " + dogCharacteristic);
                    }

                    Console.WriteLine("Press the Enter key to continue.");
                    readResult = Console.ReadLine();
                    break;

                default:
                    break;
            }
        } while (menuSelection != "exit");
    }

    public static void Challenge2()
    {
        // ourAnimals array will store the following: 
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";
        string suggestedDonation = "";

        // variables that support data entry
        int maxPets = 8;
        string? readResult;
        string menuSelection = "";
        decimal decimalDonation = 0.00m;

        // array used to store runtime data
        string[,] ourAnimals = new string[maxPets, 7];

        // sample data ourAnimals array entries
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription =
                        "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
                    animalPersonalityDescription =
                        "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    suggestedDonation = "85.00";
                    break;

                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription =
                        "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription =
                        "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "gus";
                    suggestedDonation = "49.99";
                    break;

                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "snow";
                    suggestedDonation = "40.00";
                    break;

                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "lion";
                    suggestedDonation = "";

                    break;

                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    suggestedDonation = "";
                    break;
            }

            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "Species: " + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

            if (!decimal.TryParse(suggestedDonation, out decimalDonation))
            {
                decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
            }

            ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
        }

        // top-level menu options
        do
        {
            // NOTE: the Console.Clear method is throwing an exception in debug sessions
            Console.Clear();

            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Display all dogs with a specified characteristic");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            // switch-case to process the selected menu option
            switch (menuSelection)
            {
                case "1":
                    // list all pet info
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (ourAnimals[i, 0] != "ID #: ")
                        {
                            Console.WriteLine();
                            for (int j = 0; j < 7; j++)
                            {
                                Console.WriteLine(ourAnimals[i, j].ToString());
                            }
                        }
                    }

                    Console.WriteLine("\r\nPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                case "2":
                    // #1 Display all dogs with a multiple search characteristics

                    string dogCharacteristic = "";
                    string[] dogSearchTerms = new string[] { };
                    bool noMatchesDog = true;
                    string dogDescription = "";

                    while (dogCharacteristic == "")
                    {
                        // #2 have user enter multiple comma separated characteristics to search for
                        Console.WriteLine(
                            $"\r\nEnter your desired dog characteristic to search for separated by commas");
                        readResult = Console.ReadLine();

                        if (readResult == null) continue;
                        dogSearchTerms = readResult.ToLower().Trim().Split(",");
                        Array.Sort(dogSearchTerms);
                        Console.WriteLine();
                        dogCharacteristic = readResult;
                    }

                    // #4 update to "rotating" animation with countdown
                    string[] searchingIcons = ["|", "/", "--", @"\", "*"];

                    // loop ourAnimals array to search for matching animals
                    for (int i = 0; i < maxPets; i++)
                    {
                        if (!ourAnimals[i, 1].Contains("dog"))
                        {
                            continue;
                        }

                        // Search combined descriptions and report results
                        dogDescription = ourAnimals[i, 4] + "\r\n" + ourAnimals[i, 5];

                        for (int j = 3; j > -1; j--)
                        {
                            // #5 update "searching" message to show countdown 
                            foreach (string icon in searchingIcons)
                            {
                                Console.Write(
                                    $"\rsearching our dog {ourAnimals[i, 3]} for {dogCharacteristic} {icon,-2} {j}");
                                Thread.Sleep(250);
                            }

                            Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                        }
                            
                        bool thisDog = false;
                        // #3a iterate submitted characteristic terms and search description for each term
                        foreach (var term in dogSearchTerms)
                        {
                                
                            if (dogDescription.Contains(term))
                            {
                                // #3b update message to reflect term 
                                // #3c set a flag "this dog" is a match
                                Console.WriteLine($"Our dog {ourAnimals[i, 3]} is a match to your search for {term}!");

                                thisDog = true;
                                noMatchesDog = false;
                            }
                        }

                        // #3d if "this dog" is match write match message + dog description
                        if (thisDog)
                        {
                            Console.WriteLine($"{ourAnimals[i,3]} ({i,0}).\n{dogDescription}");   
                        }
                    }

                    if (noMatchesDog)
                    {
                        Console.WriteLine("None of our dogs are a match found for: " + dogCharacteristic);
                    }

                    Console.WriteLine("\n\rPress the Enter key to continue");
                    readResult = Console.ReadLine();

                    break;

                default:
                    break;
            }
        } while (menuSelection != "exit");
    }
}