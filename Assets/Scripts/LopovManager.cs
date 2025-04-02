using System;
using UnityEngine;
using TMPro;
using System.Drawing;
public class LopovManager : MonoBehaviour
{
    public GameObject[] kuce;
    [SerializeField] GameObject kuca_prefab;
    [SerializeField] GameObject background;
    [SerializeField] GameObject left_button;
    [SerializeField] GameObject right_button;
    [SerializeField] GameObject camera;
    int min = 0;
    int max = LevelLoading.broj_kuca * 4 - 10;
    void Start()
    {
        kuce = new GameObject[LevelLoading.broj_kuca];
        for (int i = 0; i < LevelLoading.broj_kuca; i++)
        {
            kuce[i] = Instantiate(kuca_prefab);
            kuce[i].transform.position = new Vector3(-1 + (i * 4), 0.5f);
            kuce[i].transform.Find("Canvas").gameObject.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text = LevelLoading.vrednosti_kuca[i].ToString();
        }
        background.GetComponent<SpriteRenderer>().size = new Vector2(LevelLoading.broj_kuca * 4, 4.94f);
    }
    void Update()
    {
        if (camera.transform.position.x <= min)
        {
            left_button.SetActive(false);
        }
        else
        {
            left_button.SetActive(true);
        }
        if (camera.transform.position.x >= max)
        {
            right_button.SetActive(false);
        }
        else
        {
            right_button.SetActive(true);
        }
    }
}