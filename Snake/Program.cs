namespace Snake
{
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

                do
                {
                    snakeGame.OnGameTick();
                    snakeGame.Render();
                    scoreBoard.Render();
                    await Task.Delay(tickRate); // Game speed = tick rate
                } while (!snakeGame.GameOver);

                cts.Cancel();
                await monitorKeyPresses;
            }
            Frame GameOverFrame = new Frame(Constants.windowWidth, Constants.windowHeight);
            GameOverFrame.CenterRender(15, 4);

            Console.ReadLine();
            Console.Clear();

            await Task.Delay(1000);
        }
    }
}