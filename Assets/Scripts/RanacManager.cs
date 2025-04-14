using TMPro;
using UnityEditor.Search;
using UnityEngine;
public class RanacManager : MonoBehaviour
{
    [SerializeField] GameObject bar;
    [SerializeField] GameObject tezina_ranca_txt;
    [SerializeField] GameObject item_prefab;
    [SerializeField] GameObject panel;
    public GameObject[] items;
    public bool[] selected;
    int number_of_items;
    public int tezina;
    [SerializeField] GameObject value_txt;
    [SerializeField] GameObject black_screen;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject ukradeno_txt;
    [SerializeField] GameObject max_txt;
    [SerializeField] GameObject empty;
    public void UpdateBar()
    {
        tezina = 0;
        int value = 0;
        for (int i = 0; i < number_of_items; i++)
        {
            if (selected[i])
            {
                tezina = tezina + LevelLoading.tezina_predmeta[i];
                value = value + LevelLoading.vrednost_predmeta[i];
            }
        }
        Vector3 scale = bar.transform.localScale;
        scale.y = (float)((double)tezina / LevelLoading.nosivost_ranca);
        bar.transform.localScale = scale;
        tezina_ranca_txt.GetComponent<TextMeshProUGUI>().text = tezina.ToString() + "/" + LevelLoading.nosivost_ranca.ToString();
        value_txt.GetComponent<TextMeshProUGUI>().text = value.ToString();
    }
    void Start()
    {
        UpdateBar();
        number_of_items = LevelLoading.tezina_predmeta.Length;
        items = new GameObject[number_of_items];
        selected = new bool[number_of_items];
        for (int i = 0; i < number_of_items; i++)
        {
            items[i] = Instantiate(item_prefab);
            items[i].transform.SetParent(panel.transform, false);
            selected[i] = false;
            items[i].transform.Find("ValueTXT").gameObject.GetComponent<TextMeshProUGUI>().text = LevelLoading.vrednost_predmeta[i].ToString();
            items[i].transform.Find("TezinaTXT").gameObject.GetComponent<TextMeshProUGUI>().text = LevelLoading.tezina_predmeta[i].ToString();
            items[i].GetComponent<ItemButton>().ranac_manager = gameObject;
        }
        OrderItems();
    }
    public void OrderItems()
    {
        int l = 0;
        int r = 0;
        for (int i = 0; i < number_of_items; i++)
        {
            if (selected[i])
            {
                items[i].GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
                items[i].GetComponent<RectTransform>().anchorMin = new Vector2(1, 1);
                items[i].transform.position = new Vector3(-150 - ((r % 3) * 210) + 1920, -150 - (((int)Mathf.Floor(r / 3)) * 210) + 1080);
                r++;
            }
            else
            {
                items[i].transform.position = new Vector3(150 + ((l % 3) * 210), -150 - (((int)Mathf.Floor(l / 3)) * 210) + 1080);
                l++;
            }
        }
    }
    public void EndLevel()
    {
        black_screen.SetActive(true);
        canvas.GetComponent<Canvas>().sortingOrder = 5;
        empty.SetActive(false);
        ReturnClass res = Funkcije.Ranac(LevelLoading.nosivost_ranca, LevelLoading.tezina_predmeta, LevelLoading.vrednost_predmeta);
        LevelLoading.max_vrednost = res;
        int vrednost = 0;
        for (int i = 0; i < selected.Length; i++)
        {
            items[i].SetActive(false);
            if (selected[i])
            {
                vrednost = vrednost + LevelLoading.vrednost_predmeta[i];
            }
        }
        LevelLoading.ukradena_vrednost = vrednost;
        ukradeno_txt.GetComponent<TextMeshProUGUI>().text = vrednost.ToString();
        max_txt.GetComponent<TextMeshProUGUI>().text = res.razdaljina.ToString();
    }
}