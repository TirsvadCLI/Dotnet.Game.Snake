using System.Text.Json;

namespace Snake.Model
{
    public class HighScore
    {
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; }

        public HighScore(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }

    public class HighScoreCollection
    {
        private static HighScoreCollection? _instance;
        private static readonly object _lock = new object();

        public List<HighScore> HighScores { get; set; } = new List<HighScore>();

        // Parameterless constructor
        public HighScoreCollection() { }

        // Singleton instance property
        public static HighScoreCollection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new HighScoreCollection();
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Adds a new high score to the collection, maintaining a maximum of 10 records.
        /// </summary>
        /// <param name="highScore">The high score to add.</param>
        public void AddHighScore(HighScore highScore)
        {
            HighScores.Add(highScore);
            HighScores = HighScores.OrderByDescending(h => h.Score).Take(10).ToList();
        }

        /// <summary>
        /// Checks if the given score is a new high score.
        /// </summary>
        /// <param name="score">The score to check.</param>
        /// <returns>True if the score is a new high score, otherwise false.</returns>
        public bool IsNewHighScore(int score)
        {
            if (this.HighScores.Count < 10)
            {
                return true;
            }
            return (score > this.HighScores.Min(h => h.Score));
        }
        /// <summary>
        /// Saves the high scores to a JSON file.
        /// </summary>
        public void SaveToFile(string highScoresFileName = Constants.highScoresFileName)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(highScoresFileName, json);
        }

        /// <summary>
        /// Loads the high scores from a JSON file.
        /// </summary>
        public void LoadFromFile(string highScoresFileName = Constants.highScoresFileName)
        {
            if (File.Exists(highScoresFileName))
            {
                Clear();
                var json = File.ReadAllText(highScoresFileName);
                var highScoreCollection = JsonSerializer.Deserialize<HighScoreCollection>(json);
                if (highScoreCollection != null)
                {
                    this.HighScores = highScoreCollection.HighScores;
                }
            }
        }

        public void Clear()
        {
            HighScores.Clear();
        }
    }
}
