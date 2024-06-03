using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCameraChange : MonoBehaviour
{
    public GameObject cam;
    public Vector3 pos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        cam.transform.position = pos;
        //Destroy(gameObject);
    }
}
