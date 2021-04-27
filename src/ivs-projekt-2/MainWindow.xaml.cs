/*******************************************************************
* Název projektu: IVS projekt 2
* Soubor: MainWindow.xaml.cs
* Datum: 13.4.2021
* Poslední změna: 26.4.2021
* Autor: Dominik Klon (xklond00)
*
* Popis: Propojení GUI s matematickou knihovnou
*
*******************************************************************/
/**
* @file MainWindow.xaml.cs
*
* @brief Propojení GUI s matematickou knihovnou
* @author Dominik Klon (xklond00)
*/
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
    /// Interakční logika pro MainWindows.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            this.Closed += MainWindow_Closed;
        }

        /**
        *  Funkce na to aby se zároveň zavíralo okno kalkulačky i help okno
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown(); // s ukoncenim aplikace uzavre i help menu
        }

        /**
         * @var string output 
         * Řetězec, který se tiskne při zadavaní výpočtu
        */
        /**
         * @var string nmb 
         * Aktuálně zadávané číslo ve stringovém formátu, protože ho tvoříme postupným přidáváním charu
        */
        /**
         * @var string operation
         * Udává která operace se má provést
        */
        /**
         * @var double nmb1 
         * První číslo v operaci
         */
        /**
         * @var bool firstOp 
         *Ukazuje zda jsme v první části výrazu (true) nebo ve druhé
        */
        /**
         * @var string err 
         *Chybová hláška
        */
        string output = ""; 
        string nmb = ""; 
        string operation = ""; 
        double nmb1 = 0; 
        bool firstOp = true; 
        string err = "Syntax Error: Prosím zadejte číslo ve správném formátu."; 

        /**
        * Funkce pro tisk čísel na obrazovku
        *
        * @param x String ktere se tiskne
        */
        private void printOut(string x)
        {

            if (operation != "abs") // funkce pro absolutní hodnotu je jedina operace, ktera nedovoluje za sebe psat nova cisla
            {
                nmb = nmb + x; // pričteni xka do čísla
                output = output + x; // přidání xka do stringu na výstup
                txt.Text = output; // vytisknutí na obrazovku
            }
        }


        /**
        * Funkce pro změnu již zadané operace
        */
        // pokud je jiz uzivatel zadal nejakou operaci a rozhodl se ji zmenit, prepiseme puvodni znamenka na aktualni zadanou operaci 
        private void clearOpSigns()
        {
            if (operation != "")
            {
                output = output.Remove(output.Length - 1, 1); //odstraní operaci z výrazu
            }
            if (operation == "abs")
            {
                output = output.Remove(0, 1); //odstraní abs hodnotu z výrazu
            }
            if (operation == "sqrt")
            {
                output = output.Remove(0, 3); //odstraní odmocninu z výrazu
            }
        }
        /**
        * Funkce pro tisk operaci na obrazovku
        *
        * @param x String operace na vytisknuti
        */
        private void chooseOutput(string x)
        {
            if (x == "sqrt")
            {
                output = (output == "") ? "0" : output; //pokud ještě není zadanné žádné číslo tiskne 0, jinak tiskne celý string output
                output = "\u221A ( " + output + " ) "; // pridani znaku Sqrt do outputu a ozávorkování outputu
                txt.Text = output; // vytisknutí na obrazovku
            }
            else if (x == "abs")
            {
                output = (output == "") ? "0" : output; //pokud ještě není zadanné žádné číslo tiskne 0, jinak tiskne celý string output
                output = "| " + output + " |"; // pridani abs. čar || na výstup
                txt.Text = output; // vytisknutí na obrazovku
            }
            else
            {
                output = output + x; // pridani obycejne operace na výstup
                txt.Text = output; // vytisknutí na obrazovku
            }
        }
        /**
        * Funkce pro výběr operace
        *
        * @param x String operace na vytisknuti
        */
        // vybere operaci tak, aby byla dale zpracovatelna v btneq
        private void selectOp(string x)
        {

            if (!firstOp && operation != "") // podminka, ktera zarucuje, ze kdyz nezavolame rovna se na konci operace, zavola se samo
            {
                equals(); //vyvolání rovná se
            }

            if (firstOp)  // nahrajeme prvni cislo v operaci do nmb1 pokud se jedna o prvni cislo
            {
                // nmb1 = double.Parse(nmb);
                if (!double.TryParse(nmb, out nmb1)) //nahrátí prvního čísla do nmb1
                {
                    txt.Text = err; // eror hláška
                }
                firstOp = false;
            }
            clearOpSigns(); //smazani operace
            chooseOutput(x); //vyber operace tisku na obrazovku

            nmb = "";  //vynulujeme nmb aby jsme do nej mohli nahravat druhe cislo v binarni operaci
            operation = x; //nahrajeme operaci do globalni promeně
        }

        /**
        * Funkce pro kontrolu sqrt
        *
        */
        // Osetreni square funkce proti nezadanemu 2. cislu, zadane nule a zadanemu des. cislu
        private void fixedSqrt()
        {
            if (nmb == "") //pokud druhe čislo prazdne
            {
                nmb = MathCalc.Root(nmb1, 2).ToString(); // automaticky provádíme druhou odmocninu
                txt.Text = nmb; //zobrazeni na vystup
            }
            else
            {
                int sqrtNmb = 0;
                if (int.TryParse(nmb, out sqrtNmb)) // pokud je druhe cislo integer
                {
                    nmb = MathCalc.Root(nmb1, sqrtNmb).ToString(); //provedeme odmocněni
                    txt.Text = nmb;
                }
                else
                {
                    txt.Text = err; //pokud je číslo desetinné tak vyhlásit eror 
                }
            }
        }

        /**
        * Funkce pro výpočet výrazu
        *
        */
        private void equals()
        {
            double nmb2 = 0;
            // zkousime parsovat nmb do nmb2, pokud to nevyjde vypiseme chybovou hlasku
            // nmb2 ale nepotrebujeme do unarnich operaci a tak u nich chybu nevypisujeme
            if (double.TryParse(nmb, out nmb2) || operation == "sqrt" || operation == "!" || operation == "abs")
            {
                // switch vybere operaci a zavola funkci z knihovny CalcMath
                switch (operation)
                {
                    case "+": //pokud plus
                        nmb = MathCalc.Add(nmb1, nmb2).ToString(); //volání z knihovny MathCalc + prevedeni na String
                        txt.Text = nmb; // vytisknutí na obrazovku
                        break;
                    case "-": //pokud minus
                        nmb = MathCalc.Sub(nmb1, nmb2).ToString(); //volání z knihovny MathCalc + prevedeni na String
                        txt.Text = nmb; // vytisknutí na obrazovku
                        break;
                    case "*": //pokud krát
                        nmb = MathCalc.Mul(nmb1, nmb2).ToString(); //volání z knihovny MathCalc + prevedeni na String
                        txt.Text = nmb; // vytisknutí na obrazovku
                        break;
                    case "/": //pokud děleno
                        nmb = MathCalc.Div(nmb1, nmb2).ToString(); //volání z knihovny MathCalc + prevedeni na String
                        txt.Text = nmb; // vytisknutí na obrazovku
                        break;
                    case "^": //pokud mocnění
                        if (nmb2 % 1 == 0) // číslo musí být celé číslo
                        {
                            nmb = MathCalc.Pow(nmb1, (int)nmb2).ToString(); //volání z knihovny MathCalc + prevedeni na String
                            txt.Text = nmb; // vytisknutí na obrazovku
                        }
                        else
                        {
                            txt.Text = err; // vytisknutí chyby pokud není celé číslo
                        }
                        break;
                    case "abs":
                        nmb = MathCalc.Abs(nmb1).ToString(); //volání z knihovny MathCalc + prevedeni na String
                        txt.Text = nmb; // vytisknutí na obrazovku
                        break;
                    case "sqrt":
                        fixedSqrt(); //volání kontrolující funkce sqrt
                        break;
                    case "!": 
                        nmb = MathCalc.Fact(nmb1).ToString(); //volání z knihovny MathCalc + prevedeni na String
                        txt.Text = nmb; // vytisknutí na obrazovku
                        break;
                    case "":
                        // pri kliknuti na rovna se bez zadane operace se nic neprovede
                        break;
                    default:
                        txt.Text = err; //pri nezadane operaci vyhodí eror
                        break;
                }
                output = nmb; //nacten nové číslo na výstup
                operation = ""; // po rovna se zacina nova operace
                firstOp = true; // po zmacknuti rovna se se dostavame na zacatek dalsi operace
            } //if tryParse(nmb)
            else
            {
                txt.Text = err; //pri nezadane operaci vyhodí eror
            }
        }
        /**
        * Funkce pro smazání části výrazu
        *
        */
        //smaze posledni cifru cisla, s kterym zrovna pracujeme tj. bud prvni nebo druhe cislo v binarni operaci
        private void delete()
        {
            //podminka proto, aby jsme nezacali mazat chary ze stringu ve kterem uz zadne nejsou
            if (nmb.Length > 0)
            {
                output = output.Remove(output.Length - 1, 1); //smazani z outputu
                nmb = nmb.Remove(nmb.Length - 1, 1); //smazani z čísla
                txt.Text = output; //upraveny output
            }
        }
        /**
        * Funkce pro smazání všeho
        *
        */
        private void clearAll()
        {
            //nastavi vsechny promenne do defaultniho stavu
            firstOp = true;
            output = "";
            nmb = "";
            nmb1 = 0;
            operation = "";
            txt.Text = output;
        }
        /**
        * Funkce pro smazání aktuálně zadávaného čísla
        *
        */
        private void clear()
        {
            while (nmb.Length > 0) //mažeme dokud nějaké číslo existuje
            {
                output = output.Remove(output.Length - 1, 1); //smazani z outputu
                nmb = nmb.Remove(nmb.Length - 1, 1); //Smazani z čisla
            }
            txt.Text = output; //upraveny output
        }
        /**
        * Funkce pro vyvolání nabídky HELP
        *
        */
        private void showHelp()
        {
            Help help = new Help(); //inicializace nového Helpu
            help.Show(); // zobrazení helpu
        }

        /*
         * ZACHYTAVANI EVENTU
         */

        //ovládání přes GUI
        /**
        * Funkce ktera nic neděla
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /**
        * Funkce pro klikání tlačítka 9
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            printOut("9"); //vytiskne 9
        }

        /**
        * Funkce pro klikání tlačítka 8
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            printOut("8"); //vytiskne 9
        }
        /**
        * Funkce pro klikání tlačítka 7
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            printOut("7"); // vytiskne 7
        }
        /**
        * Funkce pro klikání tlačítka 6
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            printOut("6"); // vytiskne 6
        }
        /**
        * Funkce pro klikání tlačítka 5
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            printOut("5"); //vytiskne 5
        }
        /**
        * Funkce pro klikání tlačítka 4
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            printOut("4"); //vytiskne 4
        }
        /**
        * Funkce pro klikání tlačítka 3
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            printOut("3"); //vytiskne 3
        }
        /**
        * Funkce pro klikání tlačítka 2
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            printOut("2"); //vytiskne 2
        }
        /**
        * Funkce pro klikání tlačítka 1
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            printOut("1"); //vytiskne 1
        }
        /**
        * Funkce pro klikání tlačítka 0
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            printOut("0"); //vytiskne 0
        }
        /**
        * Funkce pro klikání tlačítka ,
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnco_Click(object sender, RoutedEventArgs e)
        {
            printOut(","); //vytiskne ,
        }

        //OPERACE
        /**
        * Funkce pro klikání tlačítka +
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnpl_Click(object sender, RoutedEventArgs e)
        {
            selectOp("+"); //vybere operaci +
        }
        /**
        * Funkce pro klikání tlačítka -
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnmi_Click(object sender, RoutedEventArgs e)
        {
            selectOp("-"); //vybere operaci -
        }
        /**
        * Funkce pro klikání tlačítka *
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnti_Click(object sender, RoutedEventArgs e)
        {
            selectOp("*"); //vybere operaci *
        }
        /**
        * Funkce pro klikání tlačítka /
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btndi_Click(object sender, RoutedEventArgs e)
        {
            selectOp("/"); //vybere operaci /
        }
        /**
        * Funkce pro klikání tlačítka !
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnfa_Click(object sender, RoutedEventArgs e)
        {
            selectOp("!"); //vybere operaci faktorial
        }
        /**
        * Funkce pro klikání tlačítka ^
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnpo_Click(object sender, RoutedEventArgs e)
        {
            selectOp("^");  //vybere operaci mocnina
        }
        /**
        * Funkce pro klikání tlačítka sqrt
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnsq_Click(object sender, RoutedEventArgs e)
        {
            selectOp("sqrt"); //vybere operaci odmocnina
        }
        /**
        * Funkce pro klikání tlačítka abs
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnab_Click(object sender, RoutedEventArgs e)
        {
            selectOp("abs"); //vybere operaci abs
        }

        // FUNKCE
        /**
        * Funkce pro klikání tlačítka =
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btneq_Click(object sender, RoutedEventArgs e)
        {
            equals(); //vyvola vyhodnoceni výrazu
        }
        /**
        * Funkce pro klikání tlačítka =
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnde_Click(object sender, RoutedEventArgs e)
        {
            delete(); //smaže poslední číslo/operaci
        }
        /**
        * Funkce pro klikání tlačítka C
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnc_Click(object sender, RoutedEventArgs e)
        {
            clearAll(); //smaže všechno
        }
        /**
        * Funkce pro klikání tlačítka CE
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnce_Click(object sender, RoutedEventArgs e)
        {
            clear();  //smaže aktualne zadavane čislo
        }

        //  ovladání přes klávesnici
        /**
        * Funkce pro ovládání tlačítek přes klávesnici
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            // CISLA 

            if (e.Key == Key.D0 || e.Key == Key.NumPad0) //klavesa 0
            {
                printOut("0"); //tisk zvolene klavesy
            }
            if ((e.Key == Key.D1 || e.Key == Key.NumPad1) && !(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))) //klavesa 1
            {
                printOut("1"); //tisk zvolene klavesy
            }
            if (e.Key == Key.D2 || e.Key == Key.NumPad2) //klavesa 2
            {
                printOut("2"); //tisk zvolene klavesy
            }
            if (e.Key == Key.D3 || e.Key == Key.NumPad3) //klavesa 3
            {
                printOut("3"); //tisk zvolene klavesy
            }
            if (e.Key == Key.D4 || e.Key == Key.NumPad4) //klavesa 4
            { 
                printOut("4"); //tisk zvolene klavesy
            } 
            if (e.Key == Key.D5 || e.Key == Key.NumPad5) //klavesa 5
            {
                printOut("5"); //tisk zvolene klavesy
            }
            if ((e.Key == Key.D6 || e.Key == Key.NumPad6) && !(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))) //klavesa 6
            { 
                printOut("6"); //tisk zvolene klavesy
            }
            if (e.Key == Key.D7 || e.Key == Key.NumPad7)  //klavesa 7
            {
                printOut("7"); //tisk zvolene klavesy
            }
            if ((e.Key == Key.D8 || e.Key == Key.NumPad8) && !(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))) //klavesa 8
            {
                printOut("8"); //tisk zvolene klavesy
            }
            if (e.Key == Key.D9 || e.Key == Key.NumPad9) //klavesa 9
            { 
                printOut("9"); //tisk zvolene klavesy
            }
            if (e.Key == Key.OemComma || e.Key == Key.Decimal) //klavesa ,
            {
                printOut(","); //tisk zvolene klavesy
            } 

            //OPERACE

            if (e.Key == Key.OemPlus || e.Key == Key.Add) //klavesa +
            {
                selectOp("+"); //zvoleni prislusne operace
            }
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract) //klavesa -
            {
                selectOp("-"); //zvoleni prislusne operace
            }
            if (e.Key == Key.Multiply || (e.Key == Key.D8 && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))) //klavesa *
            {
                selectOp("*"); //zvoleni prislusne operace
            }
            if (e.Key == Key.Divide || e.Key == Key.OemOpenBrackets || e.Key == Key.OemQuestion)  //klavesa /
            {
                selectOp("/"); //zvoleni prislusne operace
            }
            if (e.Key == Key.D6 && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))) //klavesa  ^
            {
                selectOp("^"); //zvoleni prislusne operace
            } 
            if (e.Key == Key.D1 && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))  //klavesa  !
            {
                selectOp("!"); //zvoleni prislusne operace
            }
            if (e.Key == Key.R) //klavesa  R
            {
                selectOp("sqrt"); //zvoleni prislusne operace
            }
            if (e.Key == Key.A) //klavesa  A
            {
                selectOp("abs"); //zvoleni prislusne operace
            }

            //FUNKCE

            if (e.Key == Key.Enter) //klavesa enter
            {
                equals(); //vyhodnoceni vyrazu
            }
            if (e.Key == Key.Back) //klavesa backspace
            {
                delete(); //smazani čisla
            }
            if (e.Key == Key.C) //klavesa C
            {
                clear(); //smazani celeho čisla
            }
            if (e.Key == Key.Delete) //klavesa DELETE
            {
                clearAll(); //smazani vyrazu
            }
        } // OnKeyDownHandler()
        /**
        * Funkce pro tlačítko HELP
        * @param sender uchovává který objekt zavoval událost
        * @param e Data události
        */
        private void btnhe_Click(object sender, RoutedEventArgs e)
        {
            showHelp(); //zobrazí HELP
        }
    }
}
/*** Konec souboru MainWindow.xaml.cs ***/