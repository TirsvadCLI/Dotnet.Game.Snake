namespace Snake
{
    public class Snake
    {
        private List<Position> _body;
        private int _growthSpurtsRemaining;

        public Snake(Position spawnLocation, int initialSize = 1)
        {
            _body = new List<Position> { spawnLocation };
            _growthSpurtsRemaining = Math.Max(0, initialSize - 1);
            Dead = false;
        }

        public bool Dead { get; private set; }
        public Position Head => _body.First();
        private IEnumerable<Position> Body => _body.Skip(1);

        public void Move(Direction direction)
        {
            if (Dead) throw new InvalidOperationException();

            Position newHead;

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
                Render();
                Dead = true;
                return;
            }

            _body.Insert(0, newHead);

            if (_growthSpurtsRemaining > 0)
            {
                _growthSpurtsRemaining--;
            }
            else
            {
                Console.SetCursorPosition(_body.Last().Left, _body.Last().Top);
                Console.Write(" ");
                _body.RemoveAt(_body.Count - 1);
            }
        }

        public void Grow()
        {
            if (Dead) throw new InvalidOperationException();

            _growthSpurtsRemaining++;
        }

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

        private static bool PositionIsValid(Position position) =>
        position.Top > 0 &&
            position.Left > 0 &&
            position.Left < Constants.windowWidth - 1 &&
            position.Top < Constants.windowHeight - 2;
    }
}