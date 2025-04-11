using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;
public class LevelSelectButtons : MonoBehaviour
{
    GameManager game_manager;
    [SerializeField] GameObject gm;
    void Awake()
    {
        game_manager = gm.GetComponent<GameManager>();
    }
    public void Left()
    {
        if (game_manager.current > 0)
        {
            game_manager.current = game_manager.current - 1;
        }
        game_manager.DisplayNames();
    }
    public void Right()
    {
        if (game_manager.current < game_manager.nivoi.Length - 1)
        {
            game_manager.current = game_manager.current + 1;
        }
        game_manager.DisplayNames();
    }
    public void Play()
    {
        LevelLoading.broj_kuca = 3;
        LevelLoading.vrednosti_kuca = new int[3];
        LevelLoading.vrednosti_kuca[0] = 19;
        LevelLoading.vrednosti_kuca[1] = 43;
        LevelLoading.vrednosti_kuca[2] = 2;
        LevelLoading.nosivost_ranca = 9;
        LevelLoading.tezina_predmeta = new int[5];
        LevelLoading.tezina_predmeta[0] = 4;
        LevelLoading.tezina_predmeta[1] = 1;
        LevelLoading.tezina_predmeta[2] = 6;
        LevelLoading.tezina_predmeta[3] = 1;
        LevelLoading.tezina_predmeta[4] = 6;
        LevelLoading.vrednost_predmeta = new int[5];
        LevelLoading.vrednost_predmeta[0] = 5;
        LevelLoading.vrednost_predmeta[1] = 6;
        LevelLoading.vrednost_predmeta[2] = 6;
        LevelLoading.vrednost_predmeta[3] = 6;
        LevelLoading.vrednost_predmeta[4] = 6;
        SceneManager.LoadScene("Lopov");
    }
    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }
}