using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimultaneousSwitch : MonoBehaviour
{
    public int count = 0;
    public GameObject simultaneousDoor;
    public Vector3 openByHowMuch = new(0.0f, 0.8f, 0.0f);

    private void Start()
    {
        count = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        count++;
        if(count == 1)
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        count--;
        if (count == 0)
        {
            CloseDoor();
        }
    }

    void OpenDoor() => simultaneousDoor.transform.position += openByHowMuch;
    
    void CloseDoor() => simultaneousDoor.transform.position -= openByHowMuch;

}
