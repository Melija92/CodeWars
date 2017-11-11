using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(NextBiggerNumber(144));

    }
    //ako
    public static long NextBiggerNumber(long n)
    {
        var charovi = n.ToString().ToCharArray();
        bool istina = false;
        int pozicija = 0;
        for (int i = charovi.Length - 1; i >= 0; i--)
        {
            if (i == 0)
                break;
            if (charovi[i - 1] < charovi[i])
            {
                istina = true;
                pozicija = i - 1;
                break;
            }
        }

        if (istina == false)
            return -1;
        else
        {
            string premjesten = new string(charovi);
            string prviDio = premjesten.Substring(0, pozicija);
            var pivot = premjesten[pozicija].ToString();
            var zadnjiDio = premjesten.Remove(0, pozicija + 1).OrderBy(a => a).ToArray();
            var zaLoop = new string(premjesten.Remove(0, pozicija + 1).OrderBy(a => a).ToArray());
            char[] noviString;
            string zadnjiString;
            string noviPivot;
            for (int i = 0; i < zaLoop.Length; i++)
            {

                if (Int32.Parse(zaLoop[i].ToString()) > Int32.Parse(pivot))
                {
                    noviPivot = zadnjiDio[i].ToString();
                    string privremeno = zaLoop.Remove(i, 1);
                    noviString = String.Format("{0}{1}", privremeno, pivot)
                        .OrderBy(a => a)
                        .ToArray();
                    zadnjiString = new string(noviString);
                    return long.Parse(String.Format("{0}{1}{2}", prviDio, noviPivot, zadnjiString));
                }
            }
            return -1;
        }
    }


    public static string SplitCamelCase(string input)
    {
        return System.Text.RegularExpressions.Regex.Replace(input, "([A-Z])", " $1", System.Text.RegularExpressions.RegexOptions.Compiled).Trim();
    }
    //kao što i naslov govori
    public static string BreakCamelCase(string str)
    {
        var listaRijeci = new List<string>();
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsUpper(str[i]))
            {
                listaRijeci.Add(str.Remove(i));
            }
        }
        listaRijeci.Add(str);
        for (int i = listaRijeci.Count - 1; i >= 0; i--)
        {
            if (i == 0)
                continue;
            else if (listaRijeci[i].Contains(listaRijeci[i - 1]))
            {
                listaRijeci[i] = listaRijeci[i].Replace(listaRijeci[i - 1], "");
            }
        }
        return String.Join(" ", listaRijeci);
    }

    //vraćanje 5 najvećih brojeva (za redom) u nekom dobivenom broju
    public static int GetNumber(string str)
    {
        int najveciBroj = 0;
        for (int i = 0; i < str.Length - 4; i++)
        {
            var broj = int.Parse(str.Substring(i, 5));
            if (broj > najveciBroj)
            {
                najveciBroj = broj;
            }
        }
        return najveciBroj;
    }

    //validiranje pina (4 do 6 znakova, samo brojevi)
    public static bool ValidatePin(string pin)
    {
        if (pin.Length != 4 && pin.Length != 6)
            return false;
        foreach (var item in pin)
        {
            if (Char.IsDigit(item) == false)
                return false;
        }

        return true;
    }

    //ispisivanje dijamanta
    public static string print(int n)
    {
        var expected = new StringBuilder();
        if (n % 2 == 0 || 0 > n)
            return null;
        for (int i = 1; i <= n * 2; i++)
        {
            if (i % 2 == 0)
                continue;
            else if (i > n)
            {
                var noviBroj = (n * 2) - i;
                var prazni = String.Concat(Enumerable.Repeat(" ", (n - noviBroj) / 2));
                expected.Append(String.Format("{0}{1}\n", prazni, String.Concat(Enumerable.Repeat("*", noviBroj))));
            }
            else
            {
                var prazni2 = String.Concat(Enumerable.Repeat(" ", (n - i) / 2));
                expected.Append(String.Format("{0}{1}\n", prazni2, String.Concat(Enumerable.Repeat("*", i))));
            }
        }
        return expected.ToString();
    }
    // groupanje {} [] ()
    public static bool Check(string input)
    {
        if (input == string.Empty)
            return true;
        for (int i = 0; i < input.Length; i++)
        {
            if (i == input.Length - 1)
                continue;
            else if (input[i] == '(')
            {
                if (input[i + 1] == ']' || input[i + 1] == '}')
                    return false;
            }
            else if (input[i] == '[')
            {
                if (input[i + 1] == ')' || input[i + 1] == '}')
                    return false;
            }
            else if (input[i] == '{')
            {
                if (input[i + 1] == ']' || input[i + 1] == ')')
                    return false;
            }
        }
        if (input.Count(x => x == '(') == input.Count(x => x == ')') &&
                input.Count(x => x == '[') == input.Count(x => x == ']') &&
                input.Count(x => x == '{') == input.Count(x => x == '}'))
            return true;
        else
            return false;

    }

    //vracanje stringa obrnutog za rijeci koje imaju preko 4 znaka
    public static string SpinWords(string sentence)
    {
        var lista = sentence.Split(' ');
        for (int i = 0; i < lista.Count(); i++)
        {
            if (lista[i].Length > 4)
            {
                lista[i] = Reverse(lista[i]);
            }
        }
        return String.Join(" ", lista);
    }
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    //ispisivanje indexa mjesta na kojemu se nalazi veliko slovo u riječi
    public static int[] CountCapitals(string word)
    {
        var vracenaLista = new List<int>();
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i].ToString() == word[i].ToString().ToUpper())
            {
                vracenaLista.Add(i);
            }
        }
        return vracenaLista.ToArray();
    }

    //drugi nacin
    public static int[] Capitals(string word)
    {
        return word.Select((c, i) => Char.IsUpper(c) ? i : -1).Where(i => i >= 0).ToArray();
    }
}
