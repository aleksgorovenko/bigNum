using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUMBER;

namespace FRACTION
{
    public class Fraction : Number
    {
        const int N = 128;
        private Number numerator;
        private Number denominator;
        int count_num;
        int count_denom;
        private Random rnd = new Random();
        //=================================================================
        public Fraction()
        {
            Console.Write("Введите знак числа: ");
            char s = (char)Console.Read();
            if (s == '-') sign = true;
            else sign = false;
            Console.ReadLine();
            Console.Write("Введите количество цифр(1..127): ");
            count_num = Console.Read() - 48;

            Console.Read();
            Console.Read();
            numerator = new Number(count_num, sign);

            Console.Write("Введите количество цифр(1..127): ");
            count_denom = Console.Read() - 48;
            Console.Read();
            Console.Read();
            denominator = new Number(count_denom, sign);
            /*byte[] input1 = new byte[] {1, 2};
            count_num = 2;
            numerator = new Number(input1, 2, false);
            byte[] input2 = new byte[] { 1, 2, 3 };
            denominator = new Number(input2, 3, false);
            count_denom = 3;*/
        }
        //-------------------------------------------------------------
        public Fraction(Number num, Number denom, bool s)
        {
            numerator = num;
            denominator = denom;
            count_num = num.count;
            count_denom = denom.count;
            sign = s;
        }
        //-------------------------------------------------------------
        public Number Get_Numerator()
        {
            return numerator;
        }
        //-------------------------------------------------------------
        public Number Get_Denominator()
        {
            return denominator;
        }
        //-------------------------------------------------------------
        private Number res_den(Fraction a, Fraction b)
        {
            Number result_denom = null;
            if (bigger(a.denominator, b.denominator) == 2)
                result_denom = a.denominator;
            else
            {
                result_denom = a.denominator * b.denominator;
                a.numerator = a.numerator * b.denominator;
                b.numerator = b.numerator * a.denominator;
            }
            return result_denom;
        }
        //-------------------------------------------------------------
        public static Fraction operator +(Fraction a, Fraction b)
        {
            Number result_denom = null;
            Number result_num = null;
            Number q = null;
            Number q1 = null;

            if (bigger(a.denominator, b.denominator) == 2)
                result_denom = a.denominator;
            else
            {
                result_denom = a.denominator * b.denominator;
                q = a.numerator * b.denominator;
                q1 = b.numerator * a.denominator;
            }
            result_num = q + q1;
            return new Fraction(result_num, result_denom, result_num.sign);
        }
        //-------------------------------------------------------------
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Number result_denom = null;
            Number result_num = null;
            Number q = null;
            Number q1 = null;
            if (bigger(a.denominator, b.denominator) == 2)
                result_denom = a.denominator;
            else
            {
                result_denom = a.denominator * b.denominator;
                q = a.numerator * b.denominator;
                q1 = b.numerator * a.denominator;
            }
            result_num = q - q1;
            return new Fraction(result_num, result_denom, result_num.sign);
        }
        //-------------------------------------------------------------
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Number result_denom = null;
            Number result_num = null;
            result_num = a.numerator * b.numerator;
            result_denom = b.denominator * a.denominator;
            return new Fraction(result_num, result_denom, result_num.sign);
        }
        //-------------------------------------------------------------
        public void output()
        {
            numerator.output();
            if (numerator.sign == true) Console.Write("-");
            for (int j = 0; j < count_denom; j++)
                Console.Write("_");
            Console.WriteLine();
            denominator.output();
        }
    }
}
