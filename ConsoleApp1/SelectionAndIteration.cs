using System.Threading.Channels;

namespace ConsoleApp1;

static class SelectionAndIteration
{
    enum AnimalCharacteristics
    {
        Id,
        Species,
        Age,
        Nickname,
        PhysicalDescrition,
        Personality,
    }

    private static int IdIndex => (int)AnimalCharacteristics.Id;

    private const int AgeIndex = 2;

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
        ourAnimals[0, (int)AnimalCharacteristics.Species] = "kitty";
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

            var pets = ourAnimals.GetLength(0);
            var characteristic = ourAnimals.GetLength(1); //index with ourAnimals[row,col]

            switch (menuSelection)
            {
                case "1":
                    Console.WriteLine("\nOur Pets include:");
                    // List all of our current pet information
                    // for could also be declared (int i = 0; i< maxPets, i++) and not need the extra variables rows and cols.

                    // could use pet in place of row and pets in place of rows to be more explicit
                    for (int pet = 0; pet < pets; pet++)
                    {
                        if (ourAnimals[pet, (int)AnimalCharacteristics.Id] != "ID #: ")
                        {
                            // could use characteristic instead of col as above for better readability
                            for (int character = 0; character < characteristic; character++)
                            {
                                // call would be Console.WriteLine(ourAnimals[pet, characteristic]) using custom variables
                                Console.WriteLine(ourAnimals[pet, character]);
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
                    for (int pet = 0; pet < pets; pet++)
                    {
                        if (ourAnimals[pet, (int)AnimalCharacteristics.Id] != "ID #: ")
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
                        anotherPet = Console.ReadLine()?.ToLower() ?? null;

                        if (anotherPet != null && anotherPet == "y")
                        {
                            for (int pet = 0; pet < pets; pet++)
                            {
                                if (ourAnimals[pet, (int)AnimalCharacteristics.Id] != "ID #: ")
                                {
                                    continue;
                                }

                                for (int character = 1; character < characteristic; character++)
                                {
                                    Console.WriteLine(
                                        $"Please enter the {ourAnimals[pet, character]} leave blank if unknown and press enter.");
                                    readResult = Console.ReadLine();
                                    ourAnimals[pet, character] += readResult;
                                    if (readResult == "")
                                    {
                                        if (ourAnimals[pet, character] == "Age: ")
                                        {
                                            ourAnimals[pet, character] += "?";
                                        }
                                        else
                                        {
                                            ourAnimals[pet, character] += "tbd";
                                        }
                                    }
                                }

                                if (ourAnimals[pet, (int)AnimalCharacteristics.Id] == "ID #: ")
                                {
                                    ourAnimals[pet, (int)AnimalCharacteristics.Id] +=
                                        ourAnimals[pet, (int)AnimalCharacteristics.Species].Substring(9, 1) +
                                        (animalCount + 1).ToString();
                                    Console.WriteLine($"Pet ID is {ourAnimals[pet, (int)AnimalCharacteristics.Id]}");
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
                    Console.WriteLine("\nPets Needing Age or Description:");
                    int numericValue;
                    var validEntry = false;
                    for (int pet = 0; pet < pets; pet++)
                    {
                        var petId = ourAnimals[pet, (int)AnimalCharacteristics.Id];
                        var petAge = ourAnimals[pet, (int)AnimalCharacteristics.Age];
                        if (ourAnimals[pet, (int)AnimalCharacteristics.Id] != "ID #: " &&
                            ourAnimals[pet, (int)AnimalCharacteristics.Age] == "Age: ?")
                        {
                            do
                            {
                                Console.WriteLine(
                                    $"Please enter the age for {ourAnimals[pet, (int)AnimalCharacteristics.Id]} as a whole integer and press enter. IE 3 Type exit to skip this pet.");
                                readResult = Console.ReadLine();
                                validEntry = int.TryParse(readResult, out numericValue);
                                if (validEntry)
                                {
                                    ourAnimals[pet, (int)AnimalCharacteristics.Age] += readResult;
                                    Console.WriteLine(
                                        $"You have updated the age of pet ID: {ourAnimals[pet, (int)AnimalCharacteristics.Id]}");
                                }
                                else
                                {
                                    if (readResult.ToLower().Trim() == "exit")
                                    {
                                        Console.WriteLine("You have selected to exit. Press the Enter key to continue");
                                        Console.ReadLine();
                                        break;
                                    }

                                    Console.WriteLine("You have entered an invalid entry, press enter to continue.");
                                    Console.ReadLine();
                                }
                            } while (ourAnimals[pet, (int)AnimalCharacteristics.Age] == "Age: ?");

                            Console.WriteLine("");
                        }

                        if (ourAnimals[pet, (int)AnimalCharacteristics.Id] != "ID #: " &&
                            (ourAnimals[pet, (int)AnimalCharacteristics.PhysicalDescrition] == "Physical description: tbd" || ourAnimals[pet, (int)AnimalCharacteristics.PhysicalDescrition] == "Physical description: "))
                        {
                            do
                            {
                                Console.WriteLine(
                                    $"Please enter the Physical Description for {ourAnimals[pet, (int)AnimalCharacteristics.Id]}. Such as color, pattern, size etc. Type exit to skip");
                                readResult = Console.ReadLine();
                                validEntry = (readResult.Trim() != "");
                                if (readResult.ToLower().Trim() == "exit")
                                {
                                    Console.WriteLine("You have selected to exit. Press the Enter key to continue");
                                    Console.ReadLine();
                                    break;
                                }
                                if (validEntry)
                                {
                                    ourAnimals[pet, (int)AnimalCharacteristics.PhysicalDescrition] += readResult;
                                    Console.WriteLine(
                                        $"You have updated the Physical Description of pet ID: {ourAnimals[pet, (int)AnimalCharacteristics.Id]}");
                                }
                                else
                                {
                                    Console.WriteLine("You have entered an invalid entry. Press enter to continue.");
                                    readResult = Console.ReadLine();
                                }
                            } while (ourAnimals[pet, (int)AnimalCharacteristics.PhysicalDescrition] ==
                                     "Physical description: " || ourAnimals[pet, (int)AnimalCharacteristics.PhysicalDescrition] ==
                                     "Physical description: tbd") ;

                            Console.WriteLine("");
                        }
                    }

                    Console.WriteLine("All pets are up to date. Press the Enter key to continue");
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