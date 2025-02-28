using JetBrains.Annotations;
using System;
using UnityEngine;
public class Graf
{
    public int broj_cvorova;
    public Cvor[] cvorovi;
    public int[,] matrica_povezanosti;
    public Graf(int broj_cvorova, Cvor[] cvorovi, int[,] matrica_povezanosti)
    {
        this.broj_cvorova = broj_cvorova;
        this.cvorovi = cvorovi;
        this.matrica_povezanosti = matrica_povezanosti;
    }
    public int Dajkstra()
    {
        int[] udaljenosti = new int[broj_cvorova];
        udaljenosti[0] = 0;
        bool[] poseceni = new bool[broj_cvorova];
        poseceni[0] = false;
        for (int i = 1; i < broj_cvorova; i++)
        {
            udaljenosti[i] = int.MaxValue;
            poseceni[i] = false;
        }
        for (int i = 0; i < broj_cvorova; i++)
        {
            int min_id = -1;
            int trenutni = int.MaxValue;
            for (int j = 0; j < broj_cvorova; j++)
            {
                if ((!poseceni[j]) && (udaljenosti[j] < trenutni))
                {
                    trenutni = udaljenosti[j];
                    min_id = j;
                }
            }
            poseceni[min_id] = true;
            for (int j = 0; j < broj_cvorova; j++)
            {
                if ((matrica_povezanosti[min_id, j] > 0) && (!poseceni[j]) && ((udaljenosti[min_id] + matrica_povezanosti[min_id, j]) < udaljenosti[j]))
                {
                    udaljenosti[j] = udaljenosti[min_id] + matrica_povezanosti[min_id, j];
                }
            }
        }
        return udaljenosti[broj_cvorova - 1];
    }
}