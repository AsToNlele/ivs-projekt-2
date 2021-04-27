using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CalcTests
{
    class MathCalc
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public static double Sub(double num1, double num2)
        {
            return num1 - num2;
        }
        public static double Mul(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Div(double num1, double num2)
        {
            return num1 / num2;
        }

        public static double Pow(double num, int exp)
        {
            if (exp == 0)
            {
                return 1;
            }
            if (num == 0)
            {
                return 0;
            }
            double exponent = Convert.ToDouble(exp);
            double result = Math.Pow(num, exponent);
            return result;
        }

        public static double Root(double num, int exp)
        {
            double exponent = Convert.ToDouble(exp);

            double result = Math.Pow(Abs(num), (1.0 / exponent));
            if (num < 0)
                result *= -1;
            return result;
        }

        public static double Abs(double num)
        {
            if(num > 0)
            {
                return num;
            }
            return -1 * num;
        }
        public static double Fact(double num)
        {
            double result = 1;
            for (int i = 2; i <= Abs(num); i++)
            {
                result*= i;
            }
            if (num < 0)
            {
                result *= -1;
            }
            return result;
        }
    }
}
