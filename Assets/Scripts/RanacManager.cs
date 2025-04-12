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
    int tezina;
    public void UpdateBar()
    {
        tezina = 0;
        for (int i = 0; i < number_of_items; i++)
        {
            if (selected[i])
            {
                tezina = tezina + LevelLoading.tezina_predmeta[i];
            }
        }
        Vector3 scale = bar.transform.localScale;
        scale.y = tezina / LevelLoading.nosivost_ranca;
        bar.transform.localScale = scale;
        tezina_ranca_txt.GetComponent<TextMeshProUGUI>().text = tezina.ToString() + "/" + LevelLoading.nosivost_ranca.ToString();
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
                r++;
            }
            else
            {
                items[i].transform.position = new Vector3(150 + ((l % 3) * 210), -150 - (((int)Mathf.Floor(l / 3)) * 210) + 1080);
                Debug.Log(-150 - (((int)Mathf.Floor(l / 3)) * 210));
                l++;
            }
        }
    }
}