/*******************************************************************
* Název projektu: IVS projekt 2
* Soubor: Program.cs
* Datum: 25.4.2021
* Poslední změna: 25.4.2021
* Autor: Alexandr Čelakovský (xcelak00)
*
* Popis: Program na výpočet směrodatné odchylky
*
*******************************************************************/
/**
* @file Program.cs
*
* @brief Program na výpočet směrodatné odchylky
* @author Alexandr Čelakovský (xcelak00)
*/
using System;
using System.IO;
using CalcTests;

namespace Profiling
{       
    /// <summary>
    /// Program pro výpočet směrodatné odchylky
    /// </summary>
    class Program
    {

        /**
        * Funkce main
        *
        * @param args parametry spuštění
        */
        static void Main(string[] args)
        {
            /**
            * @var string fileName 
            * Řetězec který obsahuje jméno souboru
            */
            string fileName = args[0];
            /**
            * @var string line
            * Řetězec jednoho řádku v souboru
            */
            string line = "";

            
            try
            {
                // Pokus otevřít soubor a nahrát do proměné sr
                using (var sr = new StreamReader(fileName))
                {
                    //přečtení souboru do konce a nahrání do proměnné line
                    line += sr.ReadToEnd();
                }
            }
            catch (IOException e) //chyba eror
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            string[] oddelovace = new string[] { @"\tab", " ", "\t", "\r\n"}; // Všechny možné oddělovače řádků
            
            string[] split = line.Split(oddelovace, StringSplitOptions.None); // Rozdělení čísel do pole podle oddělovačů

            double[] values = new double[split.Length]; //proměnná na načítání čísel
            for (int i = 0; i < split.Length; i++) 
            {
                string currString = split[i]; //načtení každého čísla
                currString = currString.Replace("\n", "").Replace("\r", ""); //smazání konce řádků
                values[i] = Convert.ToDouble(currString); //převední na double
            }

            double result = SmerodatnaOdchylka(values); //zavolání funkce pro výsledek

            Console.WriteLine(result); //vypsání výsledku
        }
        /**
        * Funkce pro výpočet směrodatné odchylky
        *
        * @param pole pole všech čísel
        * @return Vrací výsledek ochylky
        */
        static double SmerodatnaOdchylka(double[] pole)
        {
            double aritmetickyPrumer; //
            int N = pole.Length; // N je velikost pole
            double suma = 0; // soucet čísel
            double SO = 0;
            for (int i = 0; i < N; i++) //sečtení všech čísel
            {
                suma = MathCalc.Add(suma, pole[i]);
            }

            aritmetickyPrumer = MathCalc.Div(suma, N); //podělení sumy počtem prvků pro arimetický průměr
            //vzorecek pro vypocet odchylky
            for (int i = 0; i < N; i++)
            {
                double meziVypocet = MathCalc.Sub(pole[i],aritmetickyPrumer);
                SO = MathCalc.Add(SO,MathCalc.Pow(meziVypocet, 2)); 
            }
            double res = MathCalc.Div(SO, N);
            return MathCalc.Root(res, 2);
        }
    }
}
/*** Konec souboru Program.cs ***/
