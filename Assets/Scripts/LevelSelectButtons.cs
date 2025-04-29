using UnityEngine;
using UnityEngine.SceneManagement;
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
        LevelLoading.level_id = game_manager.current;
        LevelLoading.broj_kuca = game_manager.nivoi[game_manager.current].broj_kuca;
        LevelLoading.vrednosti_kuca = game_manager.nivoi[game_manager.current].vrednosti_kuca;
        LevelLoading.muzej = game_manager.nivoi[game_manager.current].muzej;
        LevelLoading.nosivost_ranca = game_manager.nivoi[game_manager.current].nosivost_ranca;
        LevelLoading.tezina_predmeta = game_manager.nivoi[game_manager.current].tezina_predmeta;
        LevelLoading.vrednost_predmeta = game_manager.nivoi[game_manager.current].vrednost_predmeta;
        LevelLoading.graf = game_manager.nivoi[game_manager.current].graf;
        SceneManager.LoadScene("Lopov");
    }
    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }
}