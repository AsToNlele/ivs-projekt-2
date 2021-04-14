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

        public static double Pow(double num, double exp)
        {
            if (exp == 0)
            {
                return 1;
            }
            double result = num;
            for (int i = 0; i < (exp - 1); i++)
            {
                result *= num;
            }
            return result; 
        }

        public static double Sqrt(double a, int b)
        {
            throw new NotImplementedException();
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
            double tempNumber = MathCalc.Abs(num);
            for(int i = 2; i <= tempNumber; i++)
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
