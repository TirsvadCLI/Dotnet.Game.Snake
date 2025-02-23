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
        public void AddFood()
        {
            var random = new Random(); //!< Random number generator
            var food = random.Next(1, 4); //!< Randow the type of the food
            var positionTop = random.Next(1, this.gameWindowHight); //!< Random the top position of the food
            var positionLeft = random.Next(1, this.gameWindowWidth); //!< Random the left position of the food
            Position = new Position(positionTop, positionLeft); //!< Set the position of the food
            foodType = new FoodType(Position, food); //!< Set the type of the food
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

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodType"/> class.
        /// </summary>
        /// <param name="position">The position of the food.</param>
        /// <param name="type">The type of the food.</param>
        public FoodType(Position position, int type)
        {
            Position = position;
            this._type = type;
        }

        /// <summary>
        /// Renders the food on the console.
        /// </summary>
        public void Render()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            switch (this._type)
            {
                case 1:
                    Console.Write("🍎");
                    //Console.Write("a");
                    foodPoint = 10;
                    break;
                case 2:
                    Console.Write("🍌");
                    //Console.Write("b");
                    foodPoint = 11;
                    break;
                case 3:
                    Console.Write("🍒");
                    //Console.Write("c");
                    foodPoint = 12;
                    break;
            }
        }
    }
}
