using System.Threading.Channels;

namespace ConsoleApp1;

static class SelectionAndIteration
{
    public static void ContosoPets()
    {
        // the ourAnimals array will store the following: 
        string animalSpecies = "";
        string animalID = "";
        string animalAge = "";
        string animalPhysicalDescription = "";
        string animalPersonalityDescription = "";
        string animalNickname = "";

        // variables that support data entry
        int maxPets = 8;
        string? readResult;
        string menuSelection = "";

        // array used to store runtime data, there is no persisted data
        string[,] ourAnimals = new string[maxPets, 6];
        //could also be written:
        ourAnimals[0, 0] = "kitty";
        string[][] ourAnimals2 = new string[maxPets][];
        string[] a1, a2, a3, a4, a5, a6;
        a1 = new string[8];
        a2 = new string[5];
        ourAnimals2[0] = new string[8];

        // TODO: Convert the if-elseif-else construct to a switch statement

        // create some initial ourAnimals array entries
        for (int i = 0; i < maxPets; i++)
        {
            switch (i)
            {
                case 0:
                    animalSpecies = "dog";
                    animalID = "d1";
                    animalAge = "2";
                    animalPhysicalDescription =
                        "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                    animalPersonalityDescription =
                        "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                    animalNickname = "lola";
                    break;
                case 1:
                    animalSpecies = "dog";
                    animalID = "d2";
                    animalAge = "9";
                    animalPhysicalDescription =
                        "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                    animalPersonalityDescription =
                        "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                    animalNickname = "loki";
                    break;
                case 2:
                    animalSpecies = "cat";
                    animalID = "c3";
                    animalAge = "1";
                    animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                    animalPersonalityDescription = "friendly";
                    animalNickname = "Puss";
                    break;
                case 3:
                    animalSpecies = "cat";
                    animalID = "c4";
                    animalAge = "?";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    break;
                default:
                    animalSpecies = "";
                    animalID = "";
                    animalAge = "";
                    animalPhysicalDescription = "";
                    animalPersonalityDescription = "";
                    animalNickname = "";
                    break;
            }

            ourAnimals[i, 0] = "ID #: " + animalID;
            ourAnimals[i, 1] = "Species: " + animalSpecies;
            ourAnimals[i, 2] = "Age: " + animalAge;
            ourAnimals[i, 3] = "Nickname: " + animalNickname;
            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
        }

        // display the top-level menu options
        do
        {
            Console.Clear();

            Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
            Console.WriteLine(" 1. List all of our current pet information");
            Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
            Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
            Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
            Console.WriteLine(" 5. Edit an animal’s age");
            Console.WriteLine(" 6. Edit an animal’s personality description");
            Console.WriteLine(" 7. Display all cats with a specified characteristic");
            Console.WriteLine(" 8. Display all dogs with a specified characteristic");
            Console.WriteLine();
            Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

            readResult = Console.ReadLine();
            if (readResult != null)
            {
                menuSelection = readResult.ToLower();
            }

            var rows = ourAnimals.GetLength(0);
            var cols = ourAnimals.GetLength(1); //index with ourAnimals[row,col]

            switch (menuSelection)
            {
                case "1":
                    Console.WriteLine("\nOur Pets include:");
                    // List all of our current pet information
                    // for could also be declared (int i = 0; i< maxPets, i++) and not need the extra variables rows and cols.

                    // could use pet in place of row and pets in place of rows to be more explicit
                    for (int row = 0; row < rows; row++)
                    {
                        if (ourAnimals[row, 0] != "ID #: ")
                        {
                            // could use characteristic instead of col as above for better readability
                            for (int col = 0; col < cols; col++)
                            {
                                // call would be Console.WriteLine(ourAnimals[pet, characteristic]) using custom variables
                                Console.WriteLine(ourAnimals[row, col]);
                            }

                            Console.WriteLine("");
                        }
                    }

                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                case "2":
                    var animalCount = 0;
                    var anotherPet = "y";
                    for (int row = 0; row < rows; row++)
                    {
                        if (ourAnimals[row, 0] != "ID #: ")
                        {
                            animalCount++;
                        }
                    }

                    if (animalCount < maxPets)
                    {
                        Console.WriteLine($"We currently have {animalCount} pets that need homes. " +
                                          $"We can manager {(maxPets - animalCount)} more.");
                    }
                    else
                    {
                        Console.WriteLine($"We currently have {animalCount} pets that need homes. " +
                                          $"We cannot manage another pet. Please check back later");
                        anotherPet = "n";
                    }

                    while (anotherPet == "y" && animalCount < maxPets)
                    {
                        Console.WriteLine("Would you like to enter a new pet? y/n");
                        anotherPet = Console.ReadLine()?.ToLower()??null;

                        if (anotherPet != null && anotherPet == "y")
                        {
                            for (int row = 0; row < rows; row++)
                            {
                                if (ourAnimals[row, 0] != "ID #: ")
                                {
                                    continue;
                                }

                                for (int col = 1; col < cols; col++)
                                {
                                    Console.WriteLine($"Please enter the {ourAnimals[row, col]} leave blank if unknown and press enter.");
                                    readResult = Console.ReadLine();
                                    ourAnimals[row, col] += readResult;
                                    if (readResult == "")
                                    {
                                        if (ourAnimals[row, col] == "Age: ")
                                        {
                                            ourAnimals[row, col] += "?";
                                        }
                                        else
                                        {
                                            ourAnimals[row, col] += "tbd";
                                        }
                                       
                                    }
                                    
                                }
                                
                                if (ourAnimals[row,0] == "ID #: ")
                                {
                                    ourAnimals[row, 0] += ourAnimals[row,1].Substring(9, 1) + (animalCount + 1).ToString();
                                    Console.WriteLine($"Pet ID is {ourAnimals[row,0]}");
                                }

                                animalCount++;
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine(
                                $"We currently have {animalCount} pets that need homes. We cannot manage another pet. Please check back later");
                            anotherPet = "n";
                        }
                    }

                    if (animalCount >= maxPets)
                    {
                        Console.WriteLine("New pets can not be entered. Press the Enter key to continue");
                        readResult = Console.ReadLine();
                    }

                    break;
                case "3":
                    // TODO add feature: Ensure animal ages and physical descriptions are complete

                    Console.WriteLine(
                        $"You selected menu option {menuSelection}. This is a Challenge Project - Please check back to see progress");
                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                case "4":
                    // TODO add feature: Ensure animal nicknames and personality descriptions are complete

                    Console.WriteLine(
                        $"You selected menu option {menuSelection}. This is a Challenge Project - Please check back to see progress");
                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                case "5":
                    // TODO add feature: Edit an animal’s age

                    Console.WriteLine(
                        $"You selected menu option {menuSelection}. Under Construction- Please check back to see progress");
                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                case "6":
                    // TODO add feature: Edit an animal’s personality description

                    Console.WriteLine(
                        $"You selected menu option {menuSelection}. Under Construction - Please check back to see progress");
                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                case "7":
                    // TODO add feature: Display all cats with a specified characteristic

                    Console.WriteLine(
                        $"You selected menu option {menuSelection}. Under Construction - Please check back to see progress");
                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                case "8":
                    // TODO add feature: Display all dogs with a specified characteristic

                    Console.WriteLine(
                        $"You selected menu option {menuSelection}. Under Construction - Please check back to see progress");
                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                case "exit":
                    Console.WriteLine($"You selected menu option {menuSelection}.");
                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine($"Your selection {menuSelection} is invalid. Please Try again.");
                    Console.WriteLine("Press the Enter key to continue");
                    readResult = Console.ReadLine();
                    break;
            }
        } while (menuSelection != "exit");
    }
}