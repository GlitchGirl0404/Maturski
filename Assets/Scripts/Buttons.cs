using System.IO;
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
        Application.OpenURL("https://docs.google.com/document/d/1k-_Bal8zLgYoMlPhAfHNqhmanNvaf3yUaKWKN2v8-dE/edit?usp=sharing");
    }
    public void Exit()
    {
        Application.Quit();
    }
}