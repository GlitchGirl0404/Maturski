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
}