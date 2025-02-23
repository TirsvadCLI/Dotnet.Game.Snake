namespace Snake
{
    /// <summary>
    /// Class that represents the food in the game.
    /// </summary>
    public class Food
    {
        public FoodType? foodType; // The type of the food
        public Position Position { get; set; } // The position of the food
        private int gameWindowWidth = SnakeGame.gameWindowWidth;
        private int gameWindowHight = SnakeGame.gameWindowHight;

        /// <summary>
        /// Adds food to a random position in the game window.
        /// </summary>
        public void AddFood()
        {
            var random = new Random();
            var food = random.Next(1, 4);
            var positionTop = random.Next(1, this.gameWindowHight);
            var positionLeft = random.Next(1, this.gameWindowWidth);
            Position = new Position(positionTop, positionLeft);
            foodType = new FoodType(Position, food);
            foodType.Render();
        }
    }

    /// <summary>
    /// Class that represents the food type in the game.
    /// </summary>
    public class FoodType
    {
        public int foodPoint { get; set; } = 0; // The point of the food
        public Position Position { get; } // The position of the food
        private int _type; // The type of the food

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
