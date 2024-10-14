using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap so can doc (0-999): ");
        int number = int.Parse(Console.ReadLine());

        if (number < 0 || number > 999)
        {
            Console.WriteLine("out of ability");
            return;
        }

        string result = ConvertNumberToWords(number);
        Console.WriteLine(result);
    }

    static string ConvertNumberToWords(int number)
    {
        if (number == 0)
            return "zero";

        string[] ones = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
                          "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        if (number < 20)
            return ones[number];

        if (number < 100)
        {
            return tens[number / 10] + (number % 10 != 0 ? " " + ones[number % 10] : "");
        }

        return ones[number / 100] + " hundred" + (number % 100 != 0 ? " and " + ConvertNumberToWords(number % 100) : "");
    }
}