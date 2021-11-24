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

namespace Szyfry1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cipher(object sender, RoutedEventArgs e)
        {
            int n = Int32.Parse(x.Text);
            string tekst = Rail.Text;
            char[,] tab = new char[n, tekst.Length];
            if (Deszyfracja.IsChecked == false)
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
                for (int i = 0; i < tekst.Length; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        tab[j, i] = ' ';
                    }
                }
                for (int i = 0; i < tekst.Length; i++)
                {
                    if (a == 0) flag = true;
                    if (a == n - 1) flag = false;
                    tab[a, i] = '*';
                    if (flag == true) a++;
                    else a--;
                }
                a = 0;
                for (int j = 0; j < n; j++)
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
                string wynik = "";
                for (int i = 0; i < tekst.Length; i++)
                {
                    if (a == 0) flag = true;
                    if (a == n - 1) flag = false;
                    if (tab[a, i] != ' ') wynik += tab[a, i];
                    if (flag == true) a++;
                    else a--;
                }
                Result.Text = wynik;
            }
        }

        private void Cipher2a(object sender, RoutedEventArgs e)
        {
            string style = x2a.Text;
            string tekst = Tekst2a.Text;
            string wynik = "";
            string[] subs = style.Split('-');
            int ile = subs.Length;
            int iter = 0;
            int flag = 0;
            int rows= (tekst.Length/subs.Length)+1;
            char[,] tab = new char[rows, subs.Length];
            int b = Int32.Parse(subs[0]) - 1;
            if (Deszyfracja2a.IsChecked == false)
            {
                for(int i=0; i<rows;i++)
                {
                    for(int j=0; j<subs.Length;j++)
                    {
                        if (iter < tekst.Length) tab[i, j] = tekst[iter];
                        else tab[i, j] = '#';
                        iter++;
                    }
                }
                int row = 0;
                for(int i=0;i<rows;i++)
                {
                    for(int j=0; j<subs.Length;j++)
                    {
                        if (flag == subs.Length)
                        {
                            flag = 0;
                            row++;
                        }
                        if (tab[row, Int32.Parse(subs[flag]) - 1].CompareTo('#') != 0) wynik += tab[row, Int32.Parse(subs[flag]) - 1];
                        flag++;
                    }
                }
                Result2a.Text = wynik;
            }
            else
            {
                int row = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < subs.Length; j++)
                    {
                        if (flag == subs.Length)
                        {
                            flag = 0;
                            row++;
                        }
                        if (iter < tekst.Length&&((i*subs.Length+Int32.Parse(subs[flag]))<=tekst.Length))
                        {
                            tab[row, Int32.Parse(subs[flag]) - 1] = tekst[iter];
                            iter++;
                        }
                        flag++;
                    }
                }
                iter = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < subs.Length; j++)
                    {
                        if (iter < tekst.Length) wynik+=tab[i,j];
                        iter++;
                    }
                }
                Result2a.Text = wynik;
            }
        }

        private void Cipher2b(object sender, RoutedEventArgs e)
        {
            string kod = x2b.Text;
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

            if (Deszyfracja2b.IsChecked == false)
            {
                string tekst2 = Tekst2b.Text;
                string tekst = "";
                for (int i = 0; i < tekst2.Length; i++)
                {
                    if (!Char.IsWhiteSpace(tekst2[i])) tekst += tekst2[i];
                }
                string result = "";
                int ind = 0;
                int a = tab[0];
                int iters = 0;
                if (tekst.Length > kod.Length) iters = tekst.Length;
                else iters = kod.Length;
                for (int i = 0; i < iters; i++)
                {
                    if (a > tekst.Length - 1&&ind<tab.Length-1)
                    {
                        ind++;
                        a = tab[ind];
                    }
                    if(a<tekst.Length) result += tekst[a];
                    a += count;
                }
                Result2b.Text = result;
            }
            else
            {
                string tekst = Tekst2b.Text;
                int ind = 0;
                int a = tab[0];
                string wynik = "";
                int rows = (tekst.Length / kod.Length)+1;
                char[,] resTab = new char[rows, kod.Length];

                for(int i=0; i<rows;i++)
                {
                    for(int j=0; j<kod.Length;j++)
                    {
                        if (ind < tekst.Length)
                        {
                            resTab[i, j] = '.';
                            ind++;
                        }
                        else resTab[i, j] = '#';
                    }
                }
                ind = 0;
                int iterator = 0;
                int row = 0;
                for(int i=0; i<kod.Length; i++)
                {
                    a = tab[ind];
                    while(row<rows)
                    {
                        if (resTab[row, a].CompareTo('#') != 0)
                        {
                            resTab[row, a] = tekst[iterator];
                            iterator++;
                        }
                        row++;
                    }
                    ind++;
                    row = 0;
                }
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < kod.Length; j++)
                    {
                        if (resTab[i, j].CompareTo('#') != 0) wynik += resTab[i, j];
                    }
                }
                Result2b.Text = wynik;
            }
        }

        private void Cipher2c(object sender, RoutedEventArgs e)
        {
            string kod = x2c.Text;
            string tekst2 = Tekst2c.Text;
            string tekst = "";
            for (int i = 0; i < tekst2.Length; i++)
            {
                if (!Char.IsWhiteSpace(tekst2[i])) tekst += tekst2[i];
            }
            Result2c.Text = tekst;
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
            int cols = 0, rows = 1;
            for (int i = 0; i < tekst.Length; i++)
            {
                    if (cols == tab[rows - 1])
                    {
                        cols = 0;
                        rows++;
                        continue;
                    }
                    cols++;
            }
            char[,] res = new char[rows, kod.Length];

            if (Deszyfracja2c.IsChecked == false)
            {
                int iter = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < kod.Length; j++)
                    {
                        if (j <= tab[i] && iter < tekst.Length)
                        {
                            res[i, j] = tekst[iter];
                            iter++;
                        }
                        else res[i, j] = '#';
                    }
                }
                string result = "";
                for (int i = 0; i < kod.Length; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if (res[j, tab[i]].CompareTo('#') != 0) result += res[j, tab[i]];
                    }
                }
                Result2c.Text = result;
            }
            else
            {
                int iter = 0;
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < kod.Length; j++)
                    {
                        if (j <= tab[i] && iter < tekst.Length)
                        {
                            res[i, j] = '.';
                            iter++;
                        }
                        else res[i, j] = '#';
                    }
                }
                iter = 0;
                for(int i=0; i<kod.Length;i++)
                {
                    for(int j=0; j<rows;j++)
                    {
                        if (res[j, tab[i]] == '.')
                        {
                            res[j, tab[i]] = tekst[iter];
                            iter++;
                        }
                    }
                }
                string result = "";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < kod.Length; j++)
                    {
                        if (res[i,j].CompareTo('#') != 0) result += res[i,j];
                    }
                }
                Result2c.Text = result;
            }
        }

        private void Cipher3(object sender, RoutedEventArgs e)
        {
            int a = Int32.Parse(k0.Text);
            int b = Int32.Parse(k1.Text);
            string tekst = Tekst3.Text;
            string result = "";
            if(Deszyfracja3.IsChecked==false)
            {
                for (int i = 0; i < tekst.Length; i++)
                {
                    result += (char)('A' + ((tekst[i] - 'A') * b + a) % 26);
                }
                Result3.Text = result;
            }
            else
            {
                int n= 12;
                for(int i=0; i<tekst.Length;i++)
                {
                    result += (char)('A'+(((tekst[i] - 'A') + (26 - a))) * Math.Pow(b, n - 1) % 26);
                }
                Result3.Text = result;
            }
        }

        private void Cipher4(object sender, RoutedEventArgs e)
        {
            char[,] tab = new char[26, 26];
            string kod = x4.Text;
            string tekst = Tekst4.Text;
            char letter = 'A';
            for(int i=0; i<26; i++)
            {
                letter = (char)('A' + i);
                for(int j=0; j<26; j++)
                {
                    tab[i, j] = (char)('A' + ((letter + j - 'A') % 26));
                }
            }

            int ind = 0, length=0;
            bool flag = false;
            if(tekst.Length>kod.Length)
            {
                length = kod.Length;
                for(int i=0;i<tekst.Length;i++)
                {
                    if (ind == length)
                    {
                        ind = 0;
                        flag = true;
                    }
                    if (flag) kod += kod[ind];
                    ind++;
                }
            }
            else if(kod.Length>tekst.Length)
            {
                length = tekst.Length;
                for (int i = 0; i < kod.Length; i++)
                {
                    if (ind == length)
                    {
                        ind = 0;
                        flag = true;
                    }
                    if (flag) tekst += tekst[ind];
                    ind++;
                }
            }

            string result = "";
            if(Deszyfracja4.IsChecked==false)
            {
                for(int i=0; i<tekst.Length;i++)
                {
                    result += tab[tekst[i] - 'A', kod[i] - 'A'];
                }
                Result4.Text = result;
            }
            else
            {
                for(int i=0; i<tekst.Length; i++)
                {
                    if (tekst[i] - kod[i] >= 0) result += (char)('A' + (tekst[i] - kod[i]));
                    else result += (char)('A' + 26 -(kod[i] - tekst[i]));
                }
                Result4.Text = result;
            }
        }

        public char XOR(char p, char q)
        {
            return p == q ? '0' : '1';
        }

        private void LFSR2(object sender, RoutedEventArgs e)
        {
            string lfsr = lfsrtext.Text;
            string Seed = seed1.Text;
            string wiel = wiel1.Text;
            Res1.Text = LFSR(lfsr, Seed, wiel);
        }

        public string LFSR(string tekst, string Seed, string wiel)
        {
            string row = "";
            string res = "";
            bool flag = false;
            char znak = '0';
            for (int i = 0; i < tekst.Length; i++)
            {
                znak = '0';
                for (int j = 0; j < wiel.Length; j++)
                {
                    if (Seed[j] == '1' && wiel[j] == '1') znak = XOR(znak, '1');
                }
                row += znak;
                for (int j = 0; j < Seed.Length - 1; j++) row += Seed[j];
                res += row[0];
                Seed = row;
                row = "";
            }
            return res;
        }

        private void Sync(object sender, RoutedEventArgs e)
        {
            string tekst = sync.Text;
            string Seed = seed2.Text;
            string wiel = wiel2.Text;
            string Lfsr = LFSR(tekst, Seed, wiel);
            string res = "";
            char znak;
            for(int i=0; i<tekst.Length; i++)
            {
                znak = XOR(Lfsr[i], tekst[i]);
                res += znak;
            }
            Res2.Text = res;
        }

        private void Autokey(object sender, RoutedEventArgs e)
        {
            string tekst = autokey.Text;
            string Seed = seed3.Text;
            string wiel = wiel3.Text;
            char znak='0';
            bool flag = false;
            string row = "";
            string res = "";
            if (DeszyfracjaLsfr.IsChecked==false)
            {
                for (int i = 0; i < tekst.Length; i++)
                {
                    znak = '0';
                    for (int j = 0; j < wiel.Length; j++)
                    {
                        if (Seed[j] == '1' && wiel[j] == '1') znak = XOR(znak, '1');
                    }
                    znak = XOR(tekst[i], znak);
                    row += znak;
                    for (int j = 0; j < Seed.Length - 1; j++) row += Seed[j];
                    res += row[0];
                    Seed = row;
                    row = "";
                }
            }
            else
            {
                for (int i = 0; i < tekst.Length; i++)
                {
                    znak = '0';
                    for (int j = 0; j < wiel.Length; j++)
                    {
                        if (Seed[j] == '1' && wiel[j] == '1') znak = XOR(znak, '1');
                    }

                    znak = XOR(tekst[i], znak);
                    row += tekst[i];
                    for (int j = 0; j < Seed.Length - 1; j++) row += Seed[j];
                    res += znak;
                    Seed = row;
                    row = "";
                }
            }
            Res3.Text = res;
        }

        private void DES(object sender, RoutedEventArgs e)
        {
            string key = Key.Text;
            string tekst = DEStekst.Text;
            int blocks = tekst.Length / 64;
            if (tekst.Length % 64 != 0) blocks++;
            string end = "";
            string block = "";
            block = tekst.Substring(0, 64);
            string blockPerm = InitialPermutation(block);

            string LB = blockPerm.Substring(0, 32);
            string RB = blockPerm.Substring(32, 32);

            string[] subs = keysDES(key);

            string[] Right = new string[16];
            string[] Left = new string[16];
            string init = RB;


            for (int i = 0; i < 16; i++)
            {
                if (i != 0)
                {
                    RB = Right[i - 1];
                    LB = Left[i - 1];
                    init = RB;
                }
                RB = ExtendPermutation(RB);
                RB = MultiXOR(RB, subs[i]);

                string data = "";

                for (int j = 0; j < 8; j++)
                {
                    string sub = RB.Substring(j * 6, 6);
                    data += readTableData(sub, j);
                }
                string tabledata = Permutation(data);

                Right[i] = MultiXOR(LB, tabledata);
                Left[i] = init;
            }
            string res = Right[15] + Left[15];
            end = ReversePermutation(res);

            Res4.Text += end;
        }

        public string MultiXOR(string s1, string s2)
        {
            if (s1.Length != s2.Length) return "";

            string tekst = "";

            for (int i = 0; i < s1.Length; i++)
            {
                tekst+= XOR(s1[i], s2[i]);
            }
            return tekst;
        }

        public string InitialPermutation(string key)
        {
            int[] tab = new int[] {58,50,42,34,26,18,10,2,60,52,44,36,28,20,12,4,62,54,
                                  46,38,30,22,14,6,64,56,48,40,32,24,16,8,57,49,41,33,
                                  25,17,9,1,59,51,43,35,27,19,11,3,61,53,45,37,29,21,
                                  13,5,63,55,47,39,31,23,15,7};

            string tekst = "";
            for (int i = 0; i < tab.Length; i++)
            {
                tekst += key[tab[i] - 1];
            }
            return tekst;
        }

        public string[] keysDES(string Key)
        {
            string key = permutedChoice_PC(Key);
            int[] bits = new int[] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };
            string[] subs = new string[bits.Length];
            for (int i = 0; i < bits.Length; i++)
            {
                string C = key.Substring(0, 28);
                string D = key.Substring(28, 28);
                key = cut(C, bits[i]) + cut(D, bits[i]);
                subs[i] = permutedChoice_PC2(key);
            }
            return subs;
        }

        public string cut(string tekst, int point)
        {
            string x = tekst.Substring(0, point);
            tekst = tekst.Remove(0, point);
            tekst += x;
            return tekst;
        }


        public string permutedChoice_PC(string key)
        {
            int[] tab = new int[] { 57, 49, 41, 33, 25, 17, 9, 1, 58, 50, 42, 34, 26,
                                   18, 10, 2, 59, 51, 43, 35, 27, 19, 11, 3, 60, 52,
                                   44, 36, 63, 55, 47, 39, 31, 23, 15, 7, 62, 54, 46,
                                   38, 30, 22, 14, 6, 61, 53, 45, 37, 29, 21, 13, 5,
                                   28, 20, 12, 4 };

            string tekst = "";
            for (int i = 0; i < tab.Length; i++)
            {
                tekst += key[tab[i] - 1];
            }
            return tekst;
        }

        private string permutedChoice_PC2(string key)
        {
            int[] tab = new int[] { 14,17,11,24,1,5,3,28,15,6,21,10,
                                   23,19,12,4,26,8,16,7,27,20,13,2,
                                   41,52,31,37,47,55,30,40,51,45,33,48,
                                   44,49,39,56,34,53,46,42,50,36,29,32};

            string tekst = "";
            for (int i = 0; i < tab.Length; i++)
            {
                tekst += key[tab[i] - 1];
            }
            return tekst;
        }

        public string ExtendPermutation(string key)
        {
            int[] tab = new int[] { 32,1,2,3,4,5,4,5,6,7,8,9,
                                   8,9,10,11,12,13,12,13,14,15,16,17,
                                   16,17,18,19,20,21,20,21,22,23,24,25,
                                   24,25,26,27,28,29,28,29,30,31,32,1};

            string tekst = "";
            for (int i = 0; i < tab.Length; i++)
            {
                tekst += key[tab[i] - 1];
            }
            return tekst;
        }

        public string Permutation(string key)
        {
            int[] tab = new int[] { 16, 7, 20, 21, 29, 12, 28, 17, 1, 15, 23,
                                   26, 5, 18, 31, 10, 2, 8, 24, 14, 32, 27, 3,
                                   9, 19, 13, 30, 6, 22, 11, 4, 25 };

            string tekst = "";
            for (int i = 0; i < tab.Length; i++)
            {
                tekst += key[tab[i] - 1];
            }
            return tekst;
        }


        public string ReversePermutation(string key)
        {
            int[] tab = new int[] {40,8,48,16,56,24,64,32,39,7,47,15,55,23,63,31,
                                  38,6,46,14,54,22,62,30,37,5,45,13,53,21,61,29,
                                  36,4,44,12,52,20,60,28,35,3,43,11,51,19,59,27,
                                  34,2,42,10,50,18,58,26,33,1,41,9,49,17,57,25};

            string tekst = "";
            for (int i = 0; i < tab.Length; i++)
            {
                tekst += key[tab[i] - 1];
            }
            return tekst;
        }

        public string readTableData(string bit, int s)
        {
            int row = Convert.ToInt32(bit[0].ToString() + bit[bit.Length - 1], 2);
            int column = Convert.ToInt32(bit.Substring(1, 4), 2); 

            int[,] dataTables =
                {
            {
            14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7,
            0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8,
            4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0,
            15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13,
            },
            {
            15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10,
            3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5,
            0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15,
            13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9,
            },
            {
            10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8,
            13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1,
            13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7,
            1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12,
            },
            {
            7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15,
            13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9,
            10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4,
            3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14,
            },
            {
            2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9,
            14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6,
            4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14,
            11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3,
            },
            {
            12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11,
            10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8,
            9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6,
            4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13,
            },
            {
            4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1,
            13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6,
            1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2,
            6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12,
            },
            {
            13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7,
            1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2,
            7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8,
            2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}
            };

            string result = Convert.ToString(dataTables[s, 16 * row + column], 2);
            return result.Length == 4 ? result : completeSequence(result, 4);
        }

        private string completeSequence(string result, int v)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < v - result.Length; i++)
            {
                sb.Append(0);
            }
            sb.Append(result);
            return sb.ToString();
        }
    }
}
