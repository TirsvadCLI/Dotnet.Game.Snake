using Snake.Model;

namespace Snake
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    internal class Program
    {
        static HighScoreCollection highScoreCollection = HighScoreCollection.Instance;
        static ScoreBoard scoreBoard = ScoreBoard.Instance; // Make scoreBoard static

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static async Task Main()
        {
            // Set console settings
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Set console encoding to UTF-8 so we can use special char to show fruits
            Console.CursorVisible = false; // Hide the cursor

            // Load high scores from file
            highScoreCollection.LoadFromFile(); // Load high scores from file

            do
            {
                Console.Clear(); // Clear the console
                Frame menuFrame = new Frame(Constants.gameWindowSizeWidth, Constants.gameWindowSizeHeight);
                menuFrame.CenterRender(30, 6);
                int x = (Constants.gameWindowSizeWidth - 30) / 2 + 2;
                int y = (Constants.gameWindowSizeHeight - 5) / 2 + 1;

                Console.SetCursorPosition(x, y++);
                Console.Write("Welcome to Snake Game!");
                Console.SetCursorPosition(x, y++);
                Console.Write("F1: Start new game");
                Console.SetCursorPosition(x, y++);
                Console.Write("F2: Show High score ");
                Console.SetCursorPosition(x, y++);
                Console.Write("ESC: Exit");

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.F1)
                {
                    Console.Clear(); // Clear the console
                    scoreBoard.ResetScore();
                    await RunGame(); // Run the game
                                     // Check if the score is a new high score
                    if (highScoreCollection.IsNewHighScore(scoreBoard.Score))
                    {
                        AddNewHighScore(scoreBoard.Score); // Add new high score
                    }
                    Console.Clear();
                }
                else if (keyInfo.Key == ConsoleKey.F2)
                {
                    Console.Clear(); // Clear the console
                    PrintHighScore();
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
            } while (true);

            highScoreCollection.SaveToFile(); // Save high scores to file
        }

        /// <summary>
        /// Runs the game loop.
        /// </summary>
        /// <returns></returns>
        public static async Task RunGame()
        {
            // Game settings
            TimeSpan tickRate = TimeSpan.FromMilliseconds(100); // 100ms per tick = 10 ticks per second
            SnakeGame snakeGame = new SnakeGame(); // Create a new game instance

            // In C#, the CancellationTokenSource is a class used to send cancellation signals to one or more tasks or operations.
            // It is part of the Task Parallel Library (TPL) and is commonly used in asynchronous programming to gracefully cancel operations when they are no longer needed.
            using (CancellationTokenSource cts = new CancellationTokenSource()) // Create a cancellation token source
            {
                /// <summary>
                /// Monitors key presses and handles them.
                /// </summary>
                async Task MonitorKeyPresses()
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        if (Console.KeyAvailable)
                        {
                            ConsoleKey key = Console.ReadKey(intercept: true).Key;
                            snakeGame.OnKeyPress(key);
                        }
                        await Task.Delay(10);
                    }
                }

                var monitorKeyPresses = MonitorKeyPresses();

                // Main game loop
                do
                {
                    if (snakeGame.OnGameTick())
                    {
                        // TODO level up = increase speed
                    }
                    snakeGame.Render();
                    scoreBoard.Render();
                    await Task.Delay(tickRate); // Game speed = tick rate
                } while (!snakeGame.GameOver);

                cts.Cancel(); // Cancel the key press monitor
                await monitorKeyPresses; // Wait for the key press monitor to finish
            }

            // Game over screen
            {
                Frame GameOverFrame = new Frame(Constants.gameWindowSizeWidth, Constants.gameWindowSizeHeight);
                int centerFrameWidth = 15;
                int centerFrameHeight = 3;
                GameOverFrame.CenterRender(centerFrameWidth, centerFrameHeight);

                char[] gameOver = "Game Over".ToCharArray();
                int startX = (Constants.gameWindowSizeWidth - gameOver.Length) / 2;
                int startY = (Constants.gameWindowSizeHeight - centerFrameHeight) / 2;

                Console.SetCursorPosition(startX, startY + 1);
                foreach (char c in gameOver)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(100);
                }
            }

            await Task.Delay(1000);
        }

        /// <summary>
        /// Adds a new high score to the collection.
        /// </summary>
        /// <param name="score"></param>
        public static void AddNewHighScore(int score)
        {
            int centerFrameWidth = 30;
            int centerFrameHeight = 5;

            Frame AddNewHighScoreFrame = new Frame(Constants.gameWindowSizeWidth, Constants.gameWindowSizeHeight);
            AddNewHighScoreFrame.CenterRender(centerFrameWidth, centerFrameHeight);

            int startX = (Constants.gameWindowSizeWidth - centerFrameWidth) / 2 + 2;
            int startY = (Constants.gameWindowSizeHeight - centerFrameHeight) / 2 + 1;
            Console.CursorVisible = true;
            Console.SetCursorPosition(startX, startY);
            Console.Write("New High Score!");
            Console.SetCursorPosition(startX, startY + 1);
            Console.Write("Enter your name: ");
            Console.SetCursorPosition(startX, startY + 2);
            Console.CursorVisible = false;
            string? playerName = Console.ReadLine();
            if (!string.IsNullOrEmpty(playerName))
            {
                HighScore highScore = new HighScore(playerName, score);
                highScoreCollection.AddHighScore(highScore);
            }
            else
            {
                HighScore highScore = new HighScore("anonymous", score);
                highScoreCollection.AddHighScore(highScore);
            }
        }

        /// <summary>
        /// Prints the high score to the console.
        /// </summary>
        public static void PrintHighScore()
        {
            // Frame for high scores
            Frame HighScoresFrame = new Frame(Constants.gameWindowSizeWidth, Constants.gameWindowSizeHeight - 3);
            HighScoresFrame.Render();

            int y = 2; // Start position for high scores
            int x = 2; // Start position for high scores

            // Display high scores
            Console.SetCursorPosition(2, y++);
            Console.Write($"High Scores {highScoreCollection.HighScores.Count}");
            Console.SetCursorPosition(2, y++);
            Console.Write("-----------");
            foreach (HighScore highScore in highScoreCollection.HighScores)
            {
                Console.SetCursorPosition(2, y);
                Console.Write($"{highScore.Name}: ");
                Console.SetCursorPosition(2 + 25 - highScore.Score.ToString().Length, y++);
                Console.Write($"{highScore.Score}");
            }

            Console.SetCursorPosition(0, Constants.gameWindowSizeHeight - 1);

            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}