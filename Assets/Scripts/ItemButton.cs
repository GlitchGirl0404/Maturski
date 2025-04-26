using UnityEngine;
public class ItemButton : MonoBehaviour
{
    public GameObject ranac_manager;
    RanacManager rm;
    void Start()
    {
        rm = ranac_manager.GetComponent<RanacManager>();
    }
    public void Clikc()
    {
        int n = 0;
        for (int i = 0; i < LevelLoading.tezina_predmeta.Length; i++)
        {
            if (gameObject == rm.items[i])
            {
                n = i;
                break;
            }
        }
        if (rm.selected[n])
        {
            rm.selected[n] = false;
        }
        else
        {
            if (rm.tezina + LevelLoading.tezina_predmeta[n] <= LevelLoading.nosivost_ranca)
            {
                rm.selected[n] = true;
            }
        }
        rm.UpdateBar();
        rm.OrderItems();
    }
}