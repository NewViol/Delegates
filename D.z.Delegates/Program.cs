using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

delegate decimal Test();

namespace DemoDelegates_15112021
{

    delegate void MyDelegate(double a, double b);
    delegate bool CompareDelegate(double x, double y);
    delegate double AriphmeticDelegate(double a, double b);
    class Program
    {
        static void MyMethod(double x, double y)
        {
            Console.WriteLine(x + y);
        }

        static double add(double a, double b)
        {
            return a + b;
        }
        static double sub(double a, double b)
        {
            return a - b;
        }
        static double mul(double a, double b)
        {
            return a * b;
        }
        static double div(double a, double b)
        {
            return a / b;
        }

        
        static void DemoSort(int[] mas, CompareDelegate d)
        {
            int size = mas.Length;
            while (--size > 0)
            {
                for (int i = 0; i < size; ++i)
                {
                    if (d(mas[i], mas[i + 1]))
                    {
                        int tmp = mas[i];
                        mas[i] = mas[i + 1];
                        mas[i + 1] = tmp;
                    }
                }
            }
        }
        static bool func(double a, double b)
        {
            return a > b;
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Magenta;

            AriphmeticDelegate[] ariphmetics = new AriphmeticDelegate[] { add, sub, mul, div };


            int y = 1;

            while (y != 0)
            {
                Console.WriteLine("Введите первое число");
                double a = double.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите второе число");
                double b = double.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите действие(+;-;/;*;))");
                char dia = char.Parse(Console.ReadLine());
                Console.Clear();

                if (dia == '+')
                {
                    Console.WriteLine("{0} + {1} = {2}", a, b, ariphmetics[0](a, b));
                }
                else if (dia == '-')
                {
                    Console.WriteLine("{0} - {1} = {2}", a, b, ariphmetics[1](a, b));
                }
                else if (dia == '*')
                {
                    Console.WriteLine("{0} * {1} = {2}", a, b, ariphmetics[2](a, b));
                }
                else if (dia == '/')
                {
                    Console.WriteLine("{0} / {1} = {2}", a, b, ariphmetics[3](a, b));
                }
                else
                {
                    Console.WriteLine("Ввели не правильное значение");
                }
                Console.WriteLine("Закрыть приложение('-' - Нет;'+' - Да");
                char close = char.Parse(Console.ReadLine());
                if(close == '+')
                {
                    y = 0;
                }
                Console.Clear();
            }
        }
    }
}
