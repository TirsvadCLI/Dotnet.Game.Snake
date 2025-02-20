namespace Snake
{
    public class Food
    {
        public FoodType? foodType;
        public Position Position { get; set; }
        private int gameWindowWidth = SnakeGame.gameWindowWidth - 2;
        private int gameWindowHight = SnakeGame.gameWindowHight - 2;

        /// <summary>
        /// Adds food to a random position in the game window.
        /// </summary>
        public void AddFood()
        {
            var random = new Random();
            var food = random.Next(1, 4);
            var positionTop = random.Next(1, gameWindowHight + 2);
            var positionLeft = random.Next(1, gameWindowWidth + 2);
            Position = new Position(positionTop, positionLeft);
            foodType = new FoodType(Position, food);
            foodType.Render();
        }
    }

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
                    //Console.Write("🍎");
                    Console.Write("a");
                    foodPoint = 10;
                    break;
                case 2:
                    //Console.Write("🍌");
                    Console.Write("b");
                    foodPoint = 11;
                    break;
                case 3:
                    //Console.Write("🍒"); // not shown in console
                    Console.Write("c");
                    foodPoint = 12;
                    break;
            }
        }
    }
}
