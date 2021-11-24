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
    public partial class Zad2a : Page
    {
        public Zad2a()
        {
            InitializeComponent();
        }

        private void Cipher(object sender, RoutedEventArgs e)
        {
            string style = x.Text;
            string tekst = Tekst.Text;
            string wynik = "";
            string[] subs = style.Split('-');
            int ile = subs.Length;
            int flag = 0;
            int b = Int32.Parse(subs[0]) - 1;
            if (Deszyfracja.IsChecked==false)
            {
                for (int i = 0; i < tekst.Length; i++)
                {
                    if (b > tekst.Length - 1)
                    {
                        flag++;
                        b = Int32.Parse(subs[flag]) - 1;
                    }
                    wynik += tekst[b];
                    b += ile;
                }
                Result.Text = wynik;
            }
            else
            {
                char[] result = new char[tekst.Length];
                for(int i=0; i<tekst.Length;i++)
                {
                    if (b > tekst.Length - 1)
                    {
                        flag++;
                        b = Int32.Parse(subs[flag]) - 1;
                    }
                    result[b]= tekst[i];
                    b += ile;
                }
                for(int i=0; i<tekst.Length;i++)
                {
                    wynik += result[i];
                }
                Result.Text = wynik;
            }
        }
    }
}
