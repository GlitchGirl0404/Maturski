using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
public class DajkstraManager : MonoBehaviour
{
    [SerializeField] GameObject cvor_prefab;
    [SerializeField] GameObject grana_prefab;
    public GameObject[] cvorovi;
    public GameObject[,] grane;
    [SerializeField] GameObject panel;
    public int broj_cvorova = 0;
    [SerializeField] GameObject duzina_txt_prefab;
    public int current;
    public int[] previous;
    public bool[] selected;
    [SerializeField] GameObject go_button;
    [SerializeField] GameObject duzina_txt;
    int duzina;
    [SerializeField] GameObject black_screen;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject najbrzi_txt;
    [SerializeField] GameObject trenutni_txt;
    void Start()
    {
        broj_cvorova = LevelLoading.graf.broj_cvorova;
        cvorovi = new GameObject[broj_cvorova];
        grane = new GameObject[broj_cvorova, broj_cvorova];
        previous = new int[broj_cvorova];
        selected = new bool[broj_cvorova];
        for (int i = 0; i < broj_cvorova; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (LevelLoading.graf.matrica_povezanosti[i, j] > 0)
                {
                    grane[i, j] = Instantiate(grana_prefab);
                    GameObject duzina_txt = Instantiate(duzina_txt_prefab);
                    grane[i, j].transform.SetParent(panel.transform, false);
                    duzina_txt.transform.SetParent(panel.transform, false);
                    duzina_txt.GetComponent<TextMeshProUGUI>().text = LevelLoading.graf.matrica_povezanosti[i, j].ToString();
                    grane[i, j].transform.position = new Vector3((LevelLoading.graf.cvorovi[i].x + LevelLoading.graf.cvorovi[j].x) / 2, (LevelLoading.graf.cvorovi[i].y + LevelLoading.graf.cvorovi[j].y) / 2) + new Vector3(panel.transform.parent.gameObject.GetComponent<RectTransform>().rect.width / 2, panel.transform.parent.gameObject.GetComponent<RectTransform>().rect.height / 2);
                    duzina_txt.transform.position = new Vector3((LevelLoading.graf.cvorovi[i].x + LevelLoading.graf.cvorovi[j].x) / 2, (LevelLoading.graf.cvorovi[i].y + LevelLoading.graf.cvorovi[j].y) / 2) + new Vector3(panel.transform.parent.gameObject.GetComponent<RectTransform>().rect.width / 2, panel.transform.parent.gameObject.GetComponent<RectTransform>().rect.height / 2);
                    grane[i, j].GetComponent<RectTransform>().sizeDelta = new Vector3(25, Mathf.Sqrt((LevelLoading.graf.cvorovi[i].x - LevelLoading.graf.cvorovi[j].x) * (LevelLoading.graf.cvorovi[i].x - LevelLoading.graf.cvorovi[j].x) + (LevelLoading.graf.cvorovi[i].y - LevelLoading.graf.cvorovi[j].y) * (LevelLoading.graf.cvorovi[i].y - LevelLoading.graf.cvorovi[j].y)));
                    grane[i, j].transform.Find("Selected").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector3(25, Mathf.Sqrt((LevelLoading.graf.cvorovi[i].x - LevelLoading.graf.cvorovi[j].x) * (LevelLoading.graf.cvorovi[i].x - LevelLoading.graf.cvorovi[j].x) + (LevelLoading.graf.cvorovi[i].y - LevelLoading.graf.cvorovi[j].y) * (LevelLoading.graf.cvorovi[i].y - LevelLoading.graf.cvorovi[j].y)));
                    grane[i, j].transform.eulerAngles = new Vector3(0, 0, (Mathf.Atan((LevelLoading.graf.cvorovi[j].x - LevelLoading.graf.cvorovi[i].x) / (LevelLoading.graf.cvorovi[i].y - LevelLoading.graf.cvorovi[j].y)) * 180) / Mathf.PI);
                }
                else
                {
                    grane[i, j] = null;
                }
            }
        }
        for (int i = 0; i < broj_cvorova; i++)
        {
            cvorovi[i] = Instantiate(cvor_prefab);
            cvorovi[i].GetComponent<CvorButton>().dajkstra_manager = gameObject;
            cvorovi[i].transform.SetParent(panel.transform, false);
            cvorovi[i].transform.position = new Vector3(LevelLoading.graf.cvorovi[i].x, LevelLoading.graf.cvorovi[i].y) + new Vector3(panel.transform.parent.gameObject.GetComponent<RectTransform>().rect.width / 2, panel.transform.parent.gameObject.GetComponent<RectTransform>().rect.height / 2);
            if (i == (broj_cvorova - 1))
            {
                cvorovi[i].transform.Find("Avion").gameObject.SetActive(true);
            }
            if (i == 0)
            {
                cvorovi[i].transform.Find("Selected").gameObject.SetActive(true);
            }
            previous[i] = 0;
            selected[i] = false;
        }
        current = 0;
        selected[0] = true;
        UpdateCvorovi();
    }
    public void EndLevel()
    {
        foreach (Transform child in panel.transform)
        {
            if (child != go_button.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        black_screen.SetActive(true);
        canvas.GetComponent<Canvas>().sortingOrder = 5;
        ReturnClass res = LevelLoading.graf.Dajkstra();
        LevelLoading.najbrzi = res;
        LevelLoading.trenutni = duzina;
        najbrzi_txt.GetComponent<TextMeshProUGUI>().text = res.razdaljina.ToString();
        trenutni_txt.GetComponent<TextMeshProUGUI>().text = duzina.ToString();
    }
    public void UpdateCvorovi()
    {
        for (int i = 0; i < broj_cvorova; i++)
        {
            if ((LevelLoading.graf.matrica_povezanosti[current, i] > 0) && (current != (broj_cvorova - 1)) && (!selected[i]))
            {
                cvorovi[i].GetComponent<Button>().enabled = true;
            }
            else
            {
                cvorovi[i].GetComponent<Button>().enabled = false;
            }
        }
        if (current == (broj_cvorova - 1))
        {
            cvorovi[broj_cvorova - 1].GetComponent<Button>().enabled = true;
            go_button.SetActive(true);
        }
        else
        {
            go_button.SetActive(false);
        }
        cvorovi[current].GetComponent<Button>().enabled = true;
        cvorovi[0].GetComponent<Button>().enabled = false;
        int n = current;
        duzina = 0;
        while (n > 0)
        {
            duzina = duzina + LevelLoading.graf.matrica_povezanosti[n, previous[n]];
            n = previous[n];
        }
        duzina_txt.GetComponent<TextMeshProUGUI>().text = duzina.ToString();
    }
}