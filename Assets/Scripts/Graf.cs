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
}