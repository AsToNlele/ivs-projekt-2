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
     dodelat ovladani pres klavesnici, grafika, napoveda
     */

    public partial class MainWindow : Window
    {
        string output = ""; //retezec, ktery se tiskne pri zadavani vypoctu
        string nmb = ""; //aktualne zadavane cislo ve stringovem formatu protoze ho tvorime postupnym pridavani charu
        string operation = ""; //ktera operace se ma provest
        double nmb1 = 0; //vzdy prvni cislo v operaci
        bool firstOp = true; // true znamena ze jsme na zacatku operace tj. v nmb1 jeste neni nahrana hodnota
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

        // pokud je jiz uzivatel zadal nejakou operaci a rozhodl se ji zmenit, prepiseme puvodni znamenka na aktualni zadanou operaci 
        private void clearOpSigns()
        {
            if (operation != "")
            {
                output = output.Remove(output.Length - 1, 1);
            }
            if (operation == "abs")
            {
                output = output.Remove(0, 1);
            }
            if (operation == "sqrt")
            {
                output = output.Remove(0, 3);
            }
        }

        //vybere, ktere znaceni operace je vhodne vytisknout
        private void chooseOutput(string x)
        {
            if (x == "sqrt")
            {
                output = "\u221A ( " + output + " )";
                txt.Text = output;             
            }
            else if (x == "abs")
            {
                output = "| " + output + " |";
                txt.Text = output;
            }
            else
            {
                output = output + x;
                txt.Text = output;
            }
        }

        // vybere operaci tak, aby byla dale zpracovatelna v btneq
        private void selectOp(string x)
        {
                // podminka, ktera zarucuje, ze kdyz nezavolame rovna se na konci operace, zavola se samo
                if (!firstOp && operation != "")
                {
                    btneq.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                // nahrajeme prvni cislo v operaci do nmb1 pokud se jedna o prvni cislo
                if (firstOp)
                {
                // nmb1 = double.Parse(nmb);
                    if(!double.TryParse(nmb, out nmb1))
                        {
                            txt.Text = err;
                        }
                    firstOp = false;
                }
                clearOpSigns();
                chooseOutput(x);
                //vynulujeme nmb aby jsme do nej mohli nahravat druhe cislo v binarni operaci
                nmb = "";
                operation = x;        
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
            // switch vybere operaci a zavola funkci z knihovny CalcMath
            // pokud uzivatel nezada cislo nebo zada pouze carku, vypise se chybova hlaska - s jinymi patvary se knihovna popere sama
            double nmb2 = 0;
            // zkousime parsovat nmb do nmb2, pokud to nevyjde vypiseme chybovou hlasku
            // nmb2 ale nepotrebujeme do unarnich operaci a tak u nich chybu nevypisujeme
            if (double.TryParse(nmb,out nmb2)||operation=="sqrt"||operation=="!"||operation=="abs")
            {
                switch (operation)
                {
                    case "+":
                        nmb = MathCalc.Add(nmb1, nmb2).ToString();
                        txt.Text = nmb;
                        break;
                    case "-":
                        nmb = MathCalc.Sub(nmb1, nmb2).ToString();
                        txt.Text = nmb;
                        break;
                    case "*":
                        nmb = MathCalc.Mul(nmb1, nmb2).ToString();
                        txt.Text = nmb;
                        break;
                    case "/":
                        nmb = MathCalc.Div(nmb1, nmb2).ToString();
                        txt.Text = nmb;
                        break;
                    case "^":
                        nmb = MathCalc.Pow(nmb1, nmb2).ToString();
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
                    // pri kliknuti na rovna se bez zadane operace se nic neprovede
                    case "":
                        break;
                    default:
                        txt.Text = err;
                        break;
                }
                output = nmb;
                operation = ""; // po rovna se zacina nova operace
                firstOp = true; // po zmacknuti rovna se se dostavame na zacatek dalsi operace
            } //if
            else
            {
                txt.Text = err;
            }
        } // btneq_click()
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

        //  ovladání přes klávesnici
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D0 || e.Key == Key.NumPad0)
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
            if (e.Key == Key.D6 && (Keyboard.IsKeyDown(Key.LeftShift)|| Keyboard.IsKeyDown(Key.RightShift)))
            {
                selectOp("^");
            }
            if (e.Key == Key.D1 && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
            {
                selectOp("!");
            }
            if (e.Key == Key.R)
            {
                selectOp("sqrt");
            }
            if (e.Key == Key.A)
            {
                selectOp("abs");
            }
        } // OnKeyDownHandler()
    } //public class: main window
} //namespace