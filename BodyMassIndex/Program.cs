using System.Runtime.Intrinsics.X86;

internal class Program
{
    private static void Main(string[] args)
    {
        double weight = 0, height = 0;
        Console.WriteLine("Enter weight in kg:");
        weight= double.Parse(Console.ReadLine());
        Console.WriteLine("Enter height in meters:");
        height = double.Parse(Console.ReadLine());
    
        double bmi = CalculateBmi(weight, height); 
        
            Console.Write("BMI: "+ bmi);

            if (bmi < 18)
                Console.WriteLine(" Underweight");
            else if (bmi < 25.0)
                Console.WriteLine(" Normal");
            else if (bmi < 30.0)
                Console.WriteLine(" Overweight");
            else
                Console.WriteLine(" Obese");
            
    }
    static double CalculateBmi(double weight, double height){
         double bmi = weight / Math.Pow(height,2);
            bmi = Math.Round(bmi, 1);
            return bmi;
    }
}