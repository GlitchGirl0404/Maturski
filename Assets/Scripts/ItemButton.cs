using JetBrains.Annotations;
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
        rm.selected[n] = true;
        rm.UpdateBar();
        rm.OrderItems();
    }
}