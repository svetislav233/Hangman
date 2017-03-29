using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "lampa", "monitor", "microsoft", "tanjir", "tastatura", "pas", "macka", "sto", "stolica", "fenjer" };
            Random r = new Random();
            int br = r.Next(0, arr.Length);
            string rec = arr[br];
            WriteLine(String.Concat(Enumerable.Repeat("_ ", rec.Length)));
            string[] recAr = new string[rec.Length];
            for (int i = 0; i < rec.Length; i++)
            {
                recAr[i] = Convert.ToString(rec[i]);
            }
            string[] trenutno = new string[rec.Length];
            for (int i = 0; i < rec.Length; i++)
            {
                trenutno[i] = "_ ";
            }
            List<string> lst = trenutno.ToList();
            int brPok = 15;
            List<string> lst2 = new List<string>();
            while (true && brPok > 0)
            {
                Write("\n\nPogadjaj: ");
                try
                {
                    string s = ReadLine();
                    if (lst2.Contains(s))
                    {
                        WriteLine("\n vec ste probali to slovo");
                    }
                    else
                    {
                        for (int i = 0; i < rec.Length; i++)
                        {
                            if (s == Convert.ToString(rec[i]))
                            {
                                lst.Insert(i, s);
                                lst.RemoveAt(i + 1);
                            }
                        }
                        if (rec.Contains(s))
                        {
                            WriteLine("\nPogodak");
                            lst2.Add(s);
                        }
                        else
                        {
                            brPok--;
                            WriteLine($"\nPromasaj, imate jos {brPok}");
                            lst2.Add(s);
                        }
                        foreach (string i in lst)
                        {
                            Write(i);
                        }
                        string joined = String.Join("", lst.ToArray());
                        if (joined == rec)
                        {
                            WriteLine("\npobedili ste");
                            break;
                        }
                    }
                }
                catch
                {
                    WriteLine("pogresan unos");
                }
            }
            ReadKey();
        }
    }
}
