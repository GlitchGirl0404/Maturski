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
        Application.OpenURL("file:///" + Application.dataPath + "\\Maturski.pdf");
    }
    public void Exit()
    {
        Application.Quit();
    }
}