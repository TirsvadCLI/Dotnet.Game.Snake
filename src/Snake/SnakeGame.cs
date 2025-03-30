using Snake.Model;

using TirsvadCLI.Frame;

namespace Snake
{
    /// <summary>
    /// Game Engine for the _snake game.
    /// </summary>
    public class SnakeGame
    {
        // Constants
        public const int gameWindowWidth = Constants.gameWindowSizeWidth - 2; //!< Width of the game
        public const int gameWindowHight = Constants.gameWindowSizeHeight - 2; //!< Height of the game
        // Variables
        private bool _isGameOver = false; // Check if the game is over
        private static readonly Position _origin = new Position((gameWindowHight / 2), (SnakeGame.gameWindowWidth / 2)); // _origin position of the snake
        private bool _useEmojis = false; // Check if the game use emojis
        private Direction _currentDirection; // Current direction of the snake
        private Direction _nextDirection; // Next direction of the snake
        private Snake _snake; // _snake object
        private Food _food; // _food object
        private ScoreBoard _scoreBoard = ScoreBoard.Instance; // _scoreBoard object
        private Frame _frame = new Frame(Constants.gameWindowSizeWidth, Constants.gameWindowSizeHeight); // _frame object


        /// <summary>
        /// Initializes a new instance of the <see cref="SnakeGame"/> class.
        /// </summary>
        public SnakeGame(bool useEmojis)
        {
            Console.ForegroundColor = ConsoleColor.Black; // Set the color of the border
            _useEmojis = useEmojis;
            _snake = new Snake(_origin, initialSize: 5);
            _food = new Food();
            _food.AddFood(useEmojis);
            _currentDirection = Direction.Right;
            _nextDirection = Direction.Right;
            _frame.SetColorBg(ConsoleColor.White);
            _frame.SetColorFg(ConsoleColor.Black);
            _frame.Render();
            Console.SetCursorPosition(0, Constants.gameWindowSizeHeight + 2);
            Console.WriteLine("Use the arrow keys to move the snake");
        }

        /// <summary>
        /// Gets a value indicating whether the game is over.
        /// </summary>
        public bool GameOver => _snake.Dead;

        /// <summary>
        /// Handles key press events to change the direction of the snake.
        /// </summary>
        /// <param name="key">The key that was pressed.</param>
        public void OnKeyPress(ConsoleKey key)
        {
            Direction newDirection; //!< The new direction of the snake

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
            bool levelUp = false; //!< Check if the snake level up

            if (GameOver) throw new InvalidOperationException();

            _currentDirection = _nextDirection;
            _snake.Move(_currentDirection);

            // If the snake's head moves to the same position as an apple, the snake
            // eats it.
            if (_snake.Head.Equals(_food.Position) && _food.foodType != null)
            {
                _scoreBoard.IncreaseScore(_food.foodType.foodPoint);
                _snake.Grow();
                _food.AddFood(_useEmojis);
                levelUp = true;
            }
            return levelUp;
        }

        /// <summary>
        /// Renders the game state to the console.
        /// </summary>
        public void Render()
        {
            _snake.Render();
            _food.foodType?.Render();
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
    /// <param name="left">The left position.</param>
    /// <param name="top">The top position.</param>
    public readonly struct Position(int top, int left)
    {
        public int Top { get; } = top; //!< The top position
        public int Left { get; } = left; //!< The left position

        /// <summary>
        /// Returns a new position that is moved up by the specified amount.
        /// </summary>
        /// <returns>The new position</returns>
        public Position RightBy(int n) => new Position(Top, Left + n);

        /// <summary>
        /// Returns a new position that is moved up by the specified amount.
        /// </summary>
        /// <returns>The new position</returns>
        public Position DownBy(int n) => new Position(Top + n, Left);
    }
}
