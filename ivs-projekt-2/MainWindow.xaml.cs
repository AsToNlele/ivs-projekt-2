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
     osetrit ", a znamenko po sobe vyvola chybu", dodelat ovladani pres klavesnici, osetrit konflikt specialnich operaci (abs,sqr),
     vypnout zadavani primo do textboxu, grafika, napoveda
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
            // podminka, ktera zarucuje, ze kdyz nezavolame rovna se na konci operace, zavola se samo
            // nmb!="" je osetreni podminky, aby se nam v btneq neprovadeli operace s prazdnym cislem,
            // coz muze nastat, ale nevim proc
            if (!firstOp && operation != "" && nmb!="")
            {
                btneq.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
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
            //TODO prepsat do nove funkce a vymyslet jeji nazev
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
                    nmb = MathCalc.Add(nmb1, double.Parse(nmb)).ToString();                 
                    txt.Text = nmb;              
                    break;
                case "-":                  
                    nmb = MathCalc.Sub(nmb1, double.Parse(nmb)).ToString();
                    txt.Text = nmb;
                    break;
                case "*":
                    nmb = MathCalc.Mul(nmb1, double.Parse(nmb)).ToString();
                    txt.Text = nmb;
                    break;                   
                case "/":
                    nmb = MathCalc.Div(nmb1, double.Parse(nmb)).ToString();
                    txt.Text = nmb;       
                    break;
                case "^":
                    nmb = MathCalc.Pow(nmb1, double.Parse(nmb)).ToString();
                    txt.Text = nmb;
                    break;
                case "abs":
                    nmb = MathCalc.Abs(nmb1).ToString();
                    txt.Text = nmb;
                    break;
                case "sqrt":
                    nmb = MathCalc.Sqrt(nmb1, 5).ToString();
                    txt.Text = nmb;
                    break;
                case "!":
                    nmb = MathCalc.Fact(nmb1).ToString();
                    txt.Text = nmb;
                    break;
                // pri kliknuti na rovnase bez zadane operace se nic neprovede
                case "":
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
        // clear all funkce
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
        // zakladni ovladání přes klávesnici
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                printOut("0");
            }
            if (e.Key == Key.D1|| e.Key == Key.NumPad1)
            {
                printOut("1");
            }
            if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                printOut("2");
            }
            if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                printOut("3");
            }
            if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                printOut("4");
            }
            if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                printOut("5");
            }
            if (e.Key == Key.D6 || e.Key == Key.NumPad6)
            {
                printOut("6");
            }
            if (e.Key == Key.D7 || e.Key == Key.NumPad7)
            {
                printOut("7");
            }
            if (e.Key == Key.D8 || e.Key == Key.NumPad8)
            {
                printOut("8");
            }
            if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                printOut("9");
            }
            if (e.Key == Key.OemComma || e.Key==Key.Decimal)
            {
                printOut(",");
            }
            if (e.Key == Key.OemPlus|| e.Key == Key.Add)
            {
                selectOp("+");
            }
            if (e.Key == Key.OemMinus||e.Key==Key.Subtract)
            {
                selectOp("-");
            }
            if (e.Key == Key.Multiply)
            {
                selectOp("*");
            }
            if (e.Key == Key.Divide)
            {
                selectOp("/");
            }
            if (e.Key == Key.Enter)
            {
                btneq.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            if (e.Key == Key.Back)
            {
                btnde.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            if (e.Key == Key.Delete)
            {
                btnce.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    } //public class: main window
} //namespace