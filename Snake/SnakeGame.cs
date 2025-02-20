namespace Snake
{
    public class SnakeGame
    {
        // Constants
        public const int gameWindowWidth = Constants.windowWidth - 2; // Width of the game
        public const int gameWindowHight = Constants.windowHeight - 2; // Height of the game
        // Variables
        private bool isGameOver = false; // Check if the game is over
        private static readonly Position Origin = new Position((gameWindowHight / 2), (SnakeGame.gameWindowWidth / 2)); // Origin position of the snake
        private Direction _currentDirection; // Current direction of the snake
        private Direction _nextDirection; // Next direction of the snake
        private Snake Snake; // Snake object
        private Food Food; // Food object
        private ScoreBoard ScoreBoard = ScoreBoard.Instance; // ScoreBoard object

        /// <summary>
        /// Initializes a new instance of the <see cref="SnakeGame"/> class.
        /// </summary>
        public SnakeGame()
        {
            Snake = new Snake(Origin, initialSize: 5);
            Food = new Food();
            Food.AddFood();
            _currentDirection = Direction.Right;
            _nextDirection = Direction.Right;
        }

        /// <summary>
        /// Gets a value indicating whether the game is over.
        /// </summary>
        public bool GameOver => Snake.Dead;

        /// <summary>
        /// Handles key press events to change the direction of the snake.
        /// </summary>
        /// <param name="key">The key that was pressed.</param>
        public void OnKeyPress(ConsoleKey key)
        {
            Direction newDirection;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    newDirection = Direction.Up;
                    break;

                case ConsoleKey.LeftArrow:
                    newDirection = Direction.Left;
                    break;

                case ConsoleKey.DownArrow:
                    newDirection = Direction.Down;
                    break;

                case ConsoleKey.RightArrow:
                    newDirection = Direction.Right;
                    break;

                default:
                    return;
            }

            if (newDirection == OppositeDirectionTo(_currentDirection))
            {
                return;
            }

            _nextDirection = newDirection;
        }

        /// <summary>
        /// Updates the game state on each tick.
        /// </summary>
        public void OnGameTick()
        {
            if (GameOver) throw new InvalidOperationException();

            _currentDirection = _nextDirection;
            Snake.Move(_currentDirection);

            // If the snake's head moves to the same position as an apple, the snake
            // eats it.
            if (Snake.Head.Equals(Food.Position) && Food.foodType != null)
            {
                ScoreBoard.IncreaseScore(Food.foodType.foodPoint);
                Snake.Grow();
                Food.AddFood();
            }
        }

        /// <summary>
        /// Renders the game state to the console.
        /// </summary>
        public void Render()
        {
            Snake.Render();
            Food.foodType?.Render();
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Gets the opposite direction to the specified direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The opposite direction.</returns>
        private static Direction OppositeDirectionTo(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up: return Direction.Down;
                case Direction.Left: return Direction.Right;
                case Direction.Right: return Direction.Left;
                case Direction.Down: return Direction.Up;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Draws the border lines for the game window.
        /// </summary>
        public void BorderLine()
        {
            Console.BackgroundColor = ConsoleColor.Blue; // Set the background color of the border
            Console.ForegroundColor = ConsoleColor.Black; // Set the color of the border
                                                          // Draw border lines at the top and bottom
            for (int i = 0; i < Constants.windowWidth; i++)
            {
                BorderLineHorizontal(i, 0); // Draw border lines at the top
                BorderLineHorizontal(i, Constants.windowHeight - 2); // Draw border lines at the bottom
            }
            // Draw border lines at the left and right
            for (int i = 0; i < Constants.windowHeight - 1; i++)
            {
                BorderLineVertical(0, i);
                BorderLineVertical(Constants.windowWidth - 1, i);
            }
            BorderLineCornerTopLeft(0, 0);
            BorderLineCornerTopRight(Constants.windowWidth - 1, 0);
            BorderLineCornerBottomLeft(0, Constants.windowHeight - 2);
            BorderLineCornerBottomRight(Constants.windowWidth - 1, Constants.windowHeight - 2);
            Console.ResetColor(); // Reset the color of the border


            Console.SetCursorPosition(0, Constants.windowHeight);
            Console.WriteLine("Use the arrow keys to move the snake");
            Console.WriteLine("Press ESC to exit the game");
        }

        /// <summary>
        /// Draws a vertical border line at the specified position.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private static void BorderLineVertical(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("║");
        }

        /// <summary>
        /// Draws a horizontal border line at the specified position.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private static void BorderLineHorizontal(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("═");
        }

        /// <summary>
        /// Draws the top-left corner of the border line at the specified position.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private static void BorderLineCornerTopLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("╔");
        }

        /// <summary>
        /// Draws the top-right corner of the border line at the specified position.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        private static void BorderLineCornerTopRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("╗");
        }

        /// <summary>
        /// Draws the bottom-left corner of the border line at the specified position.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public static void BorderLineCornerBottomLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("╚");
        }

        /// <summary>
        /// Draws the bottom-right corner of the border line at the specified position.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public static void BorderLineCornerBottomRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("╝");
        }
    }

    /// <summary>
    /// Represents a position in the game window.
    /// </summary>
    public readonly struct Position(int top, int left)
    {
        public int Top { get; } = top;
        public int Left { get; } = left;

        /// <summary>
        /// Gets a new position that is to the right of the current position by the specified number of units.
        /// </summary>
        /// <param name="n">The number of units to the right.</param>
        /// <returns>The new position.</returns>
        public Position RightBy(int n) => new Position(Top, Left + n);

        /// <summary>
        /// Gets a new position that is below the current position by the specified number of units.
        /// </summary>
        /// <param name="n">The number of units down.</param>
        /// <returns>The new position.</returns>
        public Position DownBy(int n) => new Position(Top + n, Left);
    }
}
