using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public static class Funkcije
{
    public static DajkstraReturn Lopov(int[] kuce)
    {
        int n = kuce.Length;
        int[] sa = new int[n];
        int[] bez = new int[n];
        sa[0] = kuce[0];
        bez[0] = 0;
        for (int i = 1; i < n; i++)
        {
            sa[i] = bez[i - 1] + kuce[i];
            bez[i] = Mathf.Max(sa[i - 1], bez[i - 1]);
        }
        List<int> s = new List<int>();
        int b = Mathf.Max(sa[n - 1], bez[n - 1]);
        for (int i = n - 1; i > -1; i--)
        {
            if (sa[i] == b)
            {
                s.Add(i);
                b = b - kuce[i];
            }
        }
        return new DajkstraReturn(Mathf.Max(sa[n - 1], bez[n - 1]), s);
    }
    public static DajkstraReturn Ranac(int nosivost, int[] tezine, int[] vrednost)
    {
        int[] dobijeni = new int[nosivost + 1];
        int[] vrednosti = new int[nosivost + 1];
        for (int i = 1;  i < nosivost + 1; i++)
        {
            dobijeni[i] = 0;
            vrednosti[i] = 0;
        }
        dobijeni[0] = -1;
        vrednosti[0] = 0;
        for (int i = 0; i < tezine.Length; i++)
        {
            for (int j = nosivost; j > -1; j--)
            {
                if ((dobijeni[j] != 0) && (j + tezine[i] <= nosivost))
                {
                    if (vrednosti[j] + vrednost[i] > vrednosti[j + tezine[i]])
                    {
                        vrednosti[j + tezine[i]] = vrednosti[j] + vrednost[i];
                        dobijeni[j + tezine[i]] = i + 1;
                    }
                }
            }
        }
        int max = 0;
        int poz = 0;
        for (int i = 0; i < vrednosti.Length; i++)
        {
            if (vrednosti[i] > max)
            {
                max = vrednosti[i];
                poz = i;
            }
        }
        List<int> lista = new List<int>();
        while (dobijeni[poz] != -1)
        {
            lista.Add(dobijeni[poz] - 1);
            poz = poz - tezine[dobijeni[poz] - 1];
        }
        return new DajkstraReturn(max, lista); ;
    }
}