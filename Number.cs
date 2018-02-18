using System;

namespace NUMBER
{
    public class Number
    {
        const int N = 128;
        private byte[] number = new byte[N];
        int count;
        private bool sign;
        private Random rnd = new Random();
        //=================================================================
        public Number(int cnt, bool s)
        {
            //number = new byte[cnt];
            for (int i = 0; i < cnt; i++)
                number[i] = (byte)rnd.Next(0, 9);
            if (number[0] == 0) number[0]++;
            count = cnt;
            sign = s;
        }
        //-----------------------------------------------------------------
        public Number(byte[] input_number, int cnt, bool s)
        {
            //number = new byte[cnt];
            for (int i = 0; i < cnt; i++)
                number[i] = input_number[i];
            count = cnt;
            sign = s;
        }
        //------------------------------------------------------------------
        public void output()
        {
            if (sign == true) Console.Write("-");
            for (int i = 0; i < count; i++)
                Console.Write("{0}", number[i]);
            Console.WriteLine();
        }
        //-----------------------------------------------------------------
        private static byte[] sum(Number a, Number b)
        {
            byte[] result;
            int i_a, i_b, i_r;
            int q;

            i_a = a.count;
            i_b = b.count;
            if (i_a > i_b) i_r = i_a;
            else i_r = i_b;
            i_r++;
            q = i_r;
            result = new byte[N];

            while ((i_a >= 0) && (i_b >= 0))
            {
                result[i_r] += a.number[i_a];
                result[i_r] += b.number[i_b];
                if (result[i_r] >= 10)
                {
                    result[i_r] -= 10;
                    result[i_r - 1]++;
                }
                i_a--;
                i_b--;
                i_r--;
            }
            if (i_a == -1 && i_b >= 0)
                while (i_b >= 0)
                {
                    result[i_r] += b.number[i_b];
                    i_r--;
                    i_b--;
                }
            else
                if (i_b == -1 && i_a >= 0)
                while (i_a >= 0)
                {
                    result[i_r] += a.number[i_a];
                    i_r--;
                    i_a--;
                }

            if (result[0] == 0)
			{
                for (int i = 0; i < N - 1; i++)
                    result[i] = result[i + 1];
				
			}
            return result;
        }
        //-----------------------------------------------------------------
        private static byte[] dif(Number a, Number b)
        {
            byte[] result;
            int i_a, i_b, i_r;
            int q;

            i_a = a.count;
            i_b = b.count;
            if (i_a > i_b) i_r = i_a;
            else i_r = i_b;
            q = i_r;
            result = new byte[N];

            while ((i_a >= 0) && (i_b >= 0))
            {
                if ((a.number[i_a] < b.number[i_b]) || (a.number[i_a] >= 10))
                {
                    a.number[i_a] += 10;
                    a.number[i_a - 1]--;
                }
                result[i_r] += a.number[i_a];
                result[i_r] -= b.number[i_b];
                i_a--;
                i_b--;
                i_r--;
            }
            if (i_b == -1 && i_a >= 0)
                while (i_a >= 0)
                {
                    result[i_r] += a.number[i_a];
                    i_r--;
                    i_a--;
                }
			
            return result;
        }
        //-----------------------------------------------------------------
        private static byte[] multi(Number a, byte b)
        {
            byte[] result = new byte[a.count + 1];

            for (int i = a.count; i > 0; i--)
            {
                result[i + 1] += a.number[i];
                result[i + 1] *= b;
                if (result[i + 1] >= 10)
                {
                    byte c = result[i + 1];
                    c /= 10;
                    result[i] = c;
                    c *= 10;
                    result[i + 1] -= c;
                }
            }
            return result;
        }
        //-----------------------------------------------------------------
        private static byte bigger(Number a, Number b)
        {
            if (a.count > b.count) return 0;
            if (b.count > a.count) return 1;

            int n = a.count;

            for (int i = 0; i < n; i++)
            {
                if (a.number[i] > b.number[i]) return 0;
                if (b.number[i] > a.number[i]) return 1;
            }

            return 2;
        }
        //-----------------------------------------------------------------
        public static Number operator +(Number a, Number b)
        {
            int q;
            if (a.count > b.count) q = a.count;
            else q = b.count;
            if (a.number[0] + b.number[0] >= 10)
                q++;

            if ((a.sign == false) && (b.sign == false)) return new Number(sum(a, b), q, false);
            if ((a.sign == false) && (b.sign == true))
            {
                if (bigger(a, b) == 0) return new Number(dif(a, b), q, false);
                if (bigger(a, b) == 1) return new Number(dif(b, a), q, true);
            }

            if ((a.sign == true) && (b.sign == false))
            {
                if (bigger(a, b) == 0) return new Number(dif(a, b), q, true);
                if (bigger(a, b) == 1) return new Number(dif(b, a), q, false);
            }
            if ((a.sign == true) && (b.sign == true)) return new Number(sum(a, b), q, true);

            return null;
        }
        //-----------------------------------------------------------------
        public static Number operator -(Number a, Number b)
        {
            if (bigger(a, b) == 2) return new Number(dif(a, b), 1, false);
            int q;
            if (a.count > b.count) q = a.count;
            else q = b.count;

            if ((a.sign == false) && (b.sign == false))
            {
                if (bigger(a, b) == 0) return new Number(dif(a, b), q, false);
                if (bigger(a, b) == 1) return new Number(dif(b, a), q, true);
            }
            if ((a.sign == false) && (b.sign == true)) return new Number(sum(a, b), q, false);
            if ((a.sign == true) && (b.sign == false)) return new Number(sum(a, b), q, true);
            if ((a.sign == true) && (b.sign == true))
            {
                if (bigger(a, b) == 0) return new Number(dif(a, b), q, true);
                if (bigger(a, b) == 1) return new Number(dif(b, a), q, false);
            }

            return null;
        }
        //-----------------------------------------------------------------
        public static Number operator *(Number a, Number b)
        {
			int n = -1;
			n += a.count;
			n += b.count;
			int k = n;
			n++;
			
            byte[] abc = new byte[n];
            
			while (k > 0)
			{
				for (int i = 0; i < a.count; i++)
					for (int j = 0; j < b.count; j++)
					{
						if (i + j == k)
						{
							abc[k] += a.number[i];
							abc[k] *= b.number[j];
						}
					}
				k--;
			}
			
			byte[] result = new byte[n];
			
			for (int i = n - 1; i > 0; i--)
			{
				result[i + 1] = abc[i];
				if (abc[i] >= 10)
				{
					result[i + 1] %= 10;
					abc[i] \= 10;
					abc[i - 1] += abc[i]; 
				}
			}
			
			if (result[0] == 0)
			{
				for(int i = 0; i < n; i++)
					result[i] = result[i + 1];
				n--;
			}	

			if (((a.sign == false) && (b.sign == false)) || ((a.sign == true) && (b.sign == true)))	return new Number(result, n, false)
			else return new Number(result, n, true);
            return null;
        }
    }