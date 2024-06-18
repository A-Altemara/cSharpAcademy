using System.Collections.Concurrent;

namespace ConsoleApp1;

public static class MethodsPettingZoo
{
    public static void PettingZoo()
    {
        string[] pettingZoo = {
            "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
            "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
            "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
        };
        
        SchoolVisit("School A");
        SchoolVisit("School B", 3);
        SchoolVisit("School C", 2);
        
        void SchoolVisit(string schoolName, int groups = 6)
        {
            string[] randomizedZooArray = RandomizeTheAnimals(pettingZoo);
            PrintSchoolName(schoolName);
            string[,] AssignedGroups = AssignAnimalsToGroups(randomizedZooArray, groups);
            PrintAnimalGroups(AssignedGroups);
        }

        string[] RandomizeTheAnimals(string[] anmialArray)
        {
            // use random to randomize the incoming animals array and return it
            Random placement = new();
            var randoziedAnimals = anmialArray.OrderBy(x => placement.NextDouble()).ToArray();
            
            // double check randmize worked
            // foreach (var animal in randoziedAnimals)
            // {
            //     Console.WriteLine(animal);
            // }

            return randoziedAnimals;

            // second method without Linq expression
            // Random random = new Random();
            // string[] randoziedAnmials = (string[])anmialArray.Clone();
            //
            // for (int i = 0; i < randoziedAnmials.Length; i++) 
            // {
            //     int r = random.Next(i, randoziedAnmials.Length);
            //
            //     string temp = randoziedAnmials[r];
            //     randoziedAnmials[r] = randoziedAnmials[i];
            //     randoziedAnmials[i] = temp;
            // }
            //
            // return randoziedAnmials; //string array with randomized animals
        }

        static string[,] AssignAnimalsToGroups(string[] randomizedAnimalArray, int groupNumber = 6)
        {
            // use loops to populate the groups of animals default of 6 but could be less than that
            string[,] groupedAnimalArray = new string [groupNumber, randomizedAnimalArray.Length / groupNumber];
          
            int counter = 0;

            for (int group = 0; group < groupNumber; group++)
            {
                for (int animal = 0; animal < randomizedAnimalArray.Length/groupNumber; animal++)
                {
                    // Console.WriteLine($"Group: {group} Animal: {animal}")
                    groupedAnimalArray[group, animal] = randomizedAnimalArray[counter];
                    counter++;
                }
            }

            // check that groups are working
            // for (int i = 0; i < groupedAnimalArray.GetLength(0); i++)
            // {
            //     Console.WriteLine($"Group {i + 1}");
            //     for (int j = 0; j < groupedAnimalArray.GetLength(1); j++)
            //     {
            //         Console.WriteLine(groupedAnimalArray[i,j]);
            //     }
            //
            //     Console.WriteLine();
            // }

            return groupedAnimalArray;
        }

        static void PrintSchoolName(string schoolName)
        {
            Console.WriteLine(schoolName);
        }

        static void PrintAnimalGroups(string[,] PreparedAnimalGroups)
        {
            // use a loop to print each animal group entry
            for (int i = 0; i < PreparedAnimalGroups.GetLength(0); i++)
            {
                Console.Write($"Group {i + 1}: ");
                for (int j = 0; j < PreparedAnimalGroups.GetLength(1); j++)
                {
                    Console.Write(PreparedAnimalGroups[i,j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}