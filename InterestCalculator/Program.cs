internal class Program
{
    private static void Main(string[] args)
    {
        double money = 1.0;
        int month = 1;
        double interestRate = 1.0;

        Console.WriteLine("Nhap so tien gui: ");
        money = Double.Parse(Console.ReadLine());

        Console.WriteLine("Nhap so thang gui: ");
        month = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Nhap lai suat theo nam (%): ");
        interestRate = Double.Parse(Console.ReadLine());

        double totalInterest = 0;
        for (int i = 0; i < month; i++)
        {
            totalInterest += money * (interestRate / 100) / 12;
        }

        Console.WriteLine("Tong tien lai: " + totalInterest);
        Console.WriteLine("Tong so tien nhan duoc: " + (money + totalInterest));
    }
}