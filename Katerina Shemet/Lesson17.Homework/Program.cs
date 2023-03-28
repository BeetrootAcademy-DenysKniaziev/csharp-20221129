namespace Snake
{
    struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;
            int lastFoodTime = 0;
            int foodDissapearTime = 8000;
            int negativePoints = 0;

            Position[] directions = new Position[]
            {
                new Position(0, 1),
                new Position(0, -1), 
                new Position(1, 0), 
                new Position(-1, 0), 
            };
            double sleepTime = 100;
            int direction = right;
            Random randomNumbersGenerator = new Random();
            lastFoodTime = Environment.TickCount;

            List<Position> obstacles = new List<Position>()

            {
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),
            new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth)),new Position(randomNumbersGenerator.Next(5,
                Console.WindowHeight),
            randomNumbersGenerator.Next(5,
                Console.WindowWidth))

             };
            foreach (Position obstacle in obstacles)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(
                    obstacle.col,
                    obstacle.row);
                Console.Write("=");
            }

            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = 0; i <= 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            Position food;
            do
            {
                food = new Position(
                    randomNumbersGenerator.Next(0,
                        Console.WindowHeight),
                    randomNumbersGenerator.Next(0,
                        Console.WindowWidth));
            }
            while (snakeElements.Contains(food) ||
                   obstacles.Contains(food));
            Console.SetCursorPosition(food.col, food.row);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("@");

            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(
                    position.col,
                    position.row);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("*");
            }

            while (true)
            {
                negativePoints++;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (direction != right) direction = left;
                    }
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        if (direction != left) direction = right;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        if (direction != down) direction = up;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        if (direction != up) direction = down;
                    }
                }

                Position snakeHead = snakeElements.Last();
                Position nextDirection = directions[direction];

                Position snakeNewHead = new Position(
                    snakeHead.row + nextDirection.row,
                    snakeHead.col + nextDirection.col);

                if (snakeNewHead.col < 0)
                    snakeNewHead.col = Console.WindowWidth - 1;
                if (snakeNewHead.row < 0)
                    snakeNewHead.row = Console.WindowHeight - 1;
                if (snakeNewHead.row >= Console.WindowHeight)
                    snakeNewHead.row = 0;
                if (snakeNewHead.col >= Console.WindowWidth)
                    snakeNewHead.col = 0;

                if (snakeElements.Contains(snakeNewHead)
                    || obstacles.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game over!");
                    int userPoints =
                        (snakeElements.Count - 6) * 100 -
                        negativePoints;

                    userPoints = Math.Max(userPoints, 0);
                    Console.WriteLine("Points are: {0}",
                        userPoints);
                    Console.ReadLine();
                    return;
                }

                Console.SetCursorPosition(
                    snakeHead.col,
                    snakeHead.row);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("*");

                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(
                    snakeNewHead.col,
                    snakeNewHead.row);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (direction == right) Console.Write(">");
                if (direction == left) Console.Write("<");
                if (direction == up) Console.Write("^");
                if (direction == down) Console.Write("v");


                if (snakeNewHead.col == food.col &&
                    snakeNewHead.row == food.row)
                {

                    do
                    {
                        food = new Position(
                            randomNumbersGenerator.Next(0,
                                Console.WindowHeight),
                            randomNumbersGenerator.Next(0,
                                Console.WindowWidth));
                    }
                    while (snakeElements.Contains(food) ||
                        obstacles.Contains(food));
                    lastFoodTime = Environment.TickCount;
                    Console.SetCursorPosition(
                        food.col,
                        food.row);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("@");
                    sleepTime--;

                    Position obstacle = new Position();
                    do
                    {
                        obstacle = new Position(
                            randomNumbersGenerator.Next(0,
                                Console.WindowHeight),
                            randomNumbersGenerator.Next(0,
                                Console.WindowWidth));
                    }
                    while (snakeElements.Contains(obstacle) ||
                        obstacles.Contains(obstacle) ||
                        (food.row != obstacle.row &&
                        food.col != obstacle.row));
                    obstacles.Add(obstacle);
                    Console.SetCursorPosition(
                        obstacle.col,
                        obstacle.row);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("=");
                }
                else
                {
                    Position last = snakeElements.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.Write(" ");
                }

                if (Environment.TickCount - lastFoodTime >=
                    foodDissapearTime)
                {
                    negativePoints = negativePoints + 50;
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write(" ");
                    do
                    {
                        food = new Position(
                            randomNumbersGenerator.Next(0,
                            Console.WindowHeight),
                            randomNumbersGenerator.Next(0,
                            Console.WindowWidth));
                    }
                    while (snakeElements.Contains(food) ||
                        obstacles.Contains(food));
                    lastFoodTime = Environment.TickCount;
                }

                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }
    }
}

