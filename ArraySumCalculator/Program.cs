internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = new int[5];

        numbers[0] = 2;
        numbers[1] = 5;
        numbers[2] = 9;
        numbers[3] = 6;
        numbers[4] = 7;


        int total = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine("Phan tu thu " + (i + 1) + ": " + numbers[i]);
            total = total + numbers[i];
        }

        Console.WriteLine("Tong cac phan tu trong mang: " + total.ToString());
    }
}