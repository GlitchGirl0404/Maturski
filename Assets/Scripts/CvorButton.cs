using UnityEngine;
public class CvorButton : MonoBehaviour
{
    public GameObject dajkstra_manager;
    public DajkstraManager dm;
    void Start()
    {
        dm = dajkstra_manager.GetComponent<DajkstraManager>();
    }
    public void Click()
    {
        int n = 0;
        for (int i = 0; i < dm.broj_cvorova; i++)
        {
            if (gameObject == dm.cvorovi[i])
            {
                n = i;
            }
        }
        if (n == dm.current)
        {
            gameObject.transform.Find("Selected").gameObject.SetActive(false);
            if (dm.grane[dm.current, dm.previous[n]] == null)
            {
                dm.grane[dm.previous[n], dm.current].transform.Find("Selected").gameObject.SetActive(false);
            }
            else
            {
                dm.grane[dm.current, dm.previous[n]].transform.Find("Selected").gameObject.SetActive(false);
            }
            dm.current = dm.previous[n];
            dm.selected[n] = false;
        }
        else
        {
            gameObject.transform.Find("Selected").gameObject.SetActive(true);
            if (dm.grane[dm.current, n] == null)
            {
                dm.grane[n, dm.current].transform.Find("Selected").gameObject.SetActive(true);
            }
            else
            {
                dm.grane[dm.current, n].transform.Find("Selected").gameObject.SetActive(true);
            }
            dm.previous[n] = dm.current;
            dm.current = n;
            dm.selected[n] = true;
        }
        dm.UpdateCvorovi();
    }
}