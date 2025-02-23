using System.Text.Json;

namespace Snake.Model
{
    public class HighScore
    {
        public string Name { get; set; } = string.Empty;
        public int Score { get; set; }
    }

    public class HighScoreHelper : HighScore
    {
        public HighScoreHelper(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }


    public class HighScoreCollection
    {
        public List<HighScore> HighScores { get; set; } = new List<HighScore>();
    }

    public class HighScoreCollectionHelper : HighScoreCollection
    {
        private string filePath = "highscores.json";

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
            if (HighScores.Count < 10)
            {
                return true;
            }
            return score > HighScores.Min(h => h.Score);
        }
        /// <summary>
        /// Saves the high scores to a JSON file.
        /// </summary>
        public void SaveToFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Loads the high scores from a JSON file.
        /// </summary>
        public void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var highScoreCollection = JsonSerializer.Deserialize<HighScoreCollectionHelper>(json);
                if (highScoreCollection != null)
                {
                    HighScores = highScoreCollection.HighScores;
                }
            }
        }
    }
}
