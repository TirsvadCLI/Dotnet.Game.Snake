namespace Snake
{
    public class Frame
    {
        private int _windowWidth;
        private int _windowHeight;
        private int _width;
        private int _height;
        private int _startX = 0;
        private int _startY = 0;
        private char _leftTop = '╔';
        private char _rightTop = '╗';
        private char _leftBottom = '╚';
        private char _rightBottom = '╝';
        private char _horizontal = '═';
        private char _vertical = '║';
        private ConsoleColor FrameColorBg = ConsoleColor.Blue;
        private ConsoleColor FrameColorFg = ConsoleColor.Black;

        public Frame(int width, int height)
        {
            _width = _windowWidth = width;
            _height = _windowHeight = height;
        }

        public Frame(int width, int height, char leftTop, char rightTop, char leftBottom, char rightBottom, char horizontal, char vertical)
        {
            _windowWidth = width;
            _windowHeight = height;
            _width = width;
            _height = height;
            _leftTop = leftTop;
            _rightTop = rightTop;
            _leftBottom = leftBottom;
            _rightBottom = rightBottom;
            _horizontal = horizontal;
            _vertical = vertical;
        }

        public void SetColorBg(ConsoleColor color)
        {
            FrameColorBg = color;
        }

        public void SetColorFg(ConsoleColor color)
        {
            FrameColorFg = color;
        }

        public void Render(bool center = false)
        {
            if (center)
            {
                // Do something special for box in the center of the screen
            }

            Console.BackgroundColor = FrameColorBg;
            Console.ForegroundColor = FrameColorFg;

            // Draw top border
            Console.SetCursorPosition(_startX, _startY);
            Console.Write(_leftTop);
            for (int i = 0; i < _width; i++)
            {
                Console.Write(_horizontal);
            }
            Console.Write(_rightTop);

            // Draw left and right border
            for (int i = 1; i < _height; i++)
            {
                Console.SetCursorPosition(_startX, _startY + i);
                Console.Write(_vertical);
                // Clear the inside of the box
                Console.BackgroundColor = ConsoleColor.Black;
                for (int j = 1; j < _width; j++)
                {

                    Console.Write(" ");
                }
                Console.BackgroundColor = FrameColorBg;
                Console.SetCursorPosition(_startX + _width + 1, _startY + i);
                Console.Write(_vertical);
            }

            // Draw bottom border
            Console.SetCursorPosition(_startX, _startY + _height);
            Console.Write(_leftBottom);
            for (int i = 0; i < _width; i++)
            {
                Console.Write(_horizontal);
            }
            Console.Write(_rightBottom);

            Console.ResetColor();

        }

        public void CenterRender(int sizeX, int sizeY)
        {
            _startX = (Constants.windowWidth - sizeX) / 2;
            _startY = (Constants.windowHeight - sizeY) / 2;
            _width = sizeX;
            _height = sizeY;

            Render(center: true);

            char[] gameOver = "Game Over".ToCharArray();
            Console.SetCursorPosition(_startX + 1 + (sizeX - gameOver.Length) / 2, _startY + 2);
            foreach (char c in gameOver)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
