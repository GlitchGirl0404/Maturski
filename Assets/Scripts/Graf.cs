using System.Collections.Generic;
using System.Linq;
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
    public ReturnClass Dajkstra()
    {
        int[] udaljenosti = new int[broj_cvorova];
        udaljenosti[0] = 0;
        bool[] poseceni = new bool[broj_cvorova];
        poseceni[0] = false;
        List<int>[] put = new List<int>[broj_cvorova];
        put[0] = new List<int>();
        put[0].Add(0);
        for (int i = 1; i < broj_cvorova; i++)
        {
            udaljenosti[i] = int.MaxValue;
            poseceni[i] = false;
            put[i] = new List<int>();
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
                    put[j] = new List<int>();
                    for (int m = 0; m < put[min_id].Count; m++)
                    {
                        put[j].Add(put[min_id].ElementAt(m));
                    }
                    put[j].Add(j);
                }
            }
        }
        ReturnClass rezultat = new ReturnClass(udaljenosti[broj_cvorova - 1], put[broj_cvorova - 1]);
        return rezultat;
    }
}