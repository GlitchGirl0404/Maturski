using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void Settings()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}