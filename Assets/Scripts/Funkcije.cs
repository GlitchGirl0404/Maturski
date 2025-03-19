using UnityEngine;
public static class Funkcije
{
    public static int Lopov(int[] kuce)
    {
        int[] sa = new int[kuce.Length];
        int[] bez = new int[kuce.Length];
        int[] max = new int[kuce.Length];
        sa[0] = kuce[0];
        bez[0] = 0;
        max[0] = kuce[0];
        for (int i = 1; i < kuce.Length; i++)
        {
            sa[i] = bez[i - 1] + kuce[i];
            bez[i] = Mathf.Max(sa[i - 1], bez[i - 1]);
            max[i] = Mathf.Max(sa[i], bez[i]);
        }
        return max[kuce.Length];
    }
    public static int Ranac(int nosivost, int[] tezine)
    {
        int[] dobijeni = new int[nosivost + 1];
        for (int i = 1;  i < nosivost + 1; i++)
        {
            dobijeni[i] = 0;
        }
        dobijeni[0] = -1;
        for (int i = 0; i < tezine.Length; i++)
        {
            for (int j = nosivost; i > -1; j--)
            {
                if ((dobijeni[j] != 0) && (j + tezine[i] <= nosivost))
                {
                    dobijeni[j + tezine[i]] = i + 1;
                }
            }
        }
        return 0;
    }
}