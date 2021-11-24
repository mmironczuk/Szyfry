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
    public partial class Zad2c : Page
    {
        public Zad2c()
        {
            InitializeComponent();
        }

        private void Cipher(object sender, RoutedEventArgs e)
        {
            string kod = x.Text;
            string tekst = Tekst.Text;
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
            int b = 0;
            int a = 0;
            for(int i=0; i<tekst.Length;i++)
            {
                //if()
            }
        }
    }
}
