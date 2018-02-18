using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUMBER;
using FRACTION;
using Lab2;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sign;
            Console.WriteLine("Введите знак числа: ");
            char s = (char)Console.Read();
            if (s == '-') sign = true;
            else sign = false;
            Console.ReadLine();
            Console.Write("Введите количество цифр(1..127): ");
            int i;
            i = Console.Read() - 48;
            Console.Read();
            Console.Read();
            Number a = new Number(i, sign);
            a.output();

            Console.WriteLine("Введите знак числа: ");
            s = (char)Console.Read();
            Console.ReadLine();
            if (s == '-') sign = true;
            else sign = false;
            Console.Write("Введите количество цифр(1..127):");
            int j = 0;
            j = Console.Read() - 48;
            Console.Read();
            Console.Read();
            Number b = new Number(j, sign);
            b.output();

            Number sum;
            sum = a + b;
            Console.Write("Сумма = ");
            sum.output();

            Number raz;
            raz = a - b;
            Console.Write("Разность = ");
            raz.output();

            Number mul;
            mul = a * b;
            Console.Write("Произведение = ");
            mul.output();

            
            //Fraction op1 = new Fraction();
            //Console.WriteLine("Первая дробь:");
            //op1.output();
            //Fraction op2 = new Fraction();
            //Console.WriteLine("Вторая дробь:");
            //op2.output();
            //Fraction res1 = op1 + op2;
            //Console.WriteLine("Сумма:");
            //res1.output();
            //Fraction res2 = op1 - op2;
            //Console.WriteLine("Разность:");
            //res2.output();
            //Fraction res3 = op1 * op2;
            //Console.WriteLine("Произведение:");
            //res3.output();
            Console.ReadKey();
        }
    }
}
