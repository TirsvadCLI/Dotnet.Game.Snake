namespace Snake
{
    public class ScoreBoard
    {
        private static ScoreBoard? _instance;
        private static readonly object _lock = new object();
        int _score = 0;

        // Private constructor to prevent instantiation
        private ScoreBoard() { }

        // Public method to get the single instance of the class
        public static ScoreBoard Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ScoreBoard();
                    }
                    return _instance;
                }
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(15, 0);
            Console.Write("Score: " + _score);
        }

        public int Score
        {
            get { return _score; }
        }

        public void IncreaseScore(int score)
        {
            _score += score;
        }

        public void ResetScore()
        {
            _score = 0;
        }
    }
}
