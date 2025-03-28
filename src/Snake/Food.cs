namespace Snake
{
    /// <summary>
    /// Class that represents the food in the game.
    /// </summary>
    public class Food
    {
        public FoodType? foodType; //!< The type of the food
        public Position Position { get; set; } //!< The position of the food
        private int gameWindowWidth = SnakeGame.gameWindowWidth; //!< The width of the game window
        private int gameWindowHight = SnakeGame.gameWindowHight; //!< The height of the game window

        /// <summary>
        /// Adds food to a random position in the game window.
        /// </summary>
        public void AddFood(bool useEmojis)
        {
            var random = new Random(); //!< Random number generator
            var food = random.Next(0, 3); //!< Randow the type of the food
            var positionTop = random.Next(2, this.gameWindowHight); //!< Random the top position of the food
            var positionLeft = random.Next(2, this.gameWindowWidth); //!< Random the left position of the food
            Position = new Position(positionTop, positionLeft); //!< Set the position of the food
            foodType = new FoodType(Position, food, useEmojis); //!< Set the type of the food
            foodType.Render();
        }
    }

    /// <summary>
    /// Class that represents the food type in the game.
    /// </summary>
    public class FoodType
    {
        public int foodPoint { get; set; } = 0; //!< The point of the food
        public Position Position { get; } //!< The position of the food
        private int _type; //!< The type of the food
        private string[] _foodType; //!< The food types

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodType"/> class.
        /// </summary>
        /// <param name="position">The position of the food.</param>
        /// <param name="type">The type of the food.</param>
        public FoodType(Position position, int type, bool useEmojis = false)
        {
            Position = position;
            if (useEmojis)
            {
                _foodType = new string[] { "🍎", "🍌", "🍒" };
            }
            else
            {
                _foodType = new string[] { "a", "b", "c" };
            }
            _type = type;
        }

        /// <summary>
        /// Renders the food on the console.
        /// </summary>
        public void Render()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            switch (_type)
            {
                case 0:
                    foodPoint = 10;
                    break;
                case 1:
                    foodPoint = 11;
                    break;
                case 2:
                    foodPoint = 12;
                    break;
            }
            Console.Write(_foodType[_type]);
        }
    }
}
