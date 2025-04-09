using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LopovButtons : MonoBehaviour
{
    [SerializeField] GameObject camera;
    LopovManager lm;
    [SerializeField] GameObject lopov_manager;
    bool level_finished = false;
    void Start()
    {
        lm = lopov_manager.GetComponent<LopovManager>();
    }
    public void Left()
    {
        camera.transform.position = new Vector3(camera.transform.position.x - 1, 0, -10);
    }
    public void Right()
    {
        camera.transform.position = new Vector3(camera.transform.position.x + 1, 0, -10);
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