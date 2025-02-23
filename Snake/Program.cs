using Snake.Model;

namespace Snake
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static async Task Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Set console encoding to UTF-8 so we can use special char to show fruits
            Console.CursorVisible = false; // Hide the cursor
            Console.Clear(); // Clear the console

            TimeSpan tickRate = TimeSpan.FromMilliseconds(100); // 100ms per tick = 10 ticks per second
            SnakeGame snakeGame = new SnakeGame(); // Create a new game instance
            ScoreBoard scoreBoard = ScoreBoard.Instance; // Get the score board instance
            HighScoreCollectionHelper highScoreCollectionHelper = new HighScoreCollectionHelper();

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
            Frame GameOverFrame = new Frame(Constants.gameWindowSizeWidth, Constants.gameWindowSizeHeight);
            {
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

            highScoreCollectionHelper.LoadFromFile(); // Load high scores from file

            // Check if the score is a new high score
            if (highScoreCollectionHelper.IsNewHighScore(scoreBoard.Score))
            {
                int centerFrameWidth = 30;
                int centerFrameHeight = 5;

                Frame AddNewHighscoreFrame = new Frame(Constants.gameWindowSizeWidth, Constants.gameWindowSizeHeight);
                AddNewHighscoreFrame.CenterRender(centerFrameWidth, centerFrameHeight);
                char[] highScoreText = "New High Score!".ToCharArray();

                int startX = (Constants.gameWindowSizeWidth - centerFrameWidth) / 2 + 2;
                int startY = (Constants.gameWindowSizeHeight - centerFrameHeight) / 2 + 1;
                Console.CursorVisible = true;
                Console.SetCursorPosition(startX, startY);
                Console.Write("New High Score!");
                Console.SetCursorPosition(startX, startY + 1);
                Console.Write("Enter your name: ");
                Console.SetCursorPosition(startX, startY + 2);
                string name = Console.ReadLine();
                Console.CursorVisible = false;
                HighScore highScore = new HighScoreHelper(name, scoreBoard.Score);
                highScoreCollectionHelper.AddHighScore(highScore);
            }

            Console.Clear();

            // Display high scores
            Console.WriteLine("High Scores");
            Console.WriteLine("-----------");
            foreach (HighScore highScore in highScoreCollectionHelper.HighScores)
            {
                Console.WriteLine($"{highScore.Name}: {highScore.Score}");
            }

            highScoreCollectionHelper.SaveToFile(); // Save high scores to file

            Console.WriteLine("Tryk på en tast for at afslutte");
            Console.ReadKey();
        }
    }
}