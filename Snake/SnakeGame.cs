using Snake.Model;

namespace Snake
{
    /// <summary>
    /// Game Engine for the Snake game.
    /// </summary>
    public class SnakeGame
    {
        // Constants
        public const int gameWindowWidth = Constants.gameWindowSizeWidth - 2; // Width of the game
        public const int gameWindowHight = Constants.gameWindowSizeHeight - 2; // Height of the game
        // Variables
        private bool isGameOver = false; // Check if the game is over
        private static readonly Position Origin = new Position((gameWindowHight / 2), (SnakeGame.gameWindowWidth / 2)); // Origin position of the snake
        private Direction _currentDirection; // Current direction of the snake
        private Direction _nextDirection; // Next direction of the snake
        private Snake Snake; // Snake object
        private Food Food; // Food object
        private ScoreBoard ScoreBoard = ScoreBoard.Instance; // ScoreBoard object
        private Frame Frame = new Frame(Constants.gameWindowSizeWidth, Constants.gameWindowSizeHeight); // Frame object

        /// <summary>
        /// Initializes a new instance of the <see cref="SnakeGame"/> class.
        /// </summary>
        public SnakeGame()
        {
            Console.ForegroundColor = ConsoleColor.Black; // Set the color of the border
            Snake = new Snake(Origin, initialSize: 5);
            Food = new Food();
            Food.AddFood();
            _currentDirection = Direction.Right;
            _nextDirection = Direction.Right;
            Frame.Render();
            Console.SetCursorPosition(0, Constants.gameWindowSizeHeight + 2);
            Console.WriteLine("Use the arrow keys to move the snake");

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
        public bool OnGameTick()
        {
            bool levelUp = false;

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
                levelUp = true;
            }
            return levelUp;
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
