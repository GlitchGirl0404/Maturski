using System;
using UnityEngine;
public class LopovButtons : MonoBehaviour
{
    [SerializeField] GameObject camera;
    public void Left()
    {
        camera.transform.position = new Vector3(camera.transform.position.x - 1, 0, -10);
    }
    public void Right()
    {
        camera.transform.position = new Vector3(camera.transform.position.x + 1, 0, -10);
    }
}