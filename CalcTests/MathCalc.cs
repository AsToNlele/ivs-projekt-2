/*******************************************************************
* Název projektu: IVS projekt 2
* Soubor: MathCalc.cs
* Datum: 13.4.2021
* Poslední změna: 15.4.2021
* Autor: Alexandr Čelakovský (xcelak00)
*
* Popis: Matematická knihovna pro práci s kalkulačkou
*
*******************************************************************/
/**
* @file MathCalc.cs
*
* @brief Matematická knihovna pro práci s kalkulačkou
* @author Alexandr Čelakovský (xcelak00)
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CalcTests
{
    
    
    
    class MathCalc
    {
        /**
        * Funkce pro sečtení 2 čísel
        *
        * @param num1 První číslo které se bude sčítat
        * @param num2 Druhé číslo které se bude sčítat
        * @return Vrací výsledek sčítání
        */
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        /**
        * Funkce odečítání 2 čísel
        *
        * @param num1 První číslo které se bude odečítat
        * @param num2 Druhé číslo které se bude odečítat
        * @return Vrací výsledek sčítání
        */
        public static double Sub(double num1, double num2)
        {
            return num1 - num2;
        }
        /**
        * Funkce násobení 2 čísel
        *
        * @param num1 První číslo které se bude násobit
        * @param num2 Druhé číslo které se bude násobit
        * @return Vrací výsledek násobení
        */
        public static double Mul(double num1, double num2)
        {
            return num1 * num2;
        }
        /**
        * Funkce dělení 2 čísel
        *
        * @param num1 První číslo které bude dělenec
        * @param num2 Druhé číslo které bude dělitel
        * @return Vrací výsledek dělení
        */
        public static double Div(double num1, double num2)
        {
            return num1 / num2;
        }
        /**
        * Funkce mocnina
        *
        * @param num základ pro mocninu
        * @param exp exponent pro mocnění
        * @return Vrací výsledek po umocnění
        */
        public static double Pow(double num, int exp)
        {
            if (exp == 0) // exponent 0 automaticky vrátí 1
            {
                return 1;
            }
            if (num == 0) // základ 0 automaticky vráti 0
            {
                return 0;
            }
            double exponent = Convert.ToDouble(exp); // Převedení na stejný datový typ
            double result = Math.Pow(num, exponent); // Provedení umocnění
            return result;
        }
        /**
        * Funkce odmocnina
        *
        * @param num číslo pod odmocninou
        * @param exp exponent odmocniny
        * @return Vrací výsledek po odmocnění
        */
        public static double Root(double num, int exp)
        {
            double exponent = Convert.ToDouble(exp); // pro počítání ve stejném datovém typu

            double result = Math.Pow(Abs(num), (1.0 / exponent)); //používáme matematickou knihovnu na mocněné protože stačí udělat inverzní exponent pro odmocnění
            if (num < 0)
                result *= -1; // pokud je záporný první číslo obracíme výsledek
            return result;
        }
        /**
        * Funkce pro absolutní hodnotu
        *
        * @param num číslo v absolutní hodnotě
        * @return Vrací výsledek po provedení absolutní hodnoty
        */
        public static double Abs(double num)
        {
            if(num > 0) //pokud je číslo kladné vratíme stejné číslo
            {
                return num;
            }
            return -1 * num; //pokud je záporné vrátíme kladné číslo
        }
        /**
        * Funkce pro výpočet faktoriálu
        *
        * @param num číslo v absolutní hodnotě
        * @return Vrací výsledek po provedení absolutní hodnoty
        */
        public static double Fact(double num)
        {
            double result = 1; // nastavení výsledku na jedničku
            for (int i = 2; i <= Abs(num); i++) // procházíme od 2 po zadané číslo a každé číslo vynásobíme s každým
            {
                result*= i;
            }
            if (num < 0) //pokud je číslo záporné otočíme znaménko
            {
                result *= -1;
            }
            return result;
        }
    }
}
/*** Konec souboru MathCalc.cs ***/

