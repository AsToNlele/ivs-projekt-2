using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalcTests;

namespace ivs_projekt_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    /* 
     TODO:
    CE button, osetrit vyjimky, zavolat push btneq v kazde operaci, zavolat push btnX pri zmacknuti klavesy, 
    grafika, button carka
     */

    public partial class MainWindow : Window
    {
        string output = ""; //retezec, ktery se tiskne pri zadavani vypoctu
        string nmb = ""; //aktualne zadavane cislo ve stringovem formatu protoze ho tvorime postupnym pridavani charu
        string operation = ""; //ktera operace se ma provest
        double nmb1 = 0; //vzdy prvni cislo v operaci
        bool firstOp = true; // 
        string err = "Syntax Error: Prosím zadejte číslo ve správném formátu."; // univerzalni chybova hlaska
        public MainWindow()
        {
            InitializeComponent();
        }
        // tiskne cisla ihned pri jejich psani
        private void printOut(string x)
        {
                nmb = nmb + x;
                output = output + x;
                txt.Text = output;
        }
        // vybere operaci tak, aby byla dale zpracovatelna v btneq
        private void selectOp(string x)
        {
            // zjistujeme, jestli chceme zadavat kompletne nove cislo do nmb1 nebo do nej nacteme vysledek predchoziho vypoctu
            if (firstOp)
            {
               nmb1 = double.Parse(nmb);
               firstOp = false;
            }
            
            /* pokud je jiz uzivatel zadal nejakou operaci a rozhodl se ji zmenit, smazeme posledni index v outputu, aby se nam 
                nam nestalo ze mame dve operace za sebou */
            if (operation != "")
            {
                output = output.Remove(output.Length - 1, 1);
            }
            //vynulujeme nmb aby jsme do nej mohli nahravat druhe cislo v binarni operaci
            nmb = "";
            if (x == "sqrt")
            {
                output = "\u221A ( " + output + " )";
                txt.Text = output;
                operation = x;
            }
            else if (x == "abs")
            {
                output = "| " + output + " |";
                txt.Text = output;
                operation = x;
            }
            else
            {
                output = output + x;
                txt.Text = output;
                operation = x;
            }
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            printOut("9");
        }


        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            printOut("8");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            printOut("7");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            printOut("6");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            printOut("5");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            printOut("4");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            printOut("3");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            printOut("2");
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            printOut("1");
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            printOut("0");
        }

        private void btnco_Click(object sender, RoutedEventArgs e)
        {
            printOut(",");
        }

        private void btnpl_Click(object sender, RoutedEventArgs e)
        {
            selectOp("+");
        }

        private void btnmi_Click(object sender, RoutedEventArgs e)
        {
            selectOp("-");
        }

        private void btnti_Click(object sender, RoutedEventArgs e)
        {
            selectOp("*");
        }

        private void btndi_Click(object sender, RoutedEventArgs e)
        {
            selectOp("/");
        }

        private void btnfa_Click(object sender, RoutedEventArgs e)
        {
            selectOp("!");
        }

        private void btnpo_Click(object sender, RoutedEventArgs e)
        {
            selectOp("^");
        }

        private void btnsq_Click(object sender, RoutedEventArgs e)
        {
            selectOp("sqrt");
        }

        private void btnab_Click(object sender, RoutedEventArgs e)
        {
            selectOp("abs");
        }

        private void btneq_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                    //result = nmb1 + int.Parse(nmb);
                    nmb = MathCalc.Add(nmb1, int.Parse(nmb)).ToString();                 
                    txt.Text = nmb;              
                    break;
                case "-":
                    //result = nmb1 - int.Parse(nmb);
                    /*result = MathCalc.Sub(nmb1, double.Parse(nmb));          
                    txt.Text = result.ToString();*/
                    nmb = MathCalc.Sub(nmb1, int.Parse(nmb)).ToString();
                    txt.Text = nmb;
                    break;
                case "*":
                    //result = nmb1 * int.Parse(nmb);
                    /* result = MathCalc.Mul(nmb1, double.Parse(nmb));
                     txt.Text = result.ToString();*/
                    nmb = MathCalc.Mul(nmb1, int.Parse(nmb)).ToString();
                    txt.Text = nmb;
                    break;                   
                case "/":
                    // result = MathCalc.Div(nmb1, double.Parse(nmb));
                    //  result = nmb1 / int.Parse(nmb);
                    // txt.Text = result.ToString();
                    nmb = MathCalc.Div(nmb1, int.Parse(nmb)).ToString();
                    txt.Text = nmb;       
                    break;
                case "^":
                    /* result = MathCalc.Pow(nmb1, double.Parse(nmb));
                     txt.Text = result.ToString();*/
                    nmb = MathCalc.Pow(nmb1, int.Parse(nmb)).ToString();
                    txt.Text = nmb;
                    break;
                case "abs":
                    /*
                    result = MathCalc.Abs(nmb1);
                    txt.Text = result.ToString();*/
                    nmb = MathCalc.Abs(nmb1).ToString();
                    txt.Text = nmb;
                    break;
                case "sqrt":
                    /* result = MathCalc.Sqrt(nmb1,5);
                     txt.Text = result.ToString();*/
                    nmb = MathCalc.Sqrt(nmb1, 5).ToString();
                    txt.Text = nmb;
                    break;
                case "!":
                    /* result = MathCalc.Fact(nmb1);
                     txt.Text = result.ToString();*/
                    nmb = MathCalc.Fact(nmb1).ToString();
                    txt.Text = nmb;
                    break;
                default:
                    txt.Text = err; 
                    break;
            }
            output = nmb;
            operation = ""; // jinak se nam umaze cislo, kdyz kontrolujeme jestli v operation neco neni
            firstOp = true;
        }
        //smaze posledni cifru cisla, s kterym zrovna pracujeme tj. bud prvni nebo druhe cislo v binarni operaci
        private void btnde_Click(object sender, RoutedEventArgs e)
        {
            //podminka proto, aby jsme nezacali mazat chary ze stringu ve kterem uz zadne nejsou
            if (nmb.Length > 0)
            {
                output = output.Remove(output.Length - 1, 1);
                nmb = nmb.Remove(nmb.Length - 1, 1);
                txt.Text = output;
            }           
        }

        private void btnce_Click(object sender, RoutedEventArgs e)
        {
            //nastavi vsechny promenne do defaultniho stavu
            firstOp = true;
            output = "";
            nmb = "";
            nmb1 = 0;
            operation = "";
            txt.Text = output;
        }
    }
}