namespace Snake
{
    public class SnakeGame
    {
        public const int gameWindowWidth = Constants.windowWidth - 2;
        public const int gameWindowHight = Constants.windowHeight - 2;
        private bool isGameOver = false;
        private static readonly Position Origin = new Position((gameWindowHight / 2), (SnakeGame.gameWindowWidth / 2));
        private Direction _currentDirection;
        private Direction _nextDirection;
        private Snake _snake;
        private Food _food;

        public SnakeGame()
        {
            _snake = new Snake(Origin, initialSize: 5);
            _food = new Food();
            _food.AddFood();
            _currentDirection = Direction.Right;
            _nextDirection = Direction.Right;
        }

        public bool GameOver => _snake.Dead;

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

        public void OnGameTick()
        {
            if (GameOver) throw new InvalidOperationException();

            _currentDirection = _nextDirection;
            _snake.Move(_currentDirection);

            // If the snake's head moves to the same position as an apple, the snake
            // eats it.
            if (_snake.Head.Equals(_food.Position))
            {
                _snake.Grow();
                _food.AddFood();
            }
        }

        public void Render()
        {
            _snake.Render();
            _food.foodType?.Render();
            Console.SetCursorPosition(0, 0);
        }

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

        // Border lines methods for the game window

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

        private static void BorderLineVertical(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("║");
        }

        private static void BorderLineHorizontal(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("═");
        }

        private static void BorderLineCornerTopLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("╔");
        }

        private static void BorderLineCornerTopRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("╗");
        }

        public static void BorderLineCornerBottomLeft(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("╚");
        }

        public static void BorderLineCornerBottomRight(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            //Console.Write("■");
            Console.Write("╝");
        }

    }
    public readonly struct Position(int top, int left)
    {
        public int Top { get; } = top;
        public int Left { get; } = left;

        public Position RightBy(int n) => new Position(Top, Left + n);
        public Position DownBy(int n) => new Position(Top + n, Left);
    }
}
