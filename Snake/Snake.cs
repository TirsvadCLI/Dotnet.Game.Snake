using Snake.Model;

namespace Snake
{
    /// <summary>
    /// Represents a snake in the game.
    /// </summary>
    public class Snake
    {
        private List<Position> _body; // The snake's body
        private int _growthSpurtsRemaining; // The number of growth spurts remaining

        /// <summary>
        /// Initializes a new instance of the <see cref="Snake"/> class.
        /// </summary>
        /// <param name="spawnLocation">The initial position of the snake.</param>
        /// <param name="initialSize">The initial size of the snake.</param>
        public Snake(Position spawnLocation, int initialSize = 1)
        {
            _body = new List<Position> { spawnLocation }; // Initialize the snake's body
            _growthSpurtsRemaining = Math.Max(0, initialSize - 1); // Initialize the growth spurts remaining
            Dead = false; // Initialize the snake's dead state
        }

        /// <summary>
        /// Gets a value indicating whether the snake is dead.
        /// </summary>
        public bool Dead { get; private set; }

        /// <summary>
        /// Gets the position of the snake's head.
        /// </summary>
        public Position Head => _body.First();

        /// <summary>
        /// Gets the positions of the snake's body excluding the head.
        /// </summary>
        private IEnumerable<Position> Body => _body.Skip(1);

        /// <summary>
        /// Moves the snake in the specified direction.
        /// </summary>
        /// <param name="direction">The direction to move the snake.</param>
        /// <exception cref="InvalidOperationException">Thrown if the snake is dead.</exception>
        public void Move(Direction direction)
        {
            if (Dead) throw new InvalidOperationException();

            Position newHead; // The new position of the snake's head

            switch (direction)
            {
                case Direction.Up:
                    newHead = Head.DownBy(-1);
                    break;

                case Direction.Left:
                    newHead = Head.RightBy(-1);
                    break;

                case Direction.Down:
                    newHead = Head.DownBy(1);
                    break;

                case Direction.Right:
                    newHead = Head.RightBy(1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_body.Contains(newHead) || !PositionIsValid(newHead))
            {
                Render(); // Render the snake before exiting
                Dead = true; // The snake is dead
                return; // Exit the method
            }

            _body.Insert(0, newHead); // Insert the new head position at the beginning of the body

            if (_growthSpurtsRemaining > 0)
            {
                _growthSpurtsRemaining--;
            }
            else
            {
                // Erase the tail of the snake
                Console.SetCursorPosition(_body.Last().Left, _body.Last().Top);
                Console.Write(" ");
                _body.RemoveAt(_body.Count - 1);
            }
        }

        /// <summary>
        /// Increases the size of the snake.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the snake is dead.</exception>
        public void Grow()
        {
            if (Dead) throw new InvalidOperationException();

            _growthSpurtsRemaining++;
        }

        /// <summary>
        /// Renders the snake on the console.
        /// </summary>
        public void Render()
        {
            Console.SetCursorPosition(Head.Left, Head.Top);
            Console.Write("@");

            foreach (var position in Body)
            {
                Console.SetCursorPosition(position.Left, position.Top);
                Console.Write("■");
            }
        }

        /// <summary>
        /// Determines whether the specified position is valid within the game window.
        /// </summary>
        /// <param name="position">The position to validate.</param>
        /// <returns><c>true</c> if the position is valid; otherwise, <c>false</c>.</returns>
        private static bool PositionIsValid(Position position) =>
            position.Top > 0 &&
            position.Left > 0 &&
            position.Left < Constants.gameWindowSizeWidth - 1 &&
            position.Top < Constants.gameWindowSizeHeight - 1;
    }
}
