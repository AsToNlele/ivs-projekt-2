/*******************************************************************
* Název projektu: IVS projekt 2
* Soubor: MainWindow.xaml.cs
* Datum: 13.4.2021
* Poslední změna: 26.4.2021
* Autor: Dominik Klon (xklond00)
*
* Popis: Okno Help
*
*******************************************************************/
/**
* @file Help.xaml.cs
*
* @brief Okno Help
* @author Dominik Klon (xklond00)
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ivs_projekt_2
{
    /// <summary>
    /// Interakční logika pro Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        /**
        *   Funkce pro inicializaci okna
        */
        public Help()
        {
            InitializeComponent();
        }
        /**
        *   Funkce která nic neděla
        */
        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
/*** Konec souboru Help.xaml.cs ***/
