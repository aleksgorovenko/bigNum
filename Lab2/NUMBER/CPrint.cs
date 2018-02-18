using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUMBER;
using FRACTION;

namespace Lab2
{
    class CPrint
    {
        public void print(Number a)
        {
            if (a.sign == true) Console.Write("-");
            byte[] print_mas = a.Get_Number();
            for (int i = 0; i < a.count; i++)
                Console.Write("{0}", print_mas[i]);
            Console.WriteLine();
        }
        //-------------------------------------------------
        public void print(Fraction a)
        {
            Number num = a.Get_Numerator();
            Number den = a.Get_Denominator();

            print(num);
            for (int i = 0; i < den.count; i++)
                Console.Write("_");
            Console.WriteLine();
            print(den);
        }
    }
}
