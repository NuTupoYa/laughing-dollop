using System;
class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        double realPart = a.Real * b.Real - a.Imaginary * b.Imaginary;
        double imaginaryPart = a.Real * b.Imaginary + a.Imaginary * b.Real;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
    {
        double denom = b.Real * b.Real + b.Imaginary * b.Imaginary;
        double realPart = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denom;
        double imaginaryPart = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denom;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public double Modulus()
    {
        return Math.Sqrt(Real * Real + Imaginary * Imaginary);
    }

    public double Argument()
    {
        return Math.Atan2(Imaginary, Real);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
   
}

partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Калькулятор комплексных чисел");

        Console.Write("Введите действительную часть первого числа: ");
        double real1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите мнимую часть первого числа: ");
        double imag1 = Convert.ToDouble(Console.ReadLine());
        ComplexNumber c1 = new ComplexNumber(real1, imag1);

        Console.Write("Введите действительную часть второго числа: ");
        double real2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите мнимую часть второго числа: ");
        double imag2 = Convert.ToDouble(Console.ReadLine());
        ComplexNumber c2 = new ComplexNumber(real2, imag2);

        Console.WriteLine($"\nПервое число: {c1}");
        Console.WriteLine($"Второе число: {c2}");

        Console.WriteLine($"Сложение: {c1 + c2}");
        Console.WriteLine($"Вычитание: {c1 - c2}");
        Console.WriteLine($"Умножение: {c1 * c2}");
        Console.WriteLine($"Деление: {c1 / c2}");

        Console.WriteLine($"Модуль первого числа: {c1.Modulus()}");
        Console.WriteLine($"Аргумент первого числа: {c1.Argument()}");
        Console.ReadKey();
    }

}
