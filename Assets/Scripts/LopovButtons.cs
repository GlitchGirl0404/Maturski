using UnityEngine;
using UnityEngine.SceneManagement;
public class LopovButtons : MonoBehaviour
{
    [SerializeField] GameObject camera;
    LopovManager lm;
    [SerializeField] GameObject lopov_manager;
    bool level_finished = false;
    [SerializeField] GameObject left_btn;
    [SerializeField] GameObject right_btn;
    int min = 0;
    int max = LevelLoading.broj_kuca * 4 - 10;
    void Start()
    {
        lm = lopov_manager.GetComponent<LopovManager>();
    }
    public void Left()
    {
        camera.transform.position = new Vector3(camera.transform.position.x - 1, 0, -10);
        if (camera.transform.position.x <= min)
        {
            left_btn.SetActive(false);
        }
        else
        {
            left_btn.SetActive(true);
        }
        if (camera.transform.position.x >= max)
        {
            right_btn.SetActive(false);
        }
        else
        {
            right_btn.SetActive(true);
        }
    }
    public void Right()
    {
        camera.transform.position = new Vector3(camera.transform.position.x + 1, 0, -10);
        if (camera.transform.position.x <= min)
        {
            left_btn.SetActive(false);
        }
        else
        {
            left_btn.SetActive(true);
        }
        if (camera.transform.position.x >= max)
        {
            right_btn.SetActive(false);
        }
        else
        {
            right_btn.SetActive(true);
        }
    }
    public void Go()
    {
        if (level_finished)
        {
            SceneManager.LoadScene("Ranac");
        }
        else
        {
            lm.EndLevel();
            level_finished = true;
        }
    }
}