using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static bool gameOver;
    static int width = 20;
    static int height = 20;
    static int score;

    static List<Position> snake;
    static Position food;

    static Direction direction;

    static readonly Random random = new Random();

    static void Main()
    {
        InitGame();
        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                ChangeDirection(key);
            }

            MoveSnake();
            CheckCollision();
            if (snake[0].Equals(food))
            {
                EatFood();
            }

            DrawGame();
            Thread.Sleep(100); 
        }

        Console.Clear();
        Console.WriteLine($"Game Over! Điểm của bạn: {score}");
    }

    static void InitGame()
    {
        gameOver = false;
        score = 0;
        direction = Direction.Right;

        snake = new List<Position>
        {
            new Position(width/2, height/2)
        };

        GenerateFood();

        Console.CursorVisible = false;
        Console.Clear();
    }

    static void DrawGame()
    {
        Console.SetCursorPosition(0, 0);

        Console.WriteLine("+" + new string('-', width) + "+");

        for (int y = 0; y < height; y++)
        {
            Console.Write("|");
            for (int x = 0; x < width; x++)
            {
                var pos = new Position(x, y);
                if (snake[0].Equals(pos))
                {
                    Console.Write("@"); 
                }
                else if (snake.Skip(1).Any(p => p.Equals(pos)))
                {
                    Console.Write("O"); 
                }
                else if (pos.Equals(food))
                {
                    Console.Write("*"); 
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine("|");
        }

        Console.WriteLine("+" + new string('-', width) + "+");
        Console.WriteLine($"Score: {score}");
    }

    static void MoveSnake()
    {
        var head = snake.First();
        Position newHead = direction switch
        {
            Direction.Up => new Position(head.X, (head.Y - 1 + height) % height),
            Direction.Down => new Position(head.X, (head.Y + 1) % height),
            Direction.Left => new Position((head.X - 1 + width) % width, head.Y),
            Direction.Right => new Position((head.X + 1) % width, head.Y),
            _ => head
        };

        snake.Insert(0, newHead);
        if (!newHead.Equals(food))
        {
            snake.RemoveAt(snake.Count - 1);
        }
    }

    static void EatFood()
    {
        score += 10;
        GenerateFood();
    }

    static void GenerateFood()
    {
        do
        {
            food = new Position(random.Next(width), random.Next(height));
        } while (snake.Any(segment => segment.Equals(food)));
    }

    static void CheckCollision()
    {
        var head = snake[0];
        if (snake.Skip(1).Any(segment => segment.Equals(head)))
        {
            gameOver = true;
        }
    }

    static void ChangeDirection(ConsoleKey key)
    {
        direction = key switch
        {
            ConsoleKey.UpArrow when direction != Direction.Down => Direction.Up,
            ConsoleKey.DownArrow when direction != Direction.Up => Direction.Down,
            ConsoleKey.LeftArrow when direction != Direction.Right => Direction.Left,
            ConsoleKey.RightArrow when direction != Direction.Left => Direction.Right,
            _ => direction
        };
    }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right
}

struct Position
{
    public int X { get; }
    public int Y { get; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object obj)
    {
        if (obj is Position other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}