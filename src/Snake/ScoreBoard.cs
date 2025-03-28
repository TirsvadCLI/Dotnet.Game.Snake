namespace Snake
{
    /// <summary>
    /// Singleton class to manage the game score.
    /// </summary>
    public class ScoreBoard
    {
        private static ScoreBoard? _instance;
        private static readonly object _lock = new object();
        private int _score = 0;

        // Private constructor to prevent instantiation
        private ScoreBoard() { }

        /// <summary>
        /// Gets the single instance of the _scoreBoard class.
        /// </summary>
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

        /// <summary>
        /// Renders the current score on the console.
        /// </summary>
        public void Render()
        {
            string scoreText = "Score: " + _score;
            // Find x position to center the score text
            int startX = (Constants.gameWindowSizeWidth - scoreText.Length) / 2;
            Console.SetCursorPosition(startX, 0);
            Console.Write(scoreText);
        }

        /// <summary>
        /// Gets the current score.
        /// </summary>
        public int Score
        {
            get { return _score; }
        }

        /// <summary>
        /// Increases the score by the specified amount.
        /// </summary>
        /// <param name="score">The amount to increase the score by.</param>
        public void IncreaseScore(int score)
        {
            _score += score;
        }

        /// <summary>
        /// Resets the score to zero.
        /// </summary>
        public void ResetScore()
        {
            _score = 0;
        }
    }
}
