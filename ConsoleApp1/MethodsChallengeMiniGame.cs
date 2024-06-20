namespace ConsoleApp1;
/*
 Needed improvements:
- Code to determine if the player has consumed the food displayed.
- Code to determine if the food consumed should freeze player movement.
- Code to determine if the food consumed should increase player movement.
- Code to increase movement speed.
- Code to redisplay the food after it's consumed by the player.
- Code to terminate execution if an unsupported key is entered. Done.
- Code to terminate execution if the terminal was resized.
*/
public static class MethodsChallengeMiniGame
{
    public static void MiniGame()
    {
        Random random = new Random();
        Console.CursorVisible = false;
        int height = Console.WindowHeight - 1;
        int width = Console.WindowWidth - 5;
        bool shouldExit = false;
        bool foodConsumed = false;

        // Console position of the player
         int playerX = width / 2;
         int playerY = height / 2;

        // Console position of the food
         int foodX = 0;
         int foodY = 0;

        // Available player and food strings
         string[] states =
        {
            "('-')", "(^-^)", "(X_X)"
        };
         string[] foods =
        {
            "@@@@@", "$$$$$", "#####"
        };

        // Current player string displayed in the Console
         string player = states[0];

        // Index of the current food
         int food = 0;

         Console.WriteLine("Use Arrow Keys or keys A S W D to move and consume food. ");
         InitializeGame();
        while (!shouldExit)
        {
            if (TerminalResized())
            {
                Console.Clear();
                Console.WriteLine("Console was resized. program exiting.");
                shouldExit = true;
            }

            int playerspeed = CheckSpeedyPlayerState();
            CheckFrozenPlayerState();
            Move(playerspeed);
            IsFoodEaten(playerX, playerY, foodX, foodY);
        }
        
        // Returns true if the Terminal was resized 
        bool TerminalResized()
        {
            return height != (Console.WindowHeight - 1) || width != (Console.WindowWidth - 5);
        }

        // Displays random food at a random location
        void ShowFood()
        {
            // Update food to a random index
            food = random.Next(0, foods.Length);

            // Update food position to a random location
            foodX = random.Next(0, width - player.Length);
            if (foodX >= playerX)
            {
                foodX += player.Length;
            }

            // int playerSpeed = CheckSpeedyPlayerState();
            // do
            // {
            //     foodY = random.Next(0, height - 1);
            // } while (foodY % playerSpeed != playerY % playerSpeed);
            //
            // foodY = random.Next(0, (height - 1) / playerSpeed) * playerSpeed + (playerY % playerSpeed);
            
            if (foodY >= playerY)
            {
                foodY++;
            }

            // Display the food at the location
            Console.SetCursorPosition(foodX, foodY);
            Console.Write(foods[food]);
        }

        // Changes the player to match the food consumed
        void ChangePlayer()
        {
            player = states[food];
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }

        // Temporarily stops the player from moving
        void FreezePlayer()
        {
            System.Threading.Thread.Sleep(1000);
            player = states[0];
        }

        // Reads directional input from the Console and moves the player
        void Move(int speed = 1)
        {
            int lastX = playerX;
            int lastY = playerY;

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    playerY--;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    playerY++;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    playerX = lastX - speed;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    playerX = lastX + speed;
                    break;
                case ConsoleKey.Escape:
                default:
                    shouldExit = true;
                    break;
            }

            // Clear the characters at the previous position
            Console.SetCursorPosition(lastX, lastY);
            for (int i = 0; i < player.Length; i++)
            {
                Console.Write(" ");
            }

            // Keep player position within the bounds of the Terminal window
            playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
            playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

            // Draw the player at the new location
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }
        
        // checks to see if player has consumed food
        void IsFoodEaten(int playerXLocation, int playerYLocation, int foodXLocation, int foodYLocation)
        {
            if (playerXLocation == foodXLocation && playerYLocation == foodYLocation)
            {
                ChangePlayer();
                ShowFood();
            }
            // return foodConsumed;
        }

        // Clears the console, displays the food and player
        void InitializeGame()
        {
            Console.Clear();
            ShowFood();
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }

        void PrintUpdate()
        {
            // var foo = Console.GetCursorPosition();
            // var l = foo.Left;
            // var t = foo.Top;
            var (left, top) = Console.GetCursorPosition();
            Console.SetCursorPosition(0,0);
            Console.Write($"Food: {food} FoodX: {foodX} FoodY: {foodY}");
            Console.SetCursorPosition(left, top);
        }

        bool CheckFrozenPlayerState()
        {
            if (player == states[2])
            {
                FreezePlayer();
                return true;
            }

            return false;
        }
        int CheckSpeedyPlayerState()
        {
            if (player == states[1])
            {
                return 3;
            }

            return 1;
        }
    }
}

