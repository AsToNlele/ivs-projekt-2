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

namespace ivs_projekt_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int result = 0; //vysledek predchozi operace se ulozi sem
        string output = ""; //retezec, ktery se tiskne pri zadavani vypoctu
        string nmb = ""; //aktualne zadavane cislo
        string operation = ""; //ktera operace se ma provest
        int nmb1 = 0; //vzdy prvni cislo v operaci
        bool firstOp = true;
        public MainWindow()
        {
            InitializeComponent();
        }
        // tiskne cisla ihned pri jejich psani
        private void printOut(int x)
        {
            string add = x.ToString();
            nmb = nmb + add;
            output = output + add;
            txt.Text = output;
        }
        // vybere operaci tak, aby byla dale zpracovatelna v btneq
        private void selectOp(string x)
        {
            // zjistujeme, jestli chceme zadavat kompletne nove cislo do nmb1 nebo do nej nacteme vysledek predchoziho vypoctu
            if (firstOp)
            {
                nmb1 = int.Parse(nmb);
                firstOp = false;
            }
            else
            {
                nmb1 = result;
            }
            //vynulujeme nmb aby jsme do nej mohli nahravat druhe cislo v binarni operaci
            nmb = "";
            if (x == "sqrt") 
            {
                output = "\u221A ( " + output +" )";
                txt.Text = output;
                operation = x;
            }
            else if(x == "abs")
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
            printOut(9);
        }


        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            printOut(8);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            printOut(7);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            printOut(6);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            printOut(5);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            printOut(4);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            printOut(3);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            printOut(2);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            printOut(1);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            printOut(0);
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
                    result = nmb1 + int.Parse(nmb);
                    txt.Text = result.ToString();
                  

                    break;
                case "-":
                    result = nmb1 - int.Parse(nmb);
                    txt.Text = result.ToString();
                    break;
                case "*":
                    result = nmb1 * int.Parse(nmb);
                    txt.Text = result.ToString();               
                    break;
                case "/":
                    result = nmb1 / int.Parse(nmb);
                    txt.Text = result.ToString();
                    break;
                case "^":
                    result = nmb1 + int.Parse(nmb);
                    txt.Text = result.ToString();
                    break;
                case "abs":
                    result = nmb1;
                    txt.Text = result.ToString();
                    break;
                case "sqrt":
                    result = nmb1;
                    txt.Text = result.ToString();
                    break;
            }
            output = result.ToString();
        }


    }
}
