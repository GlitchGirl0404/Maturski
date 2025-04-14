using UnityEngine;
using UnityEngine.SceneManagement;
public class RanacButtons : MonoBehaviour
{
    bool level_finish = false;
    [SerializeField] GameObject ranac_amanager;
    RanacManager rm;
    void Start()
    {
        rm = ranac_amanager.GetComponent<RanacManager>();
    }
    public void Go()
    {
        if (level_finish)
        {
            SceneManager.LoadScene("Dajkstra");
        }
        else
        {
            rm.EndLevel();
            level_finish = true;
        }
    }
}