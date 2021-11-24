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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szyfry1
{
    /// <summary>
    /// Logika interakcji dla klasy Zad1.xaml
    /// </summary>
    public partial class Zad1 : Page
    {
        public Zad1()
        {
            InitializeComponent();
        }

        private void Cipher(object sender, RoutedEventArgs e)
        {
            int n = Int32.Parse(x.Text);
            string tekst = Rail.Text;
            char[,] tab = new char[n, tekst.Length];
            if (Deszyfracja.IsChecked==false)
            {
                int a = 0;
                bool flag = false;
                string wynik = "";
                if (tekst != "")
                {
                    for (int i = 0; i < tekst.Length; i++)
                    {
                        if (a == 0) flag = true;
                        if (a == n - 1) flag = false;
                        tab[a, i] = tekst[i];
                        if (flag == true) a++;
                        else a--;
                    }
                    for (int j = 0; j < n; j++)
                    {
                        for (int i = 0; i < tekst.Length; i++)
                        {
                            if (tab[j, i] != null) wynik += tab[j, i];
                        }
                    }
                }
                Result.Text = wynik;
            }
            else
            {
                int a = 0;
                bool flag = false;
                for(int i=0;i<tekst.Length;i++)
                {
                    for(int j=0; j<n;j++)
                    {
                        tab[j, i] = ' ';
                    }
                }
                for(int i=0; i<tekst.Length;i++)
                {
                    if (a == 0) flag = true;
                    if (a == n - 1) flag = false;
                    tab[a, i] = '*';
                    if (flag == true) a++;
                    else a--;
                }
                a = 0;
                for(int j=0;j<n;j++)
                {
                    for (int i = 0; i < tekst.Length; i++)
                    {
                        if (tab[j, i] == '*')
                        {
                            tab[j, i] = tekst[a];
                            a++;
                        } 
                    }
                }
                a = 0;
                string wynik="";
                for (int i = 0; i < tekst.Length; i++)
                {
                    if (a == 0) flag = true;
                    if (a == n - 1) flag = false;
                    if(tab[a, i] != ' ') wynik+=tab[a,i];
                    if (flag == true) a++;
                    else a--;
                }
                Result.Text = wynik;
            }
        }
    }
}
