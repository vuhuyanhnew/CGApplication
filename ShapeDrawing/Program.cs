internal class Program
{
    private static void Main(string[] args)
    {
          while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. in hinh chu nhatt");
            Console.WriteLine("2. In hinh tam giac vuong (goc vuong o 4 vi tri khac nhau)");
            Console.WriteLine("3. In tam giac can");
            Console.WriteLine("4. Thoat");
            Console.Write("Nhap lua chon cua ban: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DrawRectangle();
                    break;
                case 2:
                    DrawRightTriangles();
                    break;
                case 3:
                    DrawIsoscelesTriangle();
                    break;
                case 4:
                    return;
                default:
                    break;
            }

            Console.WriteLine();
        }
    }
      static void DrawRectangle()
    {
        Console.Write("Nhap chieu dai: ");
        int length = int.Parse(Console.ReadLine());
        Console.Write("Nhap chieu rong ");
        int width = int.Parse(Console.ReadLine());

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }

    static void DrawRightTriangles()
    {
        Console.Write("Nhập chieu cao tam giac: ");
        int height = int.Parse(Console.ReadLine());

        Console.WriteLine("Tam giac vuong goc:");
        for (int i = 1; i <= height; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nTam giac vuong goc trai tren:");
        for (int i = height; i >= 1; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nTam giac vuong goc phai duoi:");
        for (int i = 1; i <= height; i++)
        {
            for (int j = 1; j <= height - i; j++)
            {
                Console.Write("  ");
            }
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\ntam giac vuong goc phai tren:");
        for (int i = height; i >= 1; i--)
        {
            for (int j = 1; j <= height - i; j++)
            {
                Console.Write("  ");
            }
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }

    static void DrawIsoscelesTriangle()
    {
        Console.Write("Nhap chieu cao tam giac can: ");
        int height = int.Parse(Console.ReadLine());

        for (int i = 1; i <= height; i++)
        {
            for (int j = 1; j <= height - i; j++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j <= 2 * i - 1; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}