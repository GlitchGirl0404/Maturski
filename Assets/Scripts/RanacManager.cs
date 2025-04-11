using TMPro;
using UnityEngine;
public class RanacManager : MonoBehaviour
{
    [SerializeField] GameObject bar;
    [SerializeField] GameObject tezina_ranca_txt;
    [SerializeField] GameObject item_prefab;
    [SerializeField] GameObject panel;
    GameObject[] items;
    bool[] selected;
    int number_of_items;
    public void UpdateBar(float a)
    {
        Vector3 scale = bar.transform.localScale;
        scale.y = a;
        bar.transform.localScale = scale;
    }
    void Start()
    {
        UpdateBar(0);
        tezina_ranca_txt.GetComponent<TextMeshProUGUI>().text = "0/" + LevelLoading.nosivost_ranca.ToString();
        number_of_items = LevelLoading.tezina_predmeta.Length;
        items = new GameObject[number_of_items];
        selected = new bool[number_of_items];
        for (int i = 0; i < number_of_items; i++)
        {
            items[i] = Instantiate(item_prefab);
            items[i].transform.SetParent(panel.transform);
            selected[i] = false;
        }
    }
}
