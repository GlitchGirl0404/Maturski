using NUnit.Framework.Constraints;
using System.IO;
using TMPro;
using UnityEditor.Analytics;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public class Nivo
    {
        public string flight_code;
        public string city;
        public string airport;
        public bool[] stars;
        public int to_unlock;
        public int broj_kuca;
        public int[] vrednosti_kuca;
        public int nosivost_ranca;
        public int[] tezina_predmeta;
        public int[] vrednost_predmeta;
        public Graf graf;
        public Nivo(string flightCode, string city, string airport, bool[] stars, int to_unlock, int broj_kuca, int[] vrednosti_kuca, int nosivost_ranca, int[] tezina_predmeta, int[] vrednost_predmeta, Graf graf)
        {
            this.flight_code = flightCode;
            this.city = city;
            this.airport = airport;
            this.stars = stars;
            this.to_unlock = to_unlock;
            this.broj_kuca = broj_kuca;
            this.vrednosti_kuca = vrednosti_kuca;
            this.nosivost_ranca = nosivost_ranca;
            this.tezina_predmeta = tezina_predmeta;
            this.vrednost_predmeta = vrednost_predmeta;
            this.graf = graf;
        }
    }
    public Nivo[] nivoi = new Nivo[3];
    [SerializeField] TextMeshProUGUI flight_code;
    [SerializeField] TextMeshProUGUI airport_name;
    [SerializeField] TextMeshProUGUI city;
    [SerializeField] GameObject left_button;
    [SerializeField] GameObject right_button;
    public int current;
    [SerializeField] GameObject lopov_star;
    [SerializeField] GameObject ranac_star;
    [SerializeField] GameObject dajkstra_star;
    string data_dir_path;
    string data_file_name = "SaveData.pbg";
    bool[,] stars;
    [SerializeField] GameObject to_unlock_txt;
    [SerializeField] GameObject play_button;
    public void DisplayNames()
    {
        flight_code.text = nivoi[current].flight_code;
        city.text = nivoi[current].city;
        airport_name.text = nivoi[current].airport;
        to_unlock_txt.GetComponent<TextMeshProUGUI>().text = nivoi[current].to_unlock.ToString();
        lopov_star.transform.Find("Collected").gameObject.SetActive(nivoi[current].stars[0]);
        lopov_star.transform.Find("NotCollected").gameObject.SetActive(!nivoi[current].stars[0]);
        ranac_star.transform.Find("Collected").gameObject.SetActive(nivoi[current].stars[1]);
        ranac_star.transform.Find("NotCollected").gameObject.SetActive(!nivoi[current].stars[1]);
        dajkstra_star.transform.Find("Collected").gameObject.SetActive(nivoi[current].stars[2]);
        dajkstra_star.transform.Find("NotCollected").gameObject.SetActive(!nivoi[current].stars[2]);
        if (current == 0)
        {
            left_button.SetActive(false);
            right_button.SetActive(true);
        }
        else if (current == nivoi.Length - 1)
        {
            left_button.SetActive(true);
            right_button.SetActive(false);
        }
        else
        {
            left_button.SetActive(true);
            right_button.SetActive(true);
        }
        int stars_zbir = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (stars[i, j])
                {
                    stars_zbir++;
                }
            }
        }
        if (stars_zbir < nivoi[current].to_unlock)
        {
            play_button.SetActive(false);
        }
        else
        {
            play_button.SetActive(true);
        }
    }
    void Start()
    {
        data_dir_path = Application.persistentDataPath;
        stars = new bool[3, 3];
        string full_path = Path.Combine(data_dir_path, data_file_name);
        Directory.CreateDirectory(Path.GetDirectoryName(full_path));
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                stars[i, j] = false;
            }
        }
        if (File.Exists(full_path))
        {
            using (FileStream strem = new FileStream(full_path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(strem))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            stars[i, j] = bool.Parse(reader.ReadLine());
                        }
                    }
                }
            }
        }
        bool[] level_stars = new bool[3];
        level_stars[0] = stars[0, 0];
        level_stars[1] = stars[0, 1];
        level_stars[2] = stars[0, 2];
        int[] vrednosti_kuca = new int[3];
        vrednosti_kuca[0] = 19;
        vrednosti_kuca[1] = 43;
        vrednosti_kuca[2] = 2;
        int[] tezina_predmeta = new int[5];
        int[] vrednosti_predmeta = new int[5];
        tezina_predmeta[0] = 4;
        tezina_predmeta[1] = 1;
        tezina_predmeta[2] = 6;
        tezina_predmeta[3] = 1;
        tezina_predmeta[4] = 6;
        vrednosti_predmeta[0] = 5;
        vrednosti_predmeta[1] = 6;
        vrednosti_predmeta[2] = 6;
        vrednosti_predmeta[3] = 6;
        vrednosti_predmeta[4] = 6;
        Cvor[] cvorovi = new Cvor[4];
        cvorovi[0] = new Cvor(345, 255);
        cvorovi[1] = new Cvor(-83, -231);
        cvorovi[2] = new Cvor(-385, -156);
        cvorovi[3] = new Cvor(-183, 230);
        int[,] matrica_povezanosti = new int[4, 4];
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                matrica_povezanosti[i, j] = 0;
            }
        }
        matrica_povezanosti[0, 1] = 5;
        matrica_povezanosti[1, 0] = 5;
        matrica_povezanosti[0, 3] = 8;
        matrica_povezanosti[3, 0] = 8;
        matrica_povezanosti[1, 2] = 2;
        matrica_povezanosti[2, 1] = 2;
        matrica_povezanosti[1, 3] = 7;
        matrica_povezanosti[3, 1] = 7;
        matrica_povezanosti[2, 3] = 6;
        matrica_povezanosti[3, 2] = 6;
        Graf graf = new Graf(4, cvorovi, matrica_povezanosti);
        nivoi[0] = new Nivo("V3CUHY", "Beograd", "Nikola Tesla", level_stars, 0, 3, vrednosti_kuca, 9, tezina_predmeta, vrednosti_predmeta, graf);
        level_stars = new bool[3];
        level_stars[0] = stars[1, 0];
        level_stars[1] = stars[1, 1];
        level_stars[2] = stars[1, 2];
        vrednosti_kuca = new int[7];
        vrednosti_kuca[0] = 22;
        vrednosti_kuca[1] = 18;
        vrednosti_kuca[2] = 35;
        vrednosti_kuca[3] = 45;
        vrednosti_kuca[4] = 35;
        vrednosti_kuca[5] = 33;
        vrednosti_kuca[6] = 15;
        tezina_predmeta = new int[10];
        vrednosti_predmeta = new int[10];
        tezina_predmeta[0] = 5;
        tezina_predmeta[1] = 1;
        tezina_predmeta[2] = 9;
        tezina_predmeta[3] = 9;
        tezina_predmeta[4] = 3;
        tezina_predmeta[5] = 9;
        tezina_predmeta[6] = 9;
        tezina_predmeta[7] = 5;
        tezina_predmeta[8] = 2;
        tezina_predmeta[9] = 3;
        vrednosti_predmeta[0] = 10;
        vrednosti_predmeta[1] = 1;
        vrednosti_predmeta[2] = 7;
        vrednosti_predmeta[3] = 2;
        vrednosti_predmeta[4] = 2;
        vrednosti_predmeta[5] = 5;
        vrednosti_predmeta[6] = 5;
        vrednosti_predmeta[7] = 7;
        vrednosti_predmeta[8] = 8;
        vrednosti_predmeta[9] = 2;
        cvorovi = new Cvor[6];
        cvorovi[0] = new Cvor(-330, -164);
        cvorovi[1] = new Cvor(67, -264);
        cvorovi[2] = new Cvor(0, 0);
        cvorovi[3] = new Cvor(572, 118);
        cvorovi[4] = new Cvor(149, 321);
        cvorovi[5] = new Cvor(-443, 221);
        matrica_povezanosti = new int[6, 6];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                matrica_povezanosti[i, j] = 0;
            }
        }
        matrica_povezanosti[0, 1] = 7;
        matrica_povezanosti[1, 0] = 7;
        matrica_povezanosti[0, 2] = 9;
        matrica_povezanosti[2, 0] = 9;
        matrica_povezanosti[0, 5] = 14;
        matrica_povezanosti[5, 0] = 14;
        matrica_povezanosti[1, 2] = 10;
        matrica_povezanosti[2, 1] = 10;
        matrica_povezanosti[1, 3] = 15;
        matrica_povezanosti[3, 1] = 15;
        matrica_povezanosti[2, 3] = 11;
        matrica_povezanosti[3, 2] = 11;
        matrica_povezanosti[2, 5] = 2;
        matrica_povezanosti[5, 2] = 2;
        matrica_povezanosti[3, 4] = 6;
        matrica_povezanosti[4, 3] = 6;
        matrica_povezanosti[4, 5] = 9;
        matrica_povezanosti[5, 4] = 9;
        graf = new Graf(6, cvorovi, matrica_povezanosti);
        nivoi[1] = new Nivo("QL6PLM", "London", "Elstree Aerodrome", level_stars, 2, 7, vrednosti_kuca, 15, tezina_predmeta, vrednosti_predmeta, graf);
        level_stars = new bool[3];
        level_stars[0] = stars[2, 0];
        level_stars[1] = stars[2, 1];
        level_stars[2] = stars[2, 2];
        vrednosti_kuca = new int[11];
        vrednosti_kuca[0] = 5;
        vrednosti_kuca[1] = 15;
        vrednosti_kuca[2] = 20;
        vrednosti_kuca[3] = 10;
        vrednosti_kuca[4] = 6;
        vrednosti_kuca[5] = 20;
        vrednosti_kuca[6] = 10;
        vrednosti_kuca[7] = 12;
        vrednosti_kuca[8] = 30;
        vrednosti_kuca[9] = 7;
        vrednosti_kuca[10] = 3;
        tezina_predmeta = new int[15];
        vrednosti_predmeta = new int[15];
        tezina_predmeta[0] = 15;
        tezina_predmeta[1] = 6;
        tezina_predmeta[2] = 7;
        tezina_predmeta[3] = 1;
        tezina_predmeta[4] = 18;
        tezina_predmeta[5] = 1;
        tezina_predmeta[6] = 6;
        tezina_predmeta[7] = 2;
        tezina_predmeta[8] = 4;
        tezina_predmeta[9] = 14;
        tezina_predmeta[10] = 18;
        tezina_predmeta[11] = 11;
        tezina_predmeta[12] = 14;
        tezina_predmeta[13] = 15;
        tezina_predmeta[14] = 16;
        vrednosti_predmeta[0] = 13;
        vrednosti_predmeta[1] = 12;
        vrednosti_predmeta[2] = 4;
        vrednosti_predmeta[3] = 4;
        vrednosti_predmeta[4] = 10;
        vrednosti_predmeta[5] = 12;
        vrednosti_predmeta[6] = 7;
        vrednosti_predmeta[7] = 20;
        vrednosti_predmeta[8] = 15;
        vrednosti_predmeta[9] = 8;
        vrednosti_predmeta[10] = 1;
        vrednosti_predmeta[11] = 3;
        vrednosti_predmeta[12] = 13;
        vrednosti_predmeta[13] = 12;
        vrednosti_predmeta[14] = 5;
        cvorovi = new Cvor[9];
        cvorovi[0] = new Cvor(-621, 0);
        cvorovi[1] = new Cvor(-317, 270);
        cvorovi[2] = new Cvor(0, 270);
        cvorovi[3] = new Cvor(317, 270);
        cvorovi[4] = new Cvor(621, 0);
        cvorovi[5] = new Cvor(317, -270);
        cvorovi[6] = new Cvor(0, -270);
        cvorovi[7] = new Cvor(-317, -270);
        cvorovi[8] = new Cvor(0, 0);
        matrica_povezanosti = new int[9, 9];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                matrica_povezanosti[i, j] = 0;
            }
        }
        matrica_povezanosti[0, 1] = 4;
        matrica_povezanosti[1, 0] = 4;
        matrica_povezanosti[0, 7] = 8;
        matrica_povezanosti[7, 0] = 8;
        matrica_povezanosti[1, 2] = 8;
        matrica_povezanosti[2, 1] = 8;
        matrica_povezanosti[1, 7] = 11;
        matrica_povezanosti[7, 1] = 11;
        matrica_povezanosti[2, 3] = 7;
        matrica_povezanosti[3, 2] = 7;
        matrica_povezanosti[2, 5] = 4;
        matrica_povezanosti[5, 2] = 4;
        matrica_povezanosti[2, 8] = 2;
        matrica_povezanosti[8, 2] = 2;
        matrica_povezanosti[3, 4] = 9;
        matrica_povezanosti[4, 3] = 9;
        matrica_povezanosti[3, 5] = 14;
        matrica_povezanosti[5, 3] = 14;
        matrica_povezanosti[4, 5] = 10;
        matrica_povezanosti[5, 4] = 10;
        matrica_povezanosti[5, 6] = 2;
        matrica_povezanosti[6, 5] = 2;
        matrica_povezanosti[6, 7] = 1;
        matrica_povezanosti[7, 6] = 1;
        matrica_povezanosti[6, 8] = 6;
        matrica_povezanosti[8, 6] = 6;
        matrica_povezanosti[7, 8] = 7;
        matrica_povezanosti[8, 7] = 7;
        graf = new Graf(9, cvorovi, matrica_povezanosti);
        nivoi[2] = new Nivo("V9C9WC", "Pariz", "Charles de Gaulle Airport", level_stars, 5, 11, vrednosti_kuca, 30, tezina_predmeta, vrednosti_predmeta, graf);
        current = 0;
        DisplayNames();
    }
}