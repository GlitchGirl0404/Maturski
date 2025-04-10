using System;
using UnityEngine;
using TMPro;
using System.Drawing;
using UnityEngine.UI;
using JetBrains.Annotations;
public class LopovManager : MonoBehaviour
{
    public GameObject[] kuce;
    [SerializeField] GameObject kuca_prefab;
    [SerializeField] GameObject background;
    [SerializeField] GameObject left_button;
    [SerializeField] GameObject right_button;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject black_screen;
    [SerializeField] GameObject overlay;
    [SerializeField] GameObject your_result_txt;
    [SerializeField] GameObject best_result_txt;
    public bool[] selected;
    int min = 0;
    int max = LevelLoading.broj_kuca * 4 - 10;
    void Start()
    {
        kuce = new GameObject[LevelLoading.broj_kuca];
        selected = new bool[LevelLoading.broj_kuca];
        for (int i = 0; i < LevelLoading.broj_kuca; i++)
        {
            kuce[i] = Instantiate(kuca_prefab);
            kuce[i].transform.position = new Vector3(-1 + (i * 4), 0.5f);
            kuce[i].transform.Find("Canvas").gameObject.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text = LevelLoading.vrednosti_kuca[i].ToString();
            kuce[i].transform.Find("Canvas").gameObject.transform.Find("HouseButton").gameObject.GetComponent<HouseButton>().lopov_manager = gameObject;
            selected[i] = false;
        }
        background.GetComponent<SpriteRenderer>().size = new Vector2(LevelLoading.broj_kuca * 4, 4.94f);
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
    public void KuceUpdate()
    {
        for (int i = 0; i < kuce.Length; i++)
        {
            if (selected[i])
            {
                kuce[i].transform.Find("Canvas").gameObject.transform.Find("HouseButton").GetComponent<Image>().color = new UnityEngine.Color(255f, 255f, 0f, .5f);
                if (i != 0)
                {
                    kuce[i - 1].transform.Find("Canvas").gameObject.transform.Find("HouseButton").gameObject.SetActive(false);
                }
                if (i != (LevelLoading.broj_kuca - 1))
                {
                    kuce[i + 1].transform.Find("Canvas").gameObject.transform.Find("HouseButton").gameObject.SetActive(false);
                }
                i++;
            }
            else
            {
                kuce[i].transform.Find("Canvas").gameObject.transform.Find("HouseButton").GetComponent<Image>().color = new UnityEngine.Color(255f, 255f, 0f, 0f);
                kuce[i].transform.Find("Canvas").gameObject.transform.Find("HouseButton").gameObject.SetActive(true);
            }
        }
    }
    public void EndLevel()
    {
        left_button.SetActive(false);
        right_button.SetActive(false);
        ReturnClass res = Funkcije.Lopov(LevelLoading.vrednosti_kuca);
        LevelLoading.max_lopov = res;
        black_screen.SetActive(true);
        overlay.GetComponent<Canvas>().sortingOrder = 5;
        int sum = 0;
        for (int i = 0; i < LevelLoading.broj_kuca; i++)
        {
            if (selected[i])
            {
                sum = sum + LevelLoading.vrednosti_kuca[i];
            }
        }
        LevelLoading.ukradeno_lopov = sum;
        your_result_txt.GetComponent<TextMeshProUGUI>().text = sum.ToString();
        best_result_txt.GetComponent<TextMeshProUGUI>().text = res.razdaljina.ToString();
    }
}