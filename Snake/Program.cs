namespace Snake
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static async Task Main()
        {
            var tickRate = TimeSpan.FromMilliseconds(100); // 100ms per tick = 10 ticks per second
            var snakeGame = new SnakeGame(); // Create a new game instance
            var scoreBoard = ScoreBoard.Instance; // Get the score board instance

            Console.CursorVisible = false; // Hide the cursor
            Console.Clear(); // Clear the console

            snakeGame.BorderLine(); // Draw the border line

            using (var cts = new CancellationTokenSource()) // Create a cancellation token source
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
                            var key = Console.ReadKey(intercept: true).Key;
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
                    await Task.Delay(tickRate);
                } while (!snakeGame.GameOver);

                // Allow time for user to weep before application exits.
                for (var i = 0; i < 3; i++)
                {
                    await Task.Delay(2000);
                }

                cts.Cancel();
                await monitorKeyPresses;
            }
        }
    }
}