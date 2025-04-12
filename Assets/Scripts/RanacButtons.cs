using UnityEngine;
using UnityEngine.SceneManagement;
public class RanacButtons : MonoBehaviour
{
    bool level_finish = false;
    public void Go()
    {
        if (level_finish)
        {
            SceneManager.LoadScene("Dajkstra");
        }
        else
        {
            level_finish = true;
        }
    }
}