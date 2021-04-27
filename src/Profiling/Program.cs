using System;
using System.IO;
using CalcTests;

namespace Profiling
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string line = "";
            //string line = Console.ReadLine();
            //string line = Console.In.ReadToEnd();

            
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader(fileName))
                {
                    // Read the stream as a string, and write the string to the console.
                    line += sr.ReadToEnd();
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            string[] oddelovace = new string[] { @"\tab", " ", "\t", "\r\n"};
            string[] split = line.Split(oddelovace, StringSplitOptions.None);

            double[] values = new double[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                string currString = split[i];
                currString = currString.Replace("\n", "").Replace("\r", "");
                values[i] = Convert.ToDouble(currString);
            }

            double result = SmerodatnaOdchylka(values);

            Console.WriteLine(result);
            //Console.ReadKey();
        }

        static double SmerodatnaOdchylka(double[] pole)
        {
            double aritmetickyPrumer;
            int N = pole.Length;
            double suma = 0;
            double SO = 0;
            for (int i = 0; i < N; i++)
            {
                suma = MathCalc.Add(suma, pole[i]);
            }

            aritmetickyPrumer = MathCalc.Div(suma, N);

            for(int i = 0; i < N; i++)
            {
                double meziVypocet = MathCalc.Sub(pole[i],aritmetickyPrumer);
                SO = MathCalc.Add(SO,MathCalc.Pow(meziVypocet, 2));
            }
            double res = MathCalc.Div(SO, N);
            return MathCalc.Root(res, 2);
        }
    }
}
