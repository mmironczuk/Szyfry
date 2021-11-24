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
    public partial class Zad2b : Page
    {
        public Zad2b()
        {
            InitializeComponent();
        }

        private void Cipher(object sender, RoutedEventArgs e)
        {
            string kod = x.Text;
            char letter = (char)('A' - 1);
            int[] tab = new int[kod.Length];
            int index = 0;
            do
            {
                letter++;
                for (int i = 0; i < kod.Length; i++)
                {
                    if (kod[i] == letter)
                    {
                        tab[index] = i;
                        index++;
                    }
                }
            } while (letter != 'Z');
            int count = kod.Length;

            if (Deszyfracja.IsChecked==false)
            {
                string tekst2 = Tekst.Text;
                string tekst = "";
                for (int i = 0; i < tekst2.Length; i++)
                {
                    if (!Char.IsWhiteSpace(tekst2[i])) tekst += tekst2[i];
                }
                string result = "";
                int ind = 0;
                int a = tab[0];
                for (int i = 0; i < tekst.Length; i++)
                {
                    if (a > tekst.Length - 1)
                    {
                        ind++;
                        a = tab[ind];
                    }
                    result += tekst[a];
                    a += count;
                }
                Result.Text = result;
            }
            else
            {
                string tekst = Tekst.Text;
                int ind = 0;
                int a = tab[0];
                char[] result = new char[tekst.Length];
                string wynik = "";
                for (int i = 0; i < tekst.Length; i++)
                {
                    if (a > tekst.Length - 1)
                    {
                        ind++;
                        a = tab[ind];
                    }
                    result[a] += tekst[i];
                    a += count;
                }
                for (int i = 0; i < tekst.Length; i++)
                {
                    wynik += result[i];
                }
                Result.Text = wynik;
            }
            
        }
    }
}
