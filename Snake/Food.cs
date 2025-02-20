namespace Snake
{
    public class Food
    {
        public int foodPoint = 0;
        public FoodType? foodType;
        public Position Position { get; set; }
        private int gameWindowWidth = SnakeGame.gameWindowWidth - 2;
        private int gameWindowHight = SnakeGame.gameWindowHight - 2;

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

    public class FoodType(Position position, int type)
    {
        public int foodPoint { get; set; }
        public Position Position { get; } = position;
        public void Render()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            switch (type)
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
                    //Console.Write("🍒");
                    Console.Write("c");
                    foodPoint = 12;
                    break;
            }
        }
    }
}
