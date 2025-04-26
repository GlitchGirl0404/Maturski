using UnityEngine;
public class HouseButton : MonoBehaviour
{
    LopovManager lm;
    public GameObject lopov_manager;
    void Start()
    {
        lm = lopov_manager.GetComponent<LopovManager>();
    }
    public void Click()
    {
        GameObject kuca = gameObject.transform.parent.gameObject.transform.parent.gameObject;
        int n = 0;
        for (int i = 0; i < LevelLoading.broj_kuca; i++)
        {
            if (kuca == lm.kuce[i])
            {
                n = i;
                break;
            }
        }
        lm.selected[n] = !lm.selected[n];
        lm.KuceUpdate();
    }
}